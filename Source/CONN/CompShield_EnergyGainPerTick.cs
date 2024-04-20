using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace CONN
{
	// Token: 0x0200000B RID: 11
	[HarmonyPatch(typeof(CompShield))]
	[HarmonyPatch("EnergyGainPerTick", 1)]
	public static class CompShield_EnergyGainPerTick
	{
		// Token: 0x0600001F RID: 31 RVA: 0x00002CF8 File Offset: 0x00000EF8
		[HarmonyPostfix]
		public static void Postfix(CompShield __instance, ref float __result)
		{
			Pawn pawn = HarmonyUtilities.PawnOwner(__instance);
			bool flag = pawn != null && !HarmonyUtilities.pawnStats.ContainsKey(pawn);
			if (flag)
			{
				__result *= pawn.GetStatValue(DefOfs.CONN_ShieldRechargeRateMultiplier, true, -1);
				HarmonyUtilities.CacheData(pawn);
			}
			else
			{
				__result *= GenCollection.TryGetValue<Pawn, float[]>(HarmonyUtilities.pawnStats, pawn, null)[1];
			}
		}
	}
}
