using Celeste.Mod.UI;
using Celeste;
using Celeste.Mod;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Mod.TestMod
{
    public class TestMod : EverestModule
    {
        override public void Load()
        {
            Random rnd = new Random();

            string[] motd = {
                "I pledge to not cause a catastrophic disaster in the world",
                "Uhh... hi..?",
                "Why are we here... Just to suffer...",
                "Never gonna give you up",
                "Never gonna let you down",
                "Who cut the cheese?",
                "Wheres the lamp SAUCE!?",
                "You'll never catch me gordon",
                ":)",
                "Hi, Phil Swift here with Flex Tape! The super-strong waterproof tape that can instantly patch, bond, seal, and repair!",
                "SSUnlimited was here",
                "Veggieoskibroski was here",
                "Expected ';' at line 32",
                "OH SH-! WE'RE OUTTA SPACE! Delete system32?"
            };

            int motdi = rnd.Next(motd.Length);

            Console.WriteLine(motd[motdi]);
            Console.WriteLine("VectorHelper Loaded!");


        }

        override public void Unload()
        { }

    }
}
