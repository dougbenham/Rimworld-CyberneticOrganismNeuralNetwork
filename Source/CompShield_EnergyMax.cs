using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace CONN
{
	// Token: 0x0200000C RID: 12
	[HarmonyPatch(typeof(CompShield))]
	[HarmonyPatch("EnergyMax", 1)]
	public static class CompShield_EnergyMax
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00002D58 File Offset: 0x00000F58
		[HarmonyPostfix]
		public static void Postfix(CompShield __instance, ref float __result)
		{
			Pawn pawn = HarmonyUtilities.PawnOwner(__instance);
			bool flag = pawn != null && HarmonyUtilities.pawnStats.ContainsKey(pawn);
			if (flag)
			{
				__result *= GenCollection.TryGetValue<Pawn, float[]>(HarmonyUtilities.pawnStats, pawn, null)[0];
			}
		}
	}
}
