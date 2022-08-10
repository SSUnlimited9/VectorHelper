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
    [CustomEntity("VectorHelper/DelayedKillTrigger")]
    public class DelayedKillTrigger : Trigger
    {
        private float delay, iDelay;
        private bool[] deathOptions = new bool[2];
        private bool resetDelayOnLeave, resetDelayIfInvincible;
        public DelayedKillTrigger(EntityData data, Vector2 offset) : base(data, offset)
        {
            delay = data.Float("delay"); iDelay = delay;
            deathOptions[0] = data.Bool("ignoreInvincibleAssist");
            deathOptions[1] = data.Bool("addToDeathCount");
            resetDelayOnLeave = data.Bool("resetDelayOnLeave");
            resetDelayIfInvincible = data.Bool("resetDelayIfInvincible");
        }

        public override void OnLeave(Player player)
        {
            base.OnLeave(player);
            if (resetDelayOnLeave) { delay = iDelay; }
        }

        public override void OnStay(Player player)
        {
            base.OnStay(player);
            if (resetDelayIfInvincible && SaveData.Instance.Assists.Invincible) { delay = iDelay++; }
            if (delay > 0 )
            {
                delay -= Engine.DeltaTime;
            } else
            { player.Die(Vector2.Zero, deathOptions[0], deathOptions[1]); }
            
            if (resetDelayIfInvincible && SaveData.Instance.Assists.Invincible) { delay = iDelay; }
            /* Did this since having an extremely small delay still does the kill action */
        }
    }
}