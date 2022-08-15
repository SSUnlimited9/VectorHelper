using System;
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
        private string spriteDirectory, spriteOffset, spawnId, interactionId, modifierId;
        private int visualDepth;
        private bool linkedToPlayer, slowsPlayerDown;
        private Image holdableSprite;
        private Vector2 spriteDisplacement, prevLiftSpeed, Speed;
        private Holdable Hold;
        private float noGravityTimer;
        private Collision onCollideH, onCollideV;    
        public CustomHoldable(EntityData data, Vector2 offset) : this( data.Position + offset,
            data.Attr("spriteDirectory"), data.Attr("spriteOffset"), data.Int("visualDepth"),
            data.Bool("linkedToPlayer"), data.Bool("slowsPlayerDown"),
            data.Attr("spawnId"), data.Attr("interactionId"),
            data.Attr("modifierId")
        ){}

        public CustomHoldable( Vector2 position,
            string _spriteDirectory, string _spriteOffset, int _visualDepth,
            bool _linkedToPlayer, bool _slowsPlayerDown,
            string _spawnId, string _interactionId, string _modifierId)
        : base(position)
        {
            Depth = _visualDepth;
            Collider = new Hitbox(8f, 10f, -4f, 2f);
            Add(holdableSprite = new Image(GFX.Game[_spriteDirectory]));
            int[] spriteOffset = _spriteOffset.Split(',').Select(x => int.Parse(x)).ToArray();
            spriteDisplacement = new Vector2(holdableSprite.Width / 2 - spriteOffset[0], holdableSprite.Height / 2 - spriteOffset[1]);
            holdableSprite.Position -= spriteDisplacement;
            Add(Hold = new Holdable(.1f));
            Hold.PickupCollider = new Hitbox(24f, 24f, -12f, -12f);
            Hold.SlowFall = false;
            Hold.SlowRun = _slowsPlayerDown;
            Hold.OnPickup = new Action(OnPickup);
            Hold.OnRelease = new Action<Vector2>(OnRelease);
            Hold.SpeedGetter = (() => Speed);
            onCollideH = new Collision(OnCollideH);
            onCollideV = new Collision(OnCollideV);
            Add(new MirrorReflection());
        }

        public override void Added(Scene scene)
        {
            base.Added(scene);
        }

        public override void Update()
        {
            base.Update();
            if (Hold.IsHeld)
            {
                prevLiftSpeed = Vector2.Zero;
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
                        Speed.Y = Math.Min(Speed.Y * 0.6f, 0f);
                        if (Speed.X != 0f && Speed.Y == 0f)
                        {
                            Speed.Y = -60f;
                        }
                        if (Speed.Y < 0f)
                        {
                            noGravityTimer = 0.15f;
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
        private void OnCollideH(CollisionData data){
            if (data.Hit is DashSwitch)
            {
                (data.Hit as DashSwitch).OnDashCollide(null, Vector2.UnitX * (float)Math.Sign(Speed.X));
            }
            Speed.X *= -.4f;
        }
        private void OnCollideV(CollisionData data){
            if (data.Hit is DashSwitch)
            {
                (data.Hit as DashSwitch).OnDashCollide(null, Vector2.UnitY * (float)Math.Sign(Speed.Y));
            }
            if (Speed.Y > 120f && !(data.Hit is DashSwitch))
            {
                Speed.Y *= -.45f;
                return;
            }
            Speed.Y = 0f;
        }
        private void OnPickup(){
            Speed = Vector2.Zero;
            AddTag(Tags.Persistent);
        }
        private void OnRelease(Vector2 force){
            RemoveTag(Tags.Persistent);
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

        public void spawnHoldable()
        {
            Player player = Scene.Tracker.GetEntity<Player>();
            CustomHoldable customHoldable = Scene.Tracker.GetEntity<CustomHoldable>();
            if (player != null)
            {
            }
            /*
            Scene.Add(Entity[] = new CustomHoldable(
                Position + Vector2.UnitY * -20f,
                spriteDirectory, spriteOffset, visualDepth,
                linkedToPlayer, slowsPlayerDown,
                spawnId, interactionId, modifierId
            )); */
        }
    }
}