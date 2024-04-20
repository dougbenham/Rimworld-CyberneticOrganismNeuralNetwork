using System;
using Verse;

namespace CONN
{
	// Token: 0x02000012 RID: 18
	public class CompProperties_LightEffect : HediffCompProperties
	{
		// Token: 0x06000028 RID: 40 RVA: 0x00003110 File Offset: 0x00001310
		public CompProperties_LightEffect()
		{
			this.compClass = typeof(CompLightEffect);
		}

		// Token: 0x0400000B RID: 11
		public float size = 1f;

		// Token: 0x0400000C RID: 12
		public ThingDef visualMote;
	}
}
