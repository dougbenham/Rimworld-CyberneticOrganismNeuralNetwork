using System;
using System.Collections.Generic;
using HarmonyLib;
using Verse;

namespace CONN
{
	// Token: 0x0200000D RID: 13
	[HarmonyPatch(typeof(Pawn))]
	[HarmonyPatch("GetGizmos", 0)]
	public static class Pawn_GetGizmos
	{
		// Token: 0x06000021 RID: 33 RVA: 0x00002D97 File Offset: 0x00000F97
		[HarmonyPostfix]
		private static IEnumerable<Gizmo> Postfix(IEnumerable<Gizmo> list, Pawn __instance)
		{
			bool flag = __instance.AnimalOrWildMan() || !__instance.InMentalState;
			if (flag)
			{
				foreach (Gizmo gizmo in list)
				{
					yield return gizmo;
					gizmo = null;
				}
				IEnumerator<Gizmo> enumerator = null;
			}
			else
			{
				List<HediffGizmoBerserk> result = new List<HediffGizmoBerserk>();
				__instance.health.hediffSet.GetHediffs<HediffGizmoBerserk>(ref result, null);
				int num;
				for (int i = 0; i < result.Count; i = num + 1)
				{
					foreach (Gizmo gizmo2 in result[i].GetGizmos())
					{
						yield return gizmo2;
						gizmo2 = null;
					}
					IEnumerator<Gizmo> enumerator2 = null;
					num = i;
				}
				result = null;
			}
			yield break;
			yield break;
		}
	}
}
