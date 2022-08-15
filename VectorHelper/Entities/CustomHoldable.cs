using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Celeste.Mod.Entities;
using Celeste;
using Monocle;

namespace Celeste.Mod.VectorHelper.Entities
{
    [TrackedAs(typeof(Actor))]
    [Tracked]
    [CustomEntity("VectorHelper/BasicCustomHoldable")]
    public class CustomHoldable : Actor
    {
        private string spriteDirectory;
        private int[] spriteOffset, visualDepth;
        private bool linkedToPlayer, slowsPlayerDown, spawnsFloating;
        private float noGravityTimer;
        private string spawnId, interactionId, modifierId;

        private Image Sprite; private Vector2 prevLiftSpeed, Speed, exactPosition;
        private Holdable Hold; private Collision onCollideH, onCollideV;
        private static ParticleType P_Impact { get; } = new ParticleType
        {
            Color = Calc.HexToColor("a69e95"),
            Size = 1f,
            FadeMode = ParticleType.FadeModes.Late,
            DirectionRange = 1.74532926f,
            SpeedMin = 10f,
            SpeedMax = 20f,
            SpeedMultiplier = 0.1f,
            LifeMin = 0.3f,
            LifeMax = 0.8f,
            
        };
        
        public CustomHoldable(EntityData data, Vector2 offset) : base(data.Position + offset)
        {
            Position.Y += 12f;
            /* Initalize all variables first then build the entity */
            Add(Sprite = new Image(GFX.Game[data.Attr("spriteDirectory")]));
            spriteOffset = data.Attr("spriteOffset").Split(',').Select(x => int.Parse(x)).ToArray(); visualDepth = data.Attr("visualDepth", "0,0").Split(',').Select(x => int.Parse(x)).ToArray(); linkedToPlayer = data.Bool("linkedToPlayer", false); slowsPlayerDown = data.Bool("slowsPlayerDown", false); spawnsFloating = data.Bool("spawnsFloating", false);
            Sprite.Position -= new Vector2(Sprite.Width / 2 - spriteOffset[0], Sprite.Height / 2 - spriteOffset[1] + 12f);
            Depth = visualDepth[0];
            /* Makes the Collider the "size" of the sprite */
            Collider = new Hitbox(Sprite.Width, Sprite.Height, (Sprite.Width / 2) * -1f, (Sprite.Height / 2) * -1f - 12f);
            Add(Hold = new Holdable(.05f));
            Hold.PickupCollider = new Hitbox(Sprite.Width + 8f, Sprite.Height + 8f, ((Sprite.Width + 8f) / 2) * -1f, ((Sprite.Height + 8f) / 2) * -1f - 12f);
            Hold.SlowFall = false;
            Hold.SlowRun = data.Bool("slowsPlayerDown", false);
            Hold.OnPickup = new Action(OnPickup);
            Hold.OnRelease = new Action<Vector2>(OnRelease);
            Hold.SpeedGetter = (() => Speed);
            onCollideH = new Collision(OnCollideH);
            onCollideV = new Collision(OnCollideV);
            Add(new MirrorReflection());

        }
        public override void Update()
        {
            base.Update();
            exactPosition = new Vector2(Position.X, Position.Y - 12f);
            if (Hold.IsHeld)
            {
                prevLiftSpeed = Vector2.Zero;
                Depth = visualDepth[1];
            } else
            {
                if (OnGround())
                {
                    float target = (!OnGround(Position + Vector2.UnitX * 3f)) ? 20f : (OnGround(Position - Vector2.UnitX * 3f) ? 0f : (-20f));
                    Speed.X = Calc.Approach(Speed.X, target, 800f * Engine.DeltaTime);
                    Vector2 liftSpeed = base.LiftSpeed;
                    if (liftSpeed == Vector2.Zero && prevLiftSpeed != Vector2.Zero)
                    {
                        Speed = prevLiftSpeed;
                        prevLiftSpeed = Vector2.Zero;
                        Speed.Y = Math.Min(Speed.Y * .6f, 0f);
                        if (Speed.Y != 0f && Speed.Y == 0f)
                        {
                            Speed.Y = -60f;
                        }
                        if (Speed.Y < 0f)
                        {
                            noGravityTimer = .15f;
                        }
                    } else
                    {
                        prevLiftSpeed = liftSpeed;
                        if (liftSpeed.Y < 0f && Speed.Y < 0f)
                        {
                            Speed.Y = 0f;
                        }
                    }
                } else if (Hold.ShouldHaveGravity)
                {
                    float num = 800f;
                    if (Math.Abs(Speed.Y) <= 30f)
                    {
                        num *= .5f;
                    }
                    float num2 = 350f;
                    if (Speed.Y < 0f)
                    {
                        num2 *= .5f;
                    }
                    Speed.X = Calc.Approach(Speed.X, 0f, num2 * Engine.DeltaTime);
                    if (noGravityTimer > 0f)
                    {
                        noGravityTimer -= Engine.DeltaTime;
                    } else
                    {
                        Speed.Y = Calc.Approach(Speed.Y, 200f, num * Engine.DeltaTime);
                    }
                }
                MoveH(Speed.X * Engine.DeltaTime, OnCollideH);
                MoveV(Speed.Y * Engine.DeltaTime, OnCollideV);
            }
        }
        private void OnCollideH(CollisionData data)
        {
            if (data.Hit is DashSwitch)
            {
                (data.Hit as DashSwitch).OnDashCollide(null, Vector2.UnitX * (float)Math.Sign(Speed.X));
            }
            if (Speed.X > 80f)
            {
                ImpactParticles(data.Direction);
            }
            Speed.X *= -.4f;
        }
        private void OnCollideV(CollisionData data)
        {
            if (data.Hit is DashSwitch)
            {
                (data.Hit as DashSwitch).OnDashCollide(null, Vector2.UnitY * (float)Math.Sign(Speed.Y));
            }
            if (Speed.Y > 100f)
            {
                ImpactParticles(data.Direction);
            }
            if (Speed.Y > 70f && !(data.Hit is DashSwitch))
            {
                Speed.Y *= -.425f;
                return;
            }
            Speed.Y = 0f;
        }
        private void ImpactParticles(Vector2 dir)
        {
            float direction;
            Vector2 position;
            Vector2 positionRange;
            float sizeX;
            if (Sprite.Width > 2f) { sizeX = Sprite.Width / 2f; } else { sizeX = Sprite.Width; }
            float sizeY;
            if (Sprite.Height > 2f) { sizeY = Sprite.Height / 2f; } else { sizeY = Sprite.Height; }
            if (dir.X > 0f)
            {
                direction = (float)Math.PI;
                position = new Vector2(Right, Center.Y);
                positionRange = Vector2.UnitY * sizeY;
            }
            else if (dir.X < 0f)
            {
                direction = 0f;
                position = new Vector2(Left, Center.Y);
                positionRange = Vector2.UnitY * sizeY;
            }
            else if (dir.Y > 0f)
            {
                direction = -(float)Math.PI / 2f;
                position = new Vector2(Center.X, Bottom);
                positionRange = Vector2.UnitX * sizeX;
            }
            else
            {
                direction = (float)Math.PI / 2f;
                position = new Vector2(Center.X, Top);
                positionRange = Vector2.UnitX * sizeX;
            }
            (Scene as Level).Particles.Emit(P_Impact, 12, position, positionRange, direction);
        }
        private void OnPickup()
        {
            Speed = Vector2.Zero;
            AddTag(Tags.Persistent);
            Collidable = false;
        }
        private void OnRelease(Vector2 force)
        {
            RemoveTag(Tags.Persistent);
            Collidable = true;
            if (force.X != 0f && force.Y == 0f)
            {
                force.Y = -.4f;
            }
            Speed = force * 200f;
            if (Speed != Vector2.Zero)
            {
                noGravityTimer = .1f;
            }
        }
        public override bool IsRiding(Solid solid)
        {
            return Speed.Y == 0f && base.IsRiding(solid);
        }
    }
}