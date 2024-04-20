using HarmonyLib;
using Verse;

namespace CONN
{
	[HarmonyPatch(typeof(Pawn_HealthTracker), "PreApplyDamage")]
	public static class Pawn_HealthTracker_PreApplyDamage
	{
		[HarmonyPostfix]
		private static void Pawn_HealthTracker_PreApplyDamagePostfix(Pawn_HealthTracker __instance, DamageInfo dinfo, Pawn ___pawn)
		{
			if (dinfo.Instigator != null && ___pawn != null)
			{
				foreach (var hd in ___pawn.health.hediffSet.hediffs)
				{
					var hediffCompSmokepopDefense = hd.TryGetComp<HediffCompSmokepopDefense>();
					if (hediffCompSmokepopDefense != null && hediffCompSmokepopDefense.TryTriggerSmokepopDefense(dinfo))
					{
						break;
					}
				}
			}
		}
	}
}
