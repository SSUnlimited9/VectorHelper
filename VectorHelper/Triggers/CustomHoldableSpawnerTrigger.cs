using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Celeste.Mod.Entities;
using Celeste;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.VectorHelper.Triggers
{

    
    [CustomEntity("VectorHelper/CustomHoldableSpawnerTrigger")]
    public class CustomHoldableSpawnerTrigger : Trigger
    {
        public CustomHoldableSpawnerTrigger(EntityData data, Vector2 offset) : base(data, offset) {}
    }
}