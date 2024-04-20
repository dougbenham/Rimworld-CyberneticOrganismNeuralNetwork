using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace CONN
{
	// Token: 0x0200000F RID: 15
	[HarmonyPatch(typeof(ThoughtWorker_Dark))]
	[HarmonyPatch("CurrentStateInternal", 0)]
	public static class ThoughtWorker_Dark_CurrentStateInternal
	{
		// Token: 0x06000023 RID: 35 RVA: 0x00002E28 File Offset: 0x00001028
		public static void Postfix(Pawn p, ref ThoughtState __result)
		{
			bool flag = p.health.hediffSet.HasHediff(DefOfs.CONN_hediff_FlashLight, false) || p.health.hediffSet.HasHediff(DefOfs.CONN_hediff_LaserDetection, false);
			if (flag)
			{
				__result = false;
			}
		}
	}
}
