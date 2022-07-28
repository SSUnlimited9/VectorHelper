using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.VectorHelper.Triggers
{
    [CustomEntity("VectorHelper/DelayKillTrigger")]
    public class DelayKill : Trigger
    {
        private double delay;
        public DelayKill(EntityData data, Vector2 offset) : base(data, offset)
        {
            data.Float("delay", 1f);
            data.Attr("ifFlag");
            data.Attr("notFlag");
            data.Attr("flagAfterDeath");
            data.Attr("ignoreInvincibleAssist");
        }

        public override void OnEnter(Player player)
        {
            base.OnEnter(player);

            player.Die((player.Position - Position).SafeNormalize(), false, false);
        }
    }
}