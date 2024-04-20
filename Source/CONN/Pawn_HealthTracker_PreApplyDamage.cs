using System;
using System.Collections.Generic;
using HarmonyLib;
using Verse;

namespace CONN
{
	// Token: 0x0200000E RID: 14
	[HarmonyPatch(typeof(Pawn_HealthTracker))]
	[HarmonyPatch("PreApplyDamage", 0)]
	public static class Pawn_HealthTracker_PreApplyDamage
	{
		// Token: 0x06000022 RID: 34 RVA: 0x00002DB0 File Offset: 0x00000FB0
		[HarmonyPostfix]
		private static void Pawn_HealthTracker_PreApplyDamagePostfix(Pawn_HealthTracker __instance, DamageInfo dinfo, Pawn ___pawn)
		{
			bool flag = dinfo.Instigator != null && ___pawn != null;
			if (flag)
			{
				List<Hediff> hediffs = ___pawn.health.hediffSet.hediffs;
				for (int i = 0; i < hediffs.Count; i++)
				{
					Hediff hd = hediffs[i];
					HediffCompSmokepopDefense hediffCompSmokepopDefense = hd.TryGetComp<HediffCompSmokepopDefense>();
					bool flag2 = hediffCompSmokepopDefense != null && hediffCompSmokepopDefense.TryTriggerSmokepopDefense(dinfo);
					if (flag2)
					{
						break;
					}
				}
			}
		}
	}
}
