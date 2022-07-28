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
        public float delay;
        private string ifFlag;
        private string notFlag;
        private string flagAfterDeath;
        private bool ignoreInvincibleAssist;
        private bool registerDeathInSave;
        private bool playerInTrigger = false;
        public DelayKill(EntityData data, Vector2 offset) : base(data, offset)
        {
            data.Float("delay", 1f);
            data.Attr("ifFlag");
            data.Attr("notFlag");
            data.Attr("flagAfterDeath");
            data.Bool("ignoreInvincibleAssist");
            data.Bool("registerDeathInSave");
        }

        public override void OnEnter(Player player)
        {
            base.OnEnter(player);
            playerInTrigger = true;
            Console.WriteLine("VectorHelper: Player entered Delay Killer");
            Console.WriteLine(delay);
        }

        public override void OnLeave(Player player)
        {
            base.OnLeave(player);
            playerInTrigger = false;
            Console.WriteLine("VectorHelper: Player left Delay Killer");
            Console.WriteLine(delay);
        }

        public void Update(Player player)
        {
            base.Update();
            if (playerInTrigger)
            {
                if (delay > 0f)
                {
                    delay -= Engine.DeltaTime;
                } else
                {
                    player.Die((player.Position - Position).SafeNormalize(), ignoreInvincibleAssist, registerDeathInSave);
                }
            }
        }
    }
}