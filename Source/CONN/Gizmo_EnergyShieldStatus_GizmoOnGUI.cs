using System;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace CONN
{
	// Token: 0x02000010 RID: 16
	[HarmonyPatch(typeof(Gizmo_EnergyShieldStatus))]
	[HarmonyPatch("GizmoOnGUI", 0)]
	public static class Gizmo_EnergyShieldStatus_GizmoOnGUI
	{
		// Token: 0x06000024 RID: 36 RVA: 0x00002E78 File Offset: 0x00001078
		[HarmonyPrefix]
		public static bool Prefix(Gizmo_EnergyShieldStatus __instance, ref GizmoResult __result, Vector2 topLeft, float maxWidth)
		{
			Pawn pawn = HarmonyUtilities.PawnOwner(__instance.shield);
			bool flag = pawn != null && HarmonyUtilities.pawnStats.ContainsKey(pawn);
			bool result;
			if (flag)
			{
				Rect rect = new Rect(topLeft.x, topLeft.y, __instance.GetWidth(maxWidth), 75f);
				Widgets.DrawWindowBackground(rect);
				Rect rect2 = rect.ContractedBy(6f);
				Rect rect3 = rect2;
				rect3.height = rect.height / 2f;
				Text.Font = GameFont.Tiny;
				Widgets.Label(rect3, __instance.shield.IsApparel ? __instance.shield.parent.LabelCap : "ShieldInbuilt".Translate().Resolve());
				Rect rect4 = rect2;
				rect4.yMin = rect2.y + rect2.height / 2f;
				float fillPercent = __instance.shield.Energy / Mathf.Max(1f, __instance.shield.parent.GetStatValue(StatDefOf.EnergyShieldEnergyMax, true, -1) * pawn.GetStatValue(DefOfs.CONN_ShieldMultiplier, true, -1));
				Widgets.FillableBar(rect4, fillPercent, HarmonyUtilities.FullShieldBarTex, HarmonyUtilities.EmptyShieldBarTex, false);
				Text.Font = GameFont.Small;
				Text.Anchor = TextAnchor.MiddleCenter;
				Widgets.Label(rect4, (__instance.shield.Energy * 100f).ToString("F0") + " / " + (__instance.shield.parent.GetStatValue(StatDefOf.EnergyShieldEnergyMax, true, -1) * 100f).ToString("F0"));
				Text.Anchor = TextAnchor.UpperLeft;
				TooltipHandler.TipRegion(rect2, "ShieldPersonalTip".Translate());
				__result = new GizmoResult(GizmoState.Clear);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}
	}
}
