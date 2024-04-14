using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Androids
{
    /// <summary>
    /// This thought is ALWAYS turned on for Droids.
    /// </summary>
    public class ThoughtWorker_Transhumanist : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            if ( p.health.hediffSet.HasHediff(HediffDefOf.ChjAndroidLike) &&( p.ideo.Ideo.HasMeme(DefDatabase<MemeDef>.GetNamed("Transhumanist")) || p.story.traits.HasTrait(RimWorld.TraitDefOf.Transhumanist)))
            {
                Log.Warning("Transhumanist thought active");
                return ThoughtState.ActiveAtStage(0);
            }

            return ThoughtState.Inactive;
        }
    }
}
