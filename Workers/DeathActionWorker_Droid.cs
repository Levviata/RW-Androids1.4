using Androids.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using Verse.AI.Group;

namespace Androids.Workers
{
    public class DeathActionWorker_Droid : DeathActionWorker
    {
        public DeathActionProps_Droid Props
        {
            get
            {
                return (DeathActionProps_Droid)this.props;
            }
        }
    
        public override void PawnDied(Corpse corpse, Lord prevLord)
        {
            if (!AndroidsModSettings.Instance.androidExplodesOnDeath)
                return;

            //Pawn
            Pawn pawn = corpse.InnerPawn;

            //Try get energy tracker.
            EnergyTrackerComp energy = pawn.TryGetComp<EnergyTrackerComp>();

            bool shouldBeDeadByNaturalCauses = pawn.health.hediffSet.hediffs.Any(hediff => hediff.CauseDeathNow());

            Hediff overheatingHediff = pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.ChjOverheating);
            bool deadFromOverheating = overheatingHediff != null ? overheatingHediff.Severity >= 1f : false;

            if (overheatingHediff != null || !shouldBeDeadByNaturalCauses)
            {
                float explosionRadius = AndroidsModSettings.Instance.androidExplosionRadius * energy.energy;

                if (deadFromOverheating)
                    explosionRadius *= 2;

                //Scale explosion strength from how much remaining energy we got.
                if (explosionRadius >= 1f)
                {
                    GenExplosion.DoExplosion(corpse.Position, corpse.Map, explosionRadius, RimWorld.DamageDefOf.Bomb, corpse.InnerPawn);
                }
            }

            //Remove corpse.
            if (!corpse.Destroyed)
            {
                ButcherUtility.SpawnDrops(corpse.InnerPawn, corpse.Position, corpse.Map);

                //Dump inventory.
                if (corpse.InnerPawn.apparel != null)
                    corpse.InnerPawn.apparel.DropAll(corpse.PositionHeld);

                corpse.Destroy(DestroyMode.Vanish);
            }
        }
    }
}

