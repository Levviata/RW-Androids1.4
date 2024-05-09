using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
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
    //[HarmonyPatch(typeof(SocialCardUtility))]
    //[HarmonyPatch("ShouldShowPawnRelations")]

    //internal static class SocialCardUtilityPatch
    //{
    //    public static bool Prefix(ref bool __result, Pawn pawn, Pawn selPawnForSocialInfo)
    //    {
    //        Log.Warning("SocialCardUtilityPatch");
    //        Log.Warning("selPawnForSocialInfo:" + pawn.Name.ToStringFull);
    //        Log.Warning("relations:" + pawn.relations.hidePawnRelations);
    //        Log.Warning("animal:" + pawn.RaceProps.Animal);
    //        __result = ((!pawn.RaceProps.Animal || !pawn.Dead || pawn.Corpse != null) && pawn.Name != null && !pawn.Name.Numerical && !pawn.relations.hidePawnRelations && !selPawnForSocialInfo.relations.hidePawnRelations && pawn.relations.everSeenByPlayer);
    //        return false;
    //    }
    //}
}
