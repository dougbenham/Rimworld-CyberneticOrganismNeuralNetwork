using System;
using Verse;

namespace CONN
{
	// Token: 0x0200001B RID: 27
	internal class HediffCompProperties_SmokepopDefense : HediffCompProperties
	{
		// Token: 0x06000041 RID: 65 RVA: 0x000035E4 File Offset: 0x000017E4
		public HediffCompProperties_SmokepopDefense()
		{
			this.compClass = typeof(HediffCompSmokepopDefense);
		}

		// Token: 0x04000015 RID: 21
		public int rechargeTime = 1;

		// Token: 0x04000016 RID: 22
		public float smokeRadius = 3f;
	}
}
