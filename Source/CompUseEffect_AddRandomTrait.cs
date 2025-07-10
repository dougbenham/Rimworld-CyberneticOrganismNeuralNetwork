using System.Linq;
using RimWorld;
using Verse;

namespace CONN
{
	public class CompUseEffect_AddRandomTrait : CompUseEffect
	{
		public override AcceptanceReport CanBeUsedBy(Pawn p)
		{
			if (p.story.traits.allTraits.Count >= CONNMod.settings.maxTraits)
				return "CONN.CantGetMoreTraits".Translate(p);

			return base.CanBeUsedBy(p);
		}

		public override void DoEffect(Pawn user)
		{
			var childhoodDisallowedTraits = user?.story?.Childhood?.disallowedTraits;
			var adulthoodDisallowedTraits = user?.story?.Adulthood?.disallowedTraits;
			var allTraits = user.story.traits.allTraits;
			var allDefsListForReading = DefDatabase<TraitDef>.AllDefsListForReading;
			var list = allDefsListForReading.Where(trait => (childhoodDisallowedTraits == null || !childhoodDisallowedTraits.Any(t => t.def == trait)) &&
			                                                (adulthoodDisallowedTraits == null || !adulthoodDisallowedTraits.Any(t => t.def == trait)) &&
			                                                (allTraits == null || (!allTraits.Any(t => t.def == trait) &&
			                                                                       !allTraits.Any(t => t.def.conflictingTraits.Contains(trait))))).ToList();
			var traitDef = list.RandomElement();
			user.story.traits.GainTrait(new(traitDef, PawnGenerator.RandomTraitDegree(traitDef)));
			RefreshPawnStat(user);
			parent.SplitOff(1).Destroy();
		}

		public static void RefreshPawnStat(Pawn pawn)
		{
			pawn.workSettings?.Notify_DisabledWorkTypesChanged();
			pawn.skills?.Notify_SkillDisablesChanged();
			if (!pawn.Dead && pawn.RaceProps.Humanlike)
				pawn.needs.mood?.thoughts.situational.Notify_SituationalThoughtsDirty();
		}
	}
}
