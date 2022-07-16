using System;

namespace Celeste.Mod.VectorHelper {
    public class VectorHelperModule : EverestModule {
        
        public static VectorHelperModule Instance;

        public VectorHelperModule() {
            Instance = this;
        }

        public override void Load() {
            Console.WriteLine("VectorHelper Loaded Successfully (hopefully)");
        }

        public override void Unload() {
        }

    }
}
