using System.Collections.Generic;
using HarmonyLib;
using Verse;

namespace CONN
{
	[HarmonyPatch(typeof(Pawn), "GetGizmos")]
	public static class Pawn_GetGizmos
	{
		[HarmonyPostfix]
		private static IEnumerable<Gizmo> Postfix(IEnumerable<Gizmo> list, Pawn __instance)
		{
			if (__instance.AnimalOrWildMan() || !__instance.InMentalState)
			{
				foreach (var gizmo in list)
				{
					yield return gizmo;
				}
			}
			else
			{
				var result = new List<HediffGizmoBerserk>();
				__instance.health.hediffSet.GetHediffs(ref result);
				foreach (var t in result)
				{
					foreach (var g in t.GetGizmos())
					{
						yield return g;
					}
				}
			}
		}
	}
}
