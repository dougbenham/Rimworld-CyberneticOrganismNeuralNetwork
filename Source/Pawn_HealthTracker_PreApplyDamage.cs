using System.Collections.Generic;
using HarmonyLib;
using Verse;

namespace CONN
{
	[HarmonyPatch(typeof(Pawn_HealthTracker))]
	[HarmonyPatch("PreApplyDamage", 0)]
	public static class Pawn_HealthTracker_PreApplyDamage
	{
		[HarmonyPostfix]
		private static void Pawn_HealthTracker_PreApplyDamagePostfix(Pawn_HealthTracker __instance, DamageInfo dinfo, Pawn ___pawn)
		{
			var flag = dinfo.Instigator != null && ___pawn != null;
			if (flag)
			{
				var hediffs = ___pawn.health.hediffSet.hediffs;
				for (var i = 0; i < hediffs.Count; i++)
				{
					var hd = hediffs[i];
					var hediffCompSmokepopDefense = hd.TryGetComp<HediffCompSmokepopDefense>();
					var flag2 = hediffCompSmokepopDefense != null && hediffCompSmokepopDefense.TryTriggerSmokepopDefense(dinfo);
					if (flag2)
					{
						break;
					}
				}
			}
		}
	}
}
