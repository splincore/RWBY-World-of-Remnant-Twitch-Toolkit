using RimWorld;
using RWBYRemnant;
using System.Collections.Generic;
using TwitchToolkit;
using TwitchToolkit.Store;
using Verse;

namespace RWBYTwitchToolkit
{
    public class UnlockSemblance : IncidentHelper
    {
        public override bool IsPossible()
        {
            Map map = Helper.AnyPlayerMap;
            if (map != null)
            {
                List<Pawn> possibleTargets = map.mapPawns.AllPawns.FindAll(p => p.IsColonistPlayerControlled && !p.health.hediffSet.HasHediff(RWBYDefOf.RWBY_AuraStolen) && p.story.traits.HasTrait(RWBYDefOf.RWBY_Aura));
                return possibleTargets.Count > 0;
            }
            return false;
        }

        public override void TryExecute()
        {
            Map map = Helper.AnyPlayerMap;
            if (map != null)
            {
                List<Pawn> possibleTargets = map.mapPawns.AllPawns.FindAll(p => p.IsColonistPlayerControlled && !p.health.hediffSet.HasHediff(RWBYDefOf.RWBY_AuraStolen) && p.story.traits.HasTrait(RWBYDefOf.RWBY_Aura));
                if (possibleTargets.RandomElement().TryGetComp<CompAbilityUserAura>() is CompAbilityUserAura compAbilityUserAura)
                {
                    compAbilityUserAura.TryUnlockSemblanceWith(null, true);
                }
            }
        }

        private IncidentParms parms;

        private IncidentWorker worker;
    }
}
