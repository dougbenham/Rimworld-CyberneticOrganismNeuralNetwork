using RimWorld;
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
				if (Pawn.needs.mood != null)
				{
					foreach (var t in Props.thoughtsToClear)
					{
						Pawn.needs.mood.thoughts.memories.RemoveMemoriesOfDef(t);
					}
				}
			}

			base.CompPostTick(ref severityAdjustment);
		}
	}
}
