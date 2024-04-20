using HarmonyLib;
using RimWorld;
using Verse;

namespace CONN
{
	[HarmonyPatch(typeof(ThoughtWorker_Dark))]
	[HarmonyPatch("CurrentStateInternal", 0)]
	public static class ThoughtWorker_Dark_CurrentStateInternal
	{
		public static void Postfix(Pawn p, ref ThoughtState __result)
		{
			var flag = p.health.hediffSet.HasHediff(DefOfs.CONN_hediff_FlashLight) || p.health.hediffSet.HasHediff(DefOfs.CONN_hediff_LaserDetection);
			if (flag)
			{
				__result = false;
			}
		}
	}
}
