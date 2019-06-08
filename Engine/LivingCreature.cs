using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class LivingCreature
    {
        public int CurrenthitPoints { get; set;}
        public int MaximumHitPoints { get; set; }

        public LivingCreature(int currentHitPoints, int maximumHitPoints)
        {
            CurrenthitPoints = currentHitPoints;
            MaximumHitPoints = maximumHitPoints;
        }
    }
}
