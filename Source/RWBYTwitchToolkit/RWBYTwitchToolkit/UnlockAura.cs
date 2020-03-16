using RimWorld;
using RWBYRemnant;
using System.Collections.Generic;
using System.Linq;
using TwitchToolkit;
using TwitchToolkit.Store;
using Verse;

namespace RWBYTwitchToolkit
{
    public class UnlockAura : IncidentHelper
    {
        public override bool IsPossible()
        {
            Map map = Helper.AnyPlayerMap;
            if (map != null)
            {
                List<Pawn> possibleTargets = map.mapPawns.AllPawns.FindAll(p => p.IsColonistPlayerControlled && !p.health.hediffSet.HasHediff(RWBYDefOf.RWBY_AuraStolen) && !p.story.traits.HasTrait(RWBYDefOf.RWBY_Aura) && !SemblanceUtility.semblanceList.Any(s => p.story.traits.HasTrait(s)));
                return possibleTargets.Count > 0;
            }
            return false;
        }

        public override void TryExecute()
        {
            Map map = Helper.AnyPlayerMap;
            if (map != null)
            {
                List<Pawn> possibleTargets = map.mapPawns.AllPawns.FindAll(p => p.IsColonistPlayerControlled && !p.health.hediffSet.HasHediff(RWBYDefOf.RWBY_AuraStolen) && !p.story.traits.HasTrait(RWBYDefOf.RWBY_Aura) && !SemblanceUtility.semblanceList.Any(s => p.story.traits.HasTrait(s)));
                SemblanceUtility.UnlockAura(possibleTargets.RandomElement(), "LetterTextUnlockAuraAuto");
            }
        }

        private IncidentParms parms;

        private IncidentWorker worker;
    }
}
