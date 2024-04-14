//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using HarmonyLib;
//using RimWorld;
//using SaveOurShip2;
//using Verse;

//namespace Androids.Patches
//{
//    [HarmonyPatch(typeof(ShipInteriorMod2))]
//    [HarmonyPatch("EVAlevelSlow")]

//    internal static class SOS
//    {
//        public static void Postfix(Pawn pawn, ref byte __result)
//        {
//            if (pawn.health.hediffSet.HasHediff(HediffDefOf.ChjAndroidLike))
//            {
//                if(__result < 8)
//                {
//                    __result = 8;
//                }
//            }
//        }

//    }
//}
