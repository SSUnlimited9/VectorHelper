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
    [CustomEntity("VectorHelper/CustomHoldableSpawner")]
    public class HoldableSpawner : Trigger
    {
        public HoldableSpawner(EntityData _entityData, Vector2 _offset) : base(_entityData, _offset) {

        }
    }
}