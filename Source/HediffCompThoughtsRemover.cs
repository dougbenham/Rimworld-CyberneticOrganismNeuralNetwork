using Verse;

namespace CONN
{
	internal class HediffCompThoughtsRemover : HediffComp
	{
		public HediffCompProperties_ThoughtsRemover Props => (HediffCompProperties_ThoughtsRemover) props;

		public override void CompPostTick(ref float severityAdjustment)
		{
			if (Find.TickManager.TicksGame % 2500 == 0)
			{
				var need_Mood = Pawn.needs?.mood;
				if (need_Mood != null)
				{
					foreach (var t in Props.thoughtsToClear)
					{
						need_Mood.thoughts.memories.RemoveMemoriesOfDef(t);
					}
				}
			}

			base.CompPostTick(ref severityAdjustment);
		}
	}
}
