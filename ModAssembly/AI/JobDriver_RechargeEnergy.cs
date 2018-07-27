﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Verse.AI;

namespace Androids
{
    /// <summary>
    /// Walks to the target power net and recharges their power need from it.
    /// </summary>
    public class JobDriver_RechargeEnergy : JobDriver
    {
        private const TargetIndex PowerDestIndex = TargetIndex.A;

        private const TargetIndex AlternateDestIndex = TargetIndex.B;

        public Building powerBuilding => TargetA.Thing as Building;

        public Need_Energy energyNeed;

        public override void Notify_Starting()
        {
            base.Notify_Starting();

            energyNeed = GetActor().needs.TryGetNeed<Need_Energy>();
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
            this.FailOnDestroyedNullOrForbidden(PowerDestIndex);
            AddFailCondition(() => energyNeed == null);

            yield return Toils_Reserve.Reserve(PowerDestIndex);
            if (!TargetB.IsValid)
            {
                yield return Toils_Goto.GotoThing(PowerDestIndex, PathEndMode.ClosestTouch);
            }
            else
            {
                yield return Toils_Reserve.Reserve(AlternateDestIndex);
                yield return Toils_Goto.GotoThing(AlternateDestIndex, PathEndMode.OnCell);
            }

            Toil rechargeToil = new Toil();
            
            rechargeToil.tickAction = delegate
            {
                //Drain the powernet.
                CompPowerBattery compBattery = powerBuilding.PowerComp?.PowerNet?.batteryComps?.FirstOrDefault(battery => battery.StoredEnergy > 1.32f);

                if(compBattery != null)
                {
                    compBattery.DrawPower(1.32f);

                    //Add to our energy.
                    energyNeed.CurLevel += 1f / 300f;
                }
            };
            rechargeToil.AddEndCondition(delegate
            {
                if (powerBuilding == null || powerBuilding.PowerComp == null /*|| temporaryTrader == null*/)
                    return JobCondition.Incompletable;

                if(powerBuilding.PowerComp?.PowerNet.CurrentStoredEnergy() < 1.32f)
                    return JobCondition.Incompletable;

                if (energyNeed.CurLevelPercentage >= 0.99f)
                    return JobCondition.Succeeded;

                return JobCondition.Ongoing;
            });

            if (!TargetB.IsValid)
                rechargeToil.FailOnCannotTouch(PowerDestIndex, PathEndMode.ClosestTouch);
            else
                rechargeToil.FailOnCannotTouch(AlternateDestIndex, PathEndMode.OnCell);

            rechargeToil.WithProgressBar(TargetIndex.A, () => energyNeed.CurLevelPercentage, false);
            rechargeToil.defaultCompleteMode = ToilCompleteMode.Never;
            yield return rechargeToil;
        }

        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            if (!pawn.CanReserve(TargetA))
                return false;

            if (TargetB.IsValid)
            {
                if(!pawn.CanReserve(TargetB))
                {
                    return false;
                }
                else
                {
                    pawn.Reserve(TargetB, job, errorOnFailed: errorOnFailed);
                }
            }

            pawn.Reserve(TargetA, job, errorOnFailed: errorOnFailed);

            return true;
        }
    }
}
