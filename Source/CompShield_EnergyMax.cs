using HarmonyLib;
using RimWorld;
using Verse;

namespace CONN
{
	[HarmonyPatch(typeof(CompShield), "EnergyMax", MethodType.Getter)]
	public static class CompShield_EnergyMax
	{
		[HarmonyPostfix]
		public static void Postfix(CompShield __instance, ref float __result)
		{
			var pawn = HarmonyUtilities.PawnOwner(__instance);
			var flag = pawn != null && HarmonyUtilities.pawnStats.ContainsKey(pawn);
			if (flag)
			{
				__result *= HarmonyUtilities.pawnStats.TryGetValue(pawn)[0];
			}
		}
	}
}
