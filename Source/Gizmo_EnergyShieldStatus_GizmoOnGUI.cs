using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace CONN
{
	[HarmonyPatch(typeof(Gizmo_EnergyShieldStatus))]
	[HarmonyPatch("GizmoOnGUI", 0)]
	public static class Gizmo_EnergyShieldStatus_GizmoOnGUI
	{
		[HarmonyPrefix]
		public static bool Prefix(Gizmo_EnergyShieldStatus __instance, ref GizmoResult __result, Vector2 topLeft, float maxWidth)
		{
			var pawn = HarmonyUtilities.PawnOwner(__instance.shield);
			var flag = pawn != null && HarmonyUtilities.pawnStats.ContainsKey(pawn);
			bool result;
			if (flag)
			{
				var rect = new Rect(topLeft.x, topLeft.y, __instance.GetWidth(maxWidth), 75f);
				Widgets.DrawWindowBackground(rect);
				var rect2 = rect.ContractedBy(6f);
				var rect3 = rect2;
				rect3.height = rect.height / 2f;
				Text.Font = GameFont.Tiny;
				Widgets.Label(rect3, __instance.shield.IsApparel ? __instance.shield.parent.LabelCap : "ShieldInbuilt".Translate().Resolve());
				var rect4 = rect2;
				rect4.yMin = rect2.y + rect2.height / 2f;
				var fillPercent = __instance.shield.Energy / Mathf.Max(1f, __instance.shield.parent.GetStatValue(StatDefOf.EnergyShieldEnergyMax) * pawn.GetStatValue(DefOfs.CONN_ShieldMultiplier));
				Widgets.FillableBar(rect4, fillPercent, HarmonyUtilities.FullShieldBarTex, HarmonyUtilities.EmptyShieldBarTex, false);
				Text.Font = GameFont.Small;
				Text.Anchor = TextAnchor.MiddleCenter;
				Widgets.Label(rect4, (__instance.shield.Energy * 100f).ToString("F0") + " / " + (__instance.shield.parent.GetStatValue(StatDefOf.EnergyShieldEnergyMax) * 100f).ToString("F0"));
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
