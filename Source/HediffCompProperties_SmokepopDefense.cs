using Verse;

namespace CONN
{
	internal class HediffCompProperties_SmokepopDefense : HediffCompProperties
	{
		public HediffCompProperties_SmokepopDefense()
		{
			compClass = typeof(HediffCompSmokepopDefense);
		}

		public int rechargeTime = 1;

		public float smokeRadius = 3f;
	}
}
