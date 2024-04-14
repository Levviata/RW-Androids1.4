using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Verse.AI.Group;

namespace Androids
{
    public class AndroidLikeHediff : HediffWithComps
    {
        public float energyTracked;

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref energyTracked, "energyTracked");
        }

        public override void Tick()
        {
            base.Tick();

            if(pawn.needs.TryGetNeed<Need_Energy>() is Need_Energy energy)
            {
                energyTracked = energy.CurLevel;
            }
        }

        public override void Notify_PawnDied(DamageInfo? dinfo, Hediff culprit = null)
        {
            //Log.Message("Pawn died: " + pawn);
            //Log.Message("Parent Holder: " + pawn.ParentHolder);

            if (pawn.health.hediffSet.HasHediff(HediffDefOf.ChjAndroidLike) && ThingDefOf.ChjAndroid.race.deathAction != null)
            {
                //Log.Message("Is Android");
                if (pawn.Corpse != null)
                {
                    //Log.Message("Pre: Death action worker");
                    ThingDefOf.ChjAndroid.race.DeathActionWorker.PawnDied(pawn.Corpse, pawn.GetLord());
                    //Log.Message("Post: Death action worker");
                }
            }
        }
    }
}
