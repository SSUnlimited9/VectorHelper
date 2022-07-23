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

        public Image HoldableSprite; /* The sprite for rendering with "Image" */

        public Holdable Hold; /* Do I really need to comment this? */

        public Player player;

        
        public CustomHoldable(EntityData data, Vector2 offset) : base(data.Position + offset){}

        public CustomHoldable(Vector2 position, string spriteDirectory) : base(position)
        {
            Depth = 100;
            Collider = new Hitbox(12, 12, 0, 0); /* This collider size is temporary */
            MTexture holdableSprite = GFX.Game[spriteDirectory];
            Add(HoldableSprite = new Image(holdableSprite));
        }
        public override void Added(Scene scene)
        {
            base.Added(scene);
        }
    }
}