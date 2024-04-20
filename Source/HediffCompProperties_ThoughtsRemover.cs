using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace CONN
{
	// Token: 0x0200001D RID: 29
	internal class HediffCompProperties_ThoughtsRemover : HediffCompProperties
	{
		// Token: 0x06000047 RID: 71 RVA: 0x00003828 File Offset: 0x00001A28
		public HediffCompProperties_ThoughtsRemover()
		{
			this.compClass = typeof(HediffCompThoughtsRemover);
		}

		// Token: 0x04000018 RID: 24
		public List<ThoughtDef> thoughtsToClear = new List<ThoughtDef>();
	}
}
