using Verse;

namespace CONN
{
	public class CompProperties_LightEffect : HediffCompProperties
	{
		public CompProperties_LightEffect()
		{
			compClass = typeof(CompLightEffect);
		}

		public float size = 1f;

		public ThingDef visualMote;
	}
}
