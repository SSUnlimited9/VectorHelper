using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Celeste.Mod.Entities;
using Celeste;
using Monocle;

namespace Celeste.Mod.VectorHelper.Entities
{
    [CustomEntity("VectorHelper/CustomHoldable")]
    public class CustomHoldable : Actor
    {
        public string spriteDirectory; /* The sprite from map */

        public int depth;

        public bool killPlayerOnDestroy; public bool slowsPlayerDown;

        public Image _holdableSprite; /* The sprite for rendering with "Image" */

        public Holdable Hold;

        public Player player;

        public Vector2 spriteDisplacement;

        
        public CustomHoldable(EntityData data, Vector2 offset) : this(
            data.Position + offset,
            data.Attr("spriteDirectory","objects/resortclutter/yellow_14"),
            data.Int("depth", 100),
            data.Bool("killPlayerOnDestroy", false),
            data.Bool("slowsPlayerDown", true)
        ){}

        public CustomHoldable(Vector2 position, string _spriteDirectory, int _depth, bool _killPlayerOnDestroy, bool _slowsPlayerDown) : base(position)
        {
            Depth = _depth;
            Collider = new Hitbox(8f, 10f, -4f, 2f); /* This is the collider size for "objects/resortclutter/yellow_14" */
            MTexture holdableSprite = GFX.Game[_spriteDirectory];
            Add(_holdableSprite = new Image(holdableSprite));
            spriteDisplacement = new Vector2(_holdableSprite.Width / 2, _holdableSprite.Height / 2);
            _holdableSprite.Position -= spriteDisplacement;

            Add(Hold = new Holdable(0.1f));
            Hold.PickupCollider = new Hitbox(24f, 24f, -12f, -12f);
            Hold.SlowFall = false;
            Hold.SlowRun = _slowsPlayerDown;
        }
        public override void Added(Scene scene)
        {
            base.Added(scene);
        }
    }
}