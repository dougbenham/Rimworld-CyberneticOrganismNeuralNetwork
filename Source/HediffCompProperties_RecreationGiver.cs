using Verse;

namespace CONN
{
	internal class HediffCompProperties_RecreationGiver : HediffCompProperties
	{
		public HediffCompProperties_RecreationGiver()
		{
			compClass = typeof(HediffCompRecreationGiver);
		}

		public int eachNumberOfTicks = 10000;

		public float recreationToGive = 1f;
	}
}
