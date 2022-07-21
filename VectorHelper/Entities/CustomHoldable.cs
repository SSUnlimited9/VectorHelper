using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Celeste.Mod.Entities;
using Monocle;

namespace Celeste.Mod.VectorHelper.Entities
{
    [CustomEntity("VectorHelper/CustomHoldable")]
    public class CustomHoldable
    {
        public string spriteDirectory;
        /*
        public Holdable Hold;
        private Sprite sprite;
        private Vector2 previousPosition;

        public CustomHoldable(Vector2 position) : base(position)
        {
            this.previousPosition = position;
            base.Collider = new Hitbox(8f, 10f, -4f, -10f);
            base.Add(this.sprite = GFX.SpriteBank.Create("theo_crystal"));
            this.sprite.Scale.X = -1f;
            base.Add(this.Hold = new Holdable(0.1f));
            this.Hold.PickupCollider = new Hitbox(16f, 22f, -8f, -16f);
        }

        public CustomHoldable (EntityData data, Vector2 offset)
        {

        }
         
        public CustomHoldable (Vector2 position, string spriteDirectory) : base(position)
        {
            
        }
        */

        

    }
}