using Androids.Integration;
using Androids.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Verse.AI.Group;

namespace Androids.Workers
{
    /// <summary>
    /// Makes the pawn explode like a Android and drop some butchery products on death.
    /// </summary>
    public class DeathActionProps_Droid : DeathActionProperties
    {
        public DeathActionProps_Droid()
        {
            workerClass = typeof(DeathActionWorker_Droid);
        }
        public override IEnumerable<string> ConfigErrors()
        {
            yield break;
        }
    }
}
