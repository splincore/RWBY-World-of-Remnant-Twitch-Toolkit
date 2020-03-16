using RimWorld;
using RWBYRemnant;
using TwitchToolkit;
using TwitchToolkit.Store;
using Verse;

namespace RWBYTwitchToolkit
{
    public class Nuckelavee : IncidentHelper
    {
        public override bool IsPossible()
        {
            this.worker = new IncidentWorker_Nuckelavee();
            this.worker.def = IncidentDef.Named("Nuckelavee");
            Map anyPlayerMap = Helper.AnyPlayerMap;
            if (anyPlayerMap != null)
            {
                this.parms = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.Misc, anyPlayerMap);
                this.parms.forced = true;
                return this.worker.CanFireNow(this.parms, false);
            }
            return false;
        }

        public override void TryExecute()
        {
            this.worker.TryExecute(this.parms);
        }

        private IncidentParms parms;

        private IncidentWorker worker;
    }
}
