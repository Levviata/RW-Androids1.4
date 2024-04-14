using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Androids.Utilities
{
    public static class ModChecker
    {
        public static bool HasATR()
        {
            foreach (ModContentPack p in LoadedModManager.RunningMods)
            {
                if (p.Name == "Android Tiers Reforged")
                {
                    return true;
                }
            }
            return false;
        }
        public static bool HasMH()
        {
            foreach (ModContentPack p in LoadedModManager.RunningMods)
            {
                if (p.Name == "MH: Android Tiers")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
