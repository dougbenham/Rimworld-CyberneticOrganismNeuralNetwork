using System.Collections.Generic;
using RimWorld;
using Verse;

namespace CONN
{
	internal class HediffCompProperties_ThoughtsRemover : HediffCompProperties
	{
		public HediffCompProperties_ThoughtsRemover()
		{
			compClass = typeof(HediffCompThoughtsRemover);
		}

		public List<ThoughtDef> thoughtsToClear = new List<ThoughtDef>();
	}
}
