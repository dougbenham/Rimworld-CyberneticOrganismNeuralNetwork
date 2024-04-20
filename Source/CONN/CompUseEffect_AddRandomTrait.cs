using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace CONN
{
	// Token: 0x02000002 RID: 2
	public class CompUseEffect_AddRandomTrait : CompUseEffect
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public virtual bool CanBeUsedBy(Pawn p, out string failReason)
		{
			bool flag = p.story.traits.allTraits.Count >= CONNMod.settings.maxTraits;
			bool result;
			if (flag)
			{
				failReason = "CONN.CantGetMoreTraits".Translate(p);
				result = false;
			}
			else
			{
				result = base.CanBeUsedBy(p, ref failReason);
			}
			return result;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020B0 File Offset: 0x000002B0
		public override void DoEffect(Pawn user)
		{
			List<TraitDef> list = new List<TraitDef>();
			List<BackstoryTrait> list2;
			if (user == null)
			{
				list2 = null;
			}
			else
			{
				Pawn_StoryTracker story = user.story;
				if (story == null)
				{
					list2 = null;
				}
				else
				{
					BackstoryDef childhood = story.Childhood;
					list2 = ((childhood != null) ? childhood.disallowedTraits : null);
				}
			}
			List<BackstoryTrait> list3 = list2;
			List<BackstoryTrait> list4;
			if (user == null)
			{
				list4 = null;
			}
			else
			{
				Pawn_StoryTracker story2 = user.story;
				if (story2 == null)
				{
					list4 = null;
				}
				else
				{
					BackstoryDef adulthood = story2.Adulthood;
					list4 = ((adulthood != null) ? adulthood.disallowedTraits : null);
				}
			}
			List<BackstoryTrait> list5 = list4;
			List<Trait> allTraits = user.story.traits.allTraits;
			List<TraitDef> allDefsListForReading = DefDatabase<TraitDef>.AllDefsListForReading;
			for (int i = 0; i < allDefsListForReading.Count; i++)
			{
				TraitDef iTrait = allDefsListForReading[i];
				bool flag = (list3 == null || !list3.Any((BackstoryTrait t) => t.def == iTrait)) && (list5 == null || !list5.Any((BackstoryTrait t) => t.def == iTrait)) && (allTraits == null || (!allTraits.Any((Trait t) => t.def == iTrait) && !allTraits.Any((Trait t) => t.def.conflictingTraits.Contains(iTrait))));
				if (flag)
				{
					list.Add(iTrait);
				}
			}
			TraitDef traitDef = list.RandomElement<TraitDef>();
			user.story.traits.GainTrait(new Trait(traitDef, PawnGenerator.RandomTraitDegree(traitDef), false), false);
			CompUseEffect_AddRandomTrait.RefreshPawnStat(user);
			this.parent.SplitOff(1).Destroy(DestroyMode.Vanish);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002224 File Offset: 0x00000424
		public static void RefreshPawnStat(Pawn pawn)
		{
			Pawn_WorkSettings workSettings = pawn.workSettings;
			if (workSettings != null)
			{
				workSettings.Notify_DisabledWorkTypesChanged();
			}
			Pawn_SkillTracker skills = pawn.skills;
			if (skills != null)
			{
				skills.Notify_SkillDisablesChanged();
			}
			bool flag = !pawn.Dead && pawn.RaceProps.Humanlike;
			if (flag)
			{
				pawn.needs.mood.thoughts.situational.Notify_SituationalThoughtsDirty();
			}
		}
	}
}
