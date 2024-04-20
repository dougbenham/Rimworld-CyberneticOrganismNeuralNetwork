using System;
using Verse;

namespace CONN
{
	// Token: 0x02000017 RID: 23
	internal class HediffCompProperties_RecreationGiver : HediffCompProperties
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00003382 File Offset: 0x00001582
		public HediffCompProperties_RecreationGiver()
		{
			this.compClass = typeof(HediffCompRecreationGiver);
		}

		// Token: 0x0400000E RID: 14
		public int eachNumberOfTicks = 10000;

		// Token: 0x0400000F RID: 15
		public float recreationToGive = 1f;
	}
}
