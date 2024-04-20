using HarmonyLib;
using RimWorld;
using Verse;

namespace CONN
{
	[HarmonyPatch(typeof(CompShield), "EnergyGainPerTick", MethodType.Getter)]
	public static class CompShield_EnergyGainPerTick
	{
		[HarmonyPostfix]
		public static void Postfix(CompShield __instance, ref float __result)
		{
			var pawn = HarmonyUtilities.PawnOwner(__instance);
			var flag = pawn != null && !HarmonyUtilities.pawnStats.ContainsKey(pawn);
			if (flag)
			{
				__result *= pawn.GetStatValue(DefOfs.CONN_ShieldRechargeRateMultiplier);
				HarmonyUtilities.CacheData(pawn);
			}
			else
			{
				__result *= HarmonyUtilities.pawnStats.TryGetValue(pawn)[1];
			}
		}
	}
}
