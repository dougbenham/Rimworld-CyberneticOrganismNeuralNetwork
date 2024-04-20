using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace CONN
{
	[StaticConstructorOnStartup]
	public static class HarmonyUtilities
	{
		public static void CacheData(Pawn pawn)
		{
			pawnStats.Add(pawn, new[]
			{
				pawn.GetStatValue(DefOfs.CONN_ShieldMultiplier),
				pawn.GetStatValue(DefOfs.CONN_ShieldRechargeRateMultiplier)
			});
		}

		public static Pawn PawnOwner(CompShield compShield)
		{
			var apparel = compShield.parent as Apparel;
			var flag = apparel != null;
			Pawn result;
			if (flag)
			{
				result = apparel.Wearer;
			}
			else
			{
				var pawn = compShield.parent as Pawn;
				result = ((pawn != null) ? pawn : null);
			}
			return result;
		}

		public static readonly Texture2D FullShieldBarTex = SolidColorMaterials.NewSolidColorTexture(new Color(0.2f, 0.2f, 0.24f));

		public static readonly Texture2D EmptyShieldBarTex = SolidColorMaterials.NewSolidColorTexture(Color.clear);

		public static Dictionary<Pawn, float[]> pawnStats = new Dictionary<Pawn, float[]>();
	}
}
