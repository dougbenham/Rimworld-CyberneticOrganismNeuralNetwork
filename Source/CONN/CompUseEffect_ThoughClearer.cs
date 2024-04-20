using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace CONN
{
	// Token: 0x02000004 RID: 4
	public class CompUseEffect_ThoughClearer : CompUseEffect
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002548 File Offset: 0x00000748
		public override void DoEffect(Pawn user)
		{
			List<Thought> list = new List<Thought>();
			user.needs.mood.thoughts.GetAllMoodThoughts(list);
			foreach (Thought thought in list)
			{
				bool flag = user.needs.mood != null;
				if (flag)
				{
					bool flag2 = !thought.def.IsSituational;
					if (flag2)
					{
						user.needs.mood.thoughts.memories.RemoveMemoriesOfDef(thought.def);
					}
				}
			}
			this.parent.SplitOff(1).Destroy(DestroyMode.Vanish);
		}
	}
}
