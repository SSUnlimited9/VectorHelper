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
    [CustomEntity(new string[] {"VectorHelper/BasicCustomHoldable"})]
    public class CustomHoldable : Actor
    {
        
        private string spriteDirectory, spriteOffset;
        private int visualDepth;
        private bool linkedToPlayer, slowsPlayerDown;
        private Image _holdableSprite;
        private Vector2 spriteDisplacement;
        private Holdable Hold;
        public CustomHoldable(EntityData data, Vector2 offset) : this( data.Position + offset,
            data.Attr("spriteDirectory"), data.Attr("spriteOffset"), data.Int("visualDepth"),
            data.Bool("linkedToPlayer"), data.Bool("slowsPlayerDown")
        ){}

        public CustomHoldable( Vector2 position,
            string _spriteDirectory, string _spriteOffset, int _visualDepth,
            bool _linkedToPlayer, bool _slowsPlayerDown)
        : base(position)
        {
            Depth = _visualDepth;
            Collider = new Hitbox(8f, 10f, -4f, 2f);
            Add(_holdableSprite = new Image(GFX.Game[_spriteDirectory]));
            int[] spriteOffset = _spriteOffset.Split(',').Select(x => int.Parse(x)).ToArray();
            spriteDisplacement = new Vector2(_holdableSprite.Width / 2 - spriteOffset[0], _holdableSprite.Height / 2 - spriteOffset[1]);
            _holdableSprite.Position -= spriteDisplacement;
            Add(Hold = new Holdable(.1f));
            Hold.PickupCollider = new Hitbox(24f, 24f, -12f, -12f);
            Hold.SlowFall = false;
            Hold.SlowRun = _slowsPlayerDown;
        }

        public override void Added(Scene scene)
        {
            base.Added(scene);
        }

        public override void Update()
        {
            base.Update();
            
        }
    }
}