using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Celeste.Mod.Entities;
using Monocle;

namespace Celeste.Mod.VectorHelper.Entities
{
    [Tracked(true)]
    [CustomEntity("VectorHelper/CustomHoldable")]
    public class CustomHoldable : Actor
    {
        public string spriteDirectory {get; set;}

        public CustomHoldable(Vector2 position) : base(position) {
            
        }
    }
}