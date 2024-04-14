using AlienRace;
using Androids.Utilities;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using static AlienRace.AlienPartGenerator;

namespace Androids
{
    public static class AndroidUtility
    {
        public static void Androidify(Pawn pawn)
        {
            ThingDef_AlienRace alien = ThingDefOf.ChjAndroid as ThingDef_AlienRace;
            //pawn.story.HairColor = alien.alienRace.generalSettings.alienPartGenerator.colorChannels.FirstOrDefault(channel => channel.name == "hair").first.NewRandomizedColor();
            AlienComp alienComp = pawn.TryGetComp<AlienComp>();
            //if (alienComp != null)
            //{
            //   alienComp.ColorChannels["skin"].first = alien.alienRace.generalSettings.alienPartGenerator.colorChannels.FirstOrDefault(channel => channel.name == "skin").first.NewRandomizedColor();
            //}
            PortraitsCache.SetDirty(pawn);
            PortraitsCache.PortraitsCacheUpdate();

            //Add Android Hediff.
              if (ModChecker.HasMH())
            {
                if (!MH.IsMHAndroid(pawn))
                {
                    pawn.health.AddHediff(HediffDefOf.ChjAndroidLike);
                }
            }
            else if (ModChecker.HasATR())
            {
                if (!ATR.IsATAndroid(pawn))
                {
                    pawn.health.AddHediff(HediffDefOf.ChjAndroidLike);
                }
            }
            else
            {
                pawn.health.AddHediff(HediffDefOf.ChjAndroidLike);
            }

            //Remove old wounds and bad birthday related ones.
            List<Hediff> hediffs = pawn.health.hediffSet.hediffs.ToList();
            foreach (Hediff hediff in hediffs)
            {
                if (hediff.def.isBad)
                {
                    pawn.health.RemoveHediff(hediff);
                    pawn.health.Notify_HediffChanged(null);
                }
            }
        }

    }
}
