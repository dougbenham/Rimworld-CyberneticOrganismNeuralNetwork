using System.Collections.Generic;
using RimWorld;
using Verse;

namespace CONN
{
	public class CompUseEffect_ThoughClearer : CompUseEffect
	{
		public override void DoEffect(Pawn user)
		{
			var list = new List<Thought>();
			user.needs.mood.thoughts.GetAllMoodThoughts(list);
			foreach (var thought in list)
			{
				var flag = user.needs.mood != null;
				if (flag)
				{
					var flag2 = !thought.def.IsSituational;
					if (flag2)
					{
						user.needs.mood.thoughts.memories.RemoveMemoriesOfDef(thought.def);
					}
				}
			}
			parent.SplitOff(1).Destroy();
		}
	}
}
