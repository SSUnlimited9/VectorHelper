using System;
using System.Collections;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste
{
	// Token: 0x02000765 RID: 1893
	[Tracked(false)]
	public class TheoCrystal : Actor
	{
		// Token: 0x06002F3D RID: 12093 RVA: 0x00117F3C File Offset: 0x0011613C
		public TheoCrystal(Vector2 position) : base(position)
		{
			this.previousPosition = position;
			base.Depth = 100;
			base.Collider = new Hitbox(8f, 10f, -4f, -10f);
			base.Add(this.sprite = GFX.SpriteBank.Create("theo_crystal"));
			this.sprite.Scale.X = -1f;
			base.Add(this.Hold = new Holdable(0.1f));
			this.Hold.PickupCollider = new Hitbox(16f, 22f, -8f, -16f);
			this.Hold.SlowFall = false;
			this.Hold.SlowRun = true;
			this.Hold.OnPickup = new Action(this.OnPickup);
			this.Hold.OnRelease = new Action<Vector2>(this.OnRelease);
			this.Hold.DangerousCheck = new Func<HoldableCollider, bool>(this.Dangerous);
			this.Hold.OnHitSeeker = new Action<Seeker>(this.HitSeeker);
			this.Hold.OnSwat = new Action<HoldableCollider, int>(this.Swat);
			this.Hold.OnHitSpring = new Func<Spring, bool>(this.HitSpring);
			this.Hold.OnHitSpinner = new Action<Entity>(this.HitSpinner);
			this.Hold.SpeedGetter = (() => this.Speed);
			this.onCollideH = new Collision(this.OnCollideH);
			this.onCollideV = new Collision(this.OnCollideV);
			this.LiftSpeedGraceTime = 0.1f;
			base.Add(new VertexLight(base.Collider.Center, Color.White, 1f, 32, 64));
			base.Tag = Tags.TransitionUpdate;
			base.Add(new MirrorReflection());
		}

		// Token: 0x06002F3E RID: 12094 RVA: 0x0011812C File Offset: 0x0011632C
		public TheoCrystal(EntityData e, Vector2 offset) : this(e.Position + offset)
		{
		}

		// Token: 0x06002F3F RID: 12095 RVA: 0x00118140 File Offset: 0x00116340
		public override void Added(Scene scene)
		{
			base.Added(scene);
			this.Level = base.SceneAs<Level>();
			foreach (Entity entity in this.Level.Tracker.GetEntities<TheoCrystal>())
			{
				TheoCrystal theoCrystal = (TheoCrystal)entity;
				if (theoCrystal != this && theoCrystal.Hold.IsHeld)
				{
					base.RemoveSelf();
				}
			}
			if (this.Level.Session.Level == "e-00")
			{
				this.tutorialGui = new BirdTutorialGui(this, new Vector2(0f, -24f), Dialog.Clean("tutorial_carry", null), new object[]
				{
					Dialog.Clean("tutorial_hold", null),
					BirdTutorialGui.ButtonPrompt.Grab
				});
				this.tutorialGui.Open = false;
				base.Scene.Add(this.tutorialGui);
			}
		}

		// Token: 0x06002F40 RID: 12096 RVA: 0x00118244 File Offset: 0x00116444
		public override void Update()
		{
			base.Update();
			if (this.shattering || this.dead)
			{
				return;
			}
			if (this.swatTimer > 0f)
			{
				this.swatTimer -= Engine.DeltaTime;
			}
			this.hardVerticalHitSoundCooldown -= Engine.DeltaTime;
			if (this.OnPedestal)
			{
				base.Depth = 8999;
				return;
			}
			base.Depth = 100;
			if (this.Hold.IsHeld)
			{
				this.prevLiftSpeed = Vector2.Zero;
			}
			else
			{ 
				if (base.OnGround(1))
				{
					float target;
					if (!base.OnGround(this.Position + Vector2.UnitX * 3f, 1))
					{
						target = 20f;
					}
					else if (!base.OnGround(this.Position - Vector2.UnitX * 3f, 1))
					{
						target = -20f;
					}
					else
					{
						target = 0f;
					}
					this.Speed.X = Calc.Approach(this.Speed.X, target, 800f * Engine.DeltaTime);
					Vector2 liftSpeed = base.LiftSpeed;
					if (liftSpeed == Vector2.Zero && this.prevLiftSpeed != Vector2.Zero)
					{ 
						this.Speed = this.prevLiftSpeed;
						this.prevLiftSpeed = Vector2.Zero;
						this.Speed.Y = Math.Min(this.Speed.Y * 0.6f, 0f);
						if (this.Speed.X != 0f && this.Speed.Y == 0f)
						{
							this.Speed.Y = -60f;
						}
						if (this.Speed.Y < 0f)
						{
							this.noGravityTimer = 0.15f;
						}
					}
					else
					{
						this.prevLiftSpeed = liftSpeed;
						if (liftSpeed.Y < 0f && this.Speed.Y < 0f)
						{
							this.Speed.Y = 0f;
						}
					}
				}
				else if (this.Hold.ShouldHaveGravity)
				{
					float num = 800f;
					if (Math.Abs(this.Speed.Y) <= 30f)
					{
						num *= 0.5f;
					}
					float num2 = 350f;
					if (this.Speed.Y < 0f)
					{
						num2 *= 0.5f;
					}
					this.Speed.X = Calc.Approach(this.Speed.X, 0f, num2 * Engine.DeltaTime);
					if (this.noGravityTimer > 0f)
					{
						this.noGravityTimer -= Engine.DeltaTime;
					}
					else
					{
						this.Speed.Y = Calc.Approach(this.Speed.Y, 200f, num * Engine.DeltaTime);
					}
				}
				this.previousPosition = base.ExactPosition;
				base.MoveH(this.Speed.X * Engine.DeltaTime, this.onCollideH, null);
				base.MoveV(this.Speed.Y * Engine.DeltaTime, this.onCollideV, null);
				if (base.Center.X > (float)this.Level.Bounds.Right)
				{
					base.MoveH(32f * Engine.DeltaTime, null, null);
					if (base.Left - 8f > (float)this.Level.Bounds.Right)
					{
						base.RemoveSelf();
					}
				}
				else if (base.Left < (float)this.Level.Bounds.Left)
				{
					base.Left = (float)this.Level.Bounds.Left;
					this.Speed.X = this.Speed.X * -0.4f;
				}
				else if (base.Top < (float)(this.Level.Bounds.Top - 4))
				{
					base.Top = (float)(this.Level.Bounds.Top + 4);
					this.Speed.Y = 0f;
				}
				else if (base.Bottom > (float)this.Level.Bounds.Bottom && SaveData.Instance.Assists.Invincible)
				{
					base.Bottom = (float)this.Level.Bounds.Bottom;
					this.Speed.Y = -300f;
					Audio.Play("event:/game/general/assist_screenbottom", this.Position);
				}
				else if (base.Top > (float)this.Level.Bounds.Bottom)
				{
					this.Die();
				}
				if (base.X < (float)(this.Level.Bounds.Left + 10))
				{
					base.MoveH(32f * Engine.DeltaTime, null, null);
				}
				Player entity = base.Scene.Tracker.GetEntity<Player>();
				TempleGate templeGate = base.CollideFirst<TempleGate>();
				if (templeGate != null && entity != null)
				{
					templeGate.Collidable = false;
					base.MoveH((float)(Math.Sign(entity.X - base.X) * 32) * Engine.DeltaTime, null, null);
					templeGate.Collidable = true;
				}
			}
			if (!this.dead)
			{
				this.Hold.CheckAgainstColliders();
			}
			if (this.hitSeeker != null && this.swatTimer <= 0f && !this.hitSeeker.Check(this.Hold))
			{
				this.hitSeeker = null;
			}
			if (this.tutorialGui != null)
			{
				if (!this.OnPedestal && !this.Hold.IsHeld && base.OnGround(1) && this.Level.Session.GetFlag("foundTheoInCrystal"))
				{
					this.tutorialTimer += Engine.DeltaTime;
				}
				else
				{
					this.tutorialTimer = 0f;
				}
				this.tutorialGui.Open = (this.tutorialTimer > 0.25f);
			}
		}

		// Token: 0x06002F41 RID: 12097 RVA: 0x0011884C File Offset: 0x00116A4C
		public IEnumerator Shatter()
		{
			this.shattering = true;
			BloomPoint bloom = new BloomPoint(0f, 32f);
			VertexLight light = new VertexLight(Color.AliceBlue, 0f, 64, 200);
			this.Add(bloom);
			this.Add(light);
			for (float p = 0f; p < 1f; p += Engine.DeltaTime)
			{
				this.Position += this.Speed * (1f - p) * Engine.DeltaTime;
				this.Level.ZoomFocusPoint = this.TopCenter - this.Level.Camera.Position;
				light.Alpha = p;
				bloom.Alpha = p;
				yield return null;
			}
			yield return 0.5f;
			this.Level.Shake(0.3f);
			this.sprite.Play("shatter", false, false);
			yield return 1f;
			this.Level.Shake(0.3f);
			yield break;
		}

		// Token: 0x06002F42 RID: 12098 RVA: 0x0011885C File Offset: 0x00116A5C
		public void ExplodeLaunch(Vector2 from)
		{
			if (!this.Hold.IsHeld)
			{
				this.Speed = (base.Center - from).SafeNormalize(120f);
				SlashFx.Burst(base.Center, this.Speed.Angle());
			}
		}

		// Token: 0x06002F43 RID: 12099 RVA: 0x001188A9 File Offset: 0x00116AA9
		public void Swat(HoldableCollider hc, int dir)
		{
			if (this.Hold.IsHeld && this.hitSeeker == null)
			{
				this.swatTimer = 0.1f;
				this.hitSeeker = hc;
				this.Hold.Holder.Swat(dir);
			}
		}

		// Token: 0x06002F44 RID: 12100 RVA: 0x001188E3 File Offset: 0x00116AE3
		public bool Dangerous(HoldableCollider holdableCollider)
		{
			return !this.Hold.IsHeld && this.Speed != Vector2.Zero && this.hitSeeker != holdableCollider;
		}

		// Token: 0x06002F45 RID: 12101 RVA: 0x00118914 File Offset: 0x00116B14
		public void HitSeeker(Seeker seeker)
		{
			if (!this.Hold.IsHeld)
			{
				this.Speed = (base.Center - seeker.Center).SafeNormalize(120f);
			}
			Audio.Play("event:/game/05_mirror_temple/crystaltheo_hit_side", this.Position);
		}

		// Token: 0x06002F46 RID: 12102 RVA: 0x00118960 File Offset: 0x00116B60
		public void HitSpinner(Entity spinner)
		{
			if (!this.Hold.IsHeld && this.Speed.Length() < 0.01f && base.LiftSpeed.Length() < 0.01f && (this.previousPosition - base.ExactPosition).Length() < 0.01f && base.OnGround(1))
			{
				int num = Math.Sign(base.X - spinner.X);
				if (num == 0)
				{
					num = 1;
				}
				this.Speed.X = (float)num * 120f;
				this.Speed.Y = -30f;
			}
		}

		// Token: 0x06002F47 RID: 12103 RVA: 0x00118A0C File Offset: 0x00116C0C
		public bool HitSpring(Spring spring)
		{
			if (!this.Hold.IsHeld)
			{
				if (spring.Orientation == Spring.Orientations.Floor && this.Speed.Y >= 0f)
				{
					this.Speed.X = this.Speed.X * 0.5f;
					this.Speed.Y = -160f;
					this.noGravityTimer = 0.15f;
					return true;
				}
				if (spring.Orientation == Spring.Orientations.WallLeft && this.Speed.X <= 0f)
				{
					base.MoveTowardsY(spring.CenterY + 5f, 4f, null);
					this.Speed.X = 220f;
					this.Speed.Y = -80f;
					this.noGravityTimer = 0.1f;
					return true;
				}
				if (spring.Orientation == Spring.Orientations.WallRight && this.Speed.X >= 0f)
				{
					base.MoveTowardsY(spring.CenterY + 5f, 4f, null);
					this.Speed.X = -220f;
					this.Speed.Y = -80f;
					this.noGravityTimer = 0.1f;
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002F48 RID: 12104 RVA: 0x00118B38 File Offset: 0x00116D38
		private void OnCollideH(CollisionData data)
		{
			if (data.Hit is DashSwitch)
			{
				(data.Hit as DashSwitch).OnDashCollide(null, Vector2.UnitX * (float)Math.Sign(this.Speed.X));
			}
			Audio.Play("event:/game/05_mirror_temple/crystaltheo_hit_side", this.Position);
			if (Math.Abs(this.Speed.X) > 100f)
			{
				this.ImpactParticles(data.Direction);
			}
			this.Speed.X = this.Speed.X * -0.4f;
		}

		// Token: 0x06002F49 RID: 12105 RVA: 0x00118BCC File Offset: 0x00116DCC
		private void OnCollideV(CollisionData data)
		{
			if (data.Hit is DashSwitch)
			{
				(data.Hit as DashSwitch).OnDashCollide(null, Vector2.UnitY * (float)Math.Sign(this.Speed.Y));
			}
			if (this.Speed.Y > 0f)
			{
				if (this.hardVerticalHitSoundCooldown <= 0f)
				{
					Audio.Play("event:/game/05_mirror_temple/crystaltheo_hit_ground", this.Position, "crystal_velocity", Calc.ClampedMap(this.Speed.Y, 0f, 200f, 0f, 1f));
					this.hardVerticalHitSoundCooldown = 0.5f;
				}
				else
				{
					Audio.Play("event:/game/05_mirror_temple/crystaltheo_hit_ground", this.Position, "crystal_velocity", 0f);
				}
			}
			if (this.Speed.Y > 160f)
			{
				this.ImpactParticles(data.Direction);
			}
			if (this.Speed.Y > 140f && !(data.Hit is SwapBlock) && !(data.Hit is DashSwitch))
			{
				this.Speed.Y = this.Speed.Y * -0.6f;
				return;
			}
			this.Speed.Y = 0f;
		}

		// Token: 0x06002F4A RID: 12106 RVA: 0x00118D08 File Offset: 0x00116F08
		private void ImpactParticles(Vector2 dir)
		{
			float direction;
			Vector2 position;
			Vector2 positionRange;
			if (dir.X > 0f)
			{
				direction = 3.1415927f;
				position = new Vector2(base.Right, base.Y - 4f);
				positionRange = Vector2.UnitY * 6f;
			}
			else if (dir.X < 0f)
			{
				direction = 0f;
				position = new Vector2(base.Left, base.Y - 4f);
				positionRange = Vector2.UnitY * 6f;
			}
			else if (dir.Y > 0f)
			{
				direction = -1.5707964f;
				position = new Vector2(base.X, base.Bottom);
				positionRange = Vector2.UnitX * 6f;
			}
			else
			{
				direction = 1.5707964f;
				position = new Vector2(base.X, base.Top);
				positionRange = Vector2.UnitX * 6f;
			}
			this.Level.Particles.Emit(TheoCrystal.P_Impact, 12, position, positionRange, direction);
		}

		// Token: 0x06002F4B RID: 12107 RVA: 0x00118E0F File Offset: 0x0011700F
		public override bool IsRiding(Solid solid)
		{
			return this.Speed.Y == 0f && base.IsRiding(solid);
		}

		// Token: 0x06002F4C RID: 12108 RVA: 0x00118E2C File Offset: 0x0011702C
		protected override void OnSquish(CollisionData data)
		{
			if (!base.TrySquishWiggle(data, 3, 3) && !SaveData.Instance.Assists.Invincible)
			{
				this.Die();
			}
		}

		// Token: 0x06002F4D RID: 12109 RVA: 0x00118E50 File Offset: 0x00117050
		private void OnPickup()
		{
			this.Speed = Vector2.Zero;
			base.AddTag(Tags.Persistent);
		}

		// Token: 0x06002F4E RID: 12110 RVA: 0x00118E70 File Offset: 0x00117070
		private void OnRelease(Vector2 force)
		{
			base.RemoveTag(Tags.Persistent);
			if (force.X != 0f && force.Y == 0f)
			{
				force.Y = -0.4f;
			}
			this.Speed = force * 200f;
			if (this.Speed != Vector2.Zero)
			{
				this.noGravityTimer = 0.1f;
			}
		}

		// Token: 0x06002F4F RID: 12111 RVA: 0x00118EE4 File Offset: 0x001170E4
		public void Die()
		{
			if (!this.dead)
			{
				this.dead = true;
				Player entity = this.Level.Tracker.GetEntity<Player>();
				if (entity != null)
				{
					entity.Die(-Vector2.UnitX * (float)entity.Facing, false, true);
				}
				Audio.Play("event:/char/madeline/death", this.Position);
				base.Add(new DeathEffect(Color.ForestGreen, new Vector2?(base.Center - this.Position)));
				this.sprite.Visible = false;
				base.Depth = -1000000;
				this.AllowPushing = false;
			}
		}

		// Token: 0x040028FC RID: 10492
		public static ParticleType P_Impact;

		// Token: 0x040028FD RID: 10493
		public Vector2 Speed;

		// Token: 0x040028FE RID: 10494
		public bool OnPedestal;

		// Token: 0x040028FF RID: 10495
		public Holdable Hold;

		// Token: 0x04002900 RID: 10496
		private Sprite sprite;

		// Token: 0x04002901 RID: 10497
		private bool dead;

		// Token: 0x04002902 RID: 10498
		private Level Level;

		// Token: 0x04002903 RID: 10499
		private Collision onCollideH;

		// Token: 0x04002904 RID: 10500
		private Collision onCollideV;

		// Token: 0x04002905 RID: 10501
		private float noGravityTimer;

		// Token: 0x04002906 RID: 10502
		private Vector2 prevLiftSpeed;

		// Token: 0x04002907 RID: 10503
		private Vector2 previousPosition;

		// Token: 0x04002908 RID: 10504
		private HoldableCollider hitSeeker;

		// Token: 0x04002909 RID: 10505
		private float swatTimer;

		// Token: 0x0400290A RID: 10506
		private bool shattering;

		// Token: 0x0400290B RID: 10507
		private float hardVerticalHitSoundCooldown;

		// Token: 0x0400290C RID: 10508
		private BirdTutorialGui tutorialGui;

		// Token: 0x0400290D RID: 10509
		private float tutorialTimer;
	}
}
