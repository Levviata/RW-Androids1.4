using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using Verse.AI;

namespace Androids
{
    [HarmonyPatch(typeof(JobGiver_GetNeuralSupercharge))]
    [HarmonyPatch("GetPriority")]

    internal static class SuperchargePatch
    {
        public static void Prefix(Pawn pawn,ref JobGiver_GetNeuralSupercharge __instance, ref float __result)
        {
            if(pawn.RaceProps.FleshType.defName == "ChJDroid")
            {
                __result = 0;
            }
        }
    }
}
