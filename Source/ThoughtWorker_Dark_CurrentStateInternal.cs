using HarmonyLib;
using RimWorld;
using Verse;

namespace CONN
{
	[HarmonyPatch(typeof(ThoughtWorker_Dark), "CurrentStateInternal")]
	public static class ThoughtWorker_Dark_CurrentStateInternal
	{
		public static void Postfix(Pawn p, ref ThoughtState __result)
		{
			if (p.health.hediffSet.HasHediff(DefOfs.CONN_hediff_FlashLight) || p.health.hediffSet.HasHediff(DefOfs.CONN_hediff_LaserDetection))
			{
				__result = false;
			}
		}
	}
}
