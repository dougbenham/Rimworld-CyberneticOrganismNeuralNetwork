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
			if (pawn != null && HarmonyUtilities.pawnStats.ContainsKey(pawn))
			{
				__result *= HarmonyUtilities.pawnStats.TryGetValue(pawn)[0];
			}
		}
	}
}
