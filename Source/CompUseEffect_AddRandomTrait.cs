using System.Collections.Generic;
using RimWorld;
using Verse;

namespace CONN
{
	public class CompUseEffect_AddRandomTrait : CompUseEffect
	{
		public override AcceptanceReport CanBeUsedBy(Pawn p)
		{
			if (p.story.traits.allTraits.Count >= CONNMod.settings.maxTraits)
			{
				return "CONN.CantGetMoreTraits".Translate(p);
			}

			return base.CanBeUsedBy(p);
		}

		public override void DoEffect(Pawn user)
		{
			var list = new List<TraitDef>();
			List<BackstoryTrait> list2;
			if (user == null)
			{
				list2 = null;
			}
			else
			{
				var story = user.story;
				if (story == null)
				{
					list2 = null;
				}
				else
				{
					var childhood = story.Childhood;
					list2 = ((childhood != null) ? childhood.disallowedTraits : null);
				}
			}
			var list3 = list2;
			List<BackstoryTrait> list4;
			if (user == null)
			{
				list4 = null;
			}
			else
			{
				var story2 = user.story;
				if (story2 == null)
				{
					list4 = null;
				}
				else
				{
					var adulthood = story2.Adulthood;
					list4 = ((adulthood != null) ? adulthood.disallowedTraits : null);
				}
			}
			var list5 = list4;
			var allTraits = user.story.traits.allTraits;
			var allDefsListForReading = DefDatabase<TraitDef>.AllDefsListForReading;
			for (var i = 0; i < allDefsListForReading.Count; i++)
			{
				var iTrait = allDefsListForReading[i];
				var flag = (list3 == null || !list3.Any(t => t.def == iTrait)) && (list5 == null || !list5.Any(t => t.def == iTrait)) && (allTraits == null || (!allTraits.Any(t => t.def == iTrait) && !allTraits.Any(t => t.def.conflictingTraits.Contains(iTrait))));
				if (flag)
				{
					list.Add(iTrait);
				}
			}
			var traitDef = list.RandomElement();
			user.story.traits.GainTrait(new Trait(traitDef, PawnGenerator.RandomTraitDegree(traitDef)));
			RefreshPawnStat(user);
			parent.SplitOff(1).Destroy();
		}

		public static void RefreshPawnStat(Pawn pawn)
		{
			var workSettings = pawn.workSettings;
			workSettings?.Notify_DisabledWorkTypesChanged();
			var skills = pawn.skills;
			skills?.Notify_SkillDisablesChanged();
			var flag = !pawn.Dead && pawn.RaceProps.Humanlike;
			if (flag)
			{
				pawn.needs.mood.thoughts.situational.Notify_SituationalThoughtsDirty();
			}
		}
	}
}
