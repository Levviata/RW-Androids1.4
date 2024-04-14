using Androids.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Verse.AI.Group;

namespace Androids.Workers
{
    /// <summary>
    /// Makes the Pawn explode with varied degree on death.
    /// </summary>
    public class DeathActionProps_Android : DeathActionProperties
    {
        public DeathActionProps_Android()
        {
            workerClass  = typeof(DeathActionWorker_Android);
        }
        public override IEnumerable<string> ConfigErrors()
        {
            yield break;
        }
    }
}
