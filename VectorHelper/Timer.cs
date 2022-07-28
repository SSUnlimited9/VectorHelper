using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Celeste;
using Monocle;

namespace Celeste.Mod.VectorHelper
{
    public class Timer
    {
        public long initTime; // Initial time (in ms)
        public long depTime; // Depleted Time (in ms)
        public Action timerCallback; // The function to call after the timer is complete
        public Timer(long _initTime, Action _callback) {
            initTime = _initTime;
            depTime = 0;
            timerCallback = _callback;
            Console.WriteLine("Timer Initialized (" + _initTime + " ms)");
            Update();
        }
        private void Update() {
            
            while (depTime < initTime) {
                depTime += Convert.ToInt64(Math.Floor(Engine.DeltaTime * 1000));
                Console.WriteLine("[VectHelp] depTime: " + depTime.ToString() + "; initTime: " + initTime.ToString());
                if (depTime >= initTime) timerCallback();
            }
        }
    }
}