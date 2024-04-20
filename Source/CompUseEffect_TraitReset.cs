using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace CONN
{
	// Token: 0x02000003 RID: 3
	public class CompUseEffect_TraitReset : CompUseEffect
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002298 File Offset: 0x00000498
		public virtual bool CanBeUsedBy(Pawn p, out string failReason)
		{
			bool flag = p.story.traits.allTraits.Count == 0;
			bool result;
			if (flag)
			{
				failReason = "CONN.NoPossibleTraitToRemove".Translate(p);
				result = false;
			}
			else
			{
				Pawn p2 = p;
				bool flag2;
				if (p2 == null)
				{
					flag2 = (null != null);
				}
				else
				{
					Pawn_StoryTracker story = p2.story;
					if (story == null)
					{
						flag2 = (null != null);
					}
					else
					{
						BackstoryDef childhood = story.Childhood;
						flag2 = (((childhood != null) ? childhood.disallowedTraits : null) != null);
					}
				}
				bool flag3 = flag2 && p.story.traits.allTraits.FindAll((Trait t) => !p.story.Childhood.disallowedTraits.Any((BackstoryTrait te) => te.def == t.def)).Any<Trait>();
				if (flag3)
				{
					failReason = "CONN.NoPossibleTraitToRemove".Translate(p);
					result = false;
				}
				else
				{
					Pawn p3 = p;
					bool flag4;
					if (p3 == null)
					{
						flag4 = (null != null);
					}
					else
					{
						Pawn_StoryTracker story2 = p3.story;
						if (story2 == null)
						{
							flag4 = (null != null);
						}
						else
						{
							BackstoryDef adulthood = story2.Adulthood;
							flag4 = (((adulthood != null) ? adulthood.disallowedTraits : null) != null);
						}
					}
					bool flag5 = flag4 && p.story.traits.allTraits.FindAll((Trait t) => !p.story.Adulthood.disallowedTraits.Any((BackstoryTrait te) => te.def == t.def)).Any<Trait>();
					if (flag5)
					{
						failReason = "CONN.NoPossibleTraitToRemove".Translate(p);
						result = false;
					}
					else
					{
						result = base.CanBeUsedBy(p, ref failReason);
					}
				}
			}
			return result;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000240C File Offset: 0x0000060C
		public override void DoEffect(Pawn user)
		{
			user.story.traits.allTraits = new List<Trait>();
			List<BackstoryTrait> list;
			if (user == null)
			{
				list = null;
			}
			else
			{
				Pawn_StoryTracker story = user.story;
				if (story == null)
				{
					list = null;
				}
				else
				{
					BackstoryDef childhood = story.Childhood;
					list = ((childhood != null) ? childhood.forcedTraits : null);
				}
			}
			List<BackstoryTrait> list2 = list;
			bool flag = list2 != null;
			if (flag)
			{
				for (int i = 0; i < list2.Count; i++)
				{
					BackstoryTrait backstoryTrait = list2[i];
					user.story.traits.GainTrait(new Trait(backstoryTrait.def, backstoryTrait.degree, false), false);
				}
			}
			List<BackstoryTrait> list3;
			if (user == null)
			{
				list3 = null;
			}
			else
			{
				Pawn_StoryTracker story2 = user.story;
				if (story2 == null)
				{
					list3 = null;
				}
				else
				{
					BackstoryDef adulthood = story2.Adulthood;
					list3 = ((adulthood != null) ? adulthood.forcedTraits : null);
				}
			}
			List<BackstoryTrait> list4 = list3;
			bool flag2 = list4 != null;
			if (flag2)
			{
				for (int j = 0; j < list4.Count; j++)
				{
					BackstoryTrait backstoryTrait2 = list4[j];
					user.story.traits.GainTrait(new Trait(backstoryTrait2.def, backstoryTrait2.degree, false), false);
				}
			}
			CompUseEffect_AddRandomTrait.RefreshPawnStat(user);
			this.parent.SplitOff(1).Destroy(DestroyMode.Vanish);
		}
	}
}
