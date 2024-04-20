using RimWorld;
using Verse;

namespace CONN
{
	internal class HediffCompThoughtsRemover : HediffComp
	{
		public HediffCompProperties_ThoughtsRemover Props => (HediffCompProperties_ThoughtsRemover)props;

		public override void CompPostTick(ref float severityAdjustment)
		{
			var flag = Find.TickManager.TicksGame % 2500 == 0;
			if (flag)
			{
				var needs = Pawn.needs;
				var need_Mood = (needs != null) ? needs.mood : null;
				var flag2 = need_Mood != null;
				if (flag2)
				{
					for (var i = 0; i < Props.thoughtsToClear.Count; i++)
					{
						need_Mood.thoughts.memories.RemoveMemoriesOfDef(Props.thoughtsToClear[i]);
					}
				}
			}
			base.CompPostTick(ref severityAdjustment);
		}
	}
}
