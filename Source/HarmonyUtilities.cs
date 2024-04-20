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
			if (compShield.parent is Apparel apparel)
			{
				return apparel.Wearer;
			}

			return compShield.parent as Pawn;
		}

		public static readonly Texture2D FullShieldBarTex = SolidColorMaterials.NewSolidColorTexture(new Color(0.2f, 0.2f, 0.24f));

		public static readonly Texture2D EmptyShieldBarTex = SolidColorMaterials.NewSolidColorTexture(Color.clear);

		public static Dictionary<Pawn, float[]> pawnStats = new Dictionary<Pawn, float[]>();
	}
}
