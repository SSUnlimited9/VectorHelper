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
            Console.WriteLine("I pledge to not spill 8.3 tons of oil into the gulf of mexico")
        }

        override public void Unload()
        { }

    }
}
