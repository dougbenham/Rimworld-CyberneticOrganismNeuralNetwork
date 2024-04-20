using System;
using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace CONN
{
	// Token: 0x0200000A RID: 10
	[StaticConstructorOnStartup]
	public static class HarmonyUtilities
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00002C3C File Offset: 0x00000E3C
		public static void CacheData(Pawn pawn)
		{
			HarmonyUtilities.pawnStats.Add(pawn, new float[]
			{
				pawn.GetStatValue(DefOfs.CONN_ShieldMultiplier, true, -1),
				pawn.GetStatValue(DefOfs.CONN_ShieldRechargeRateMultiplier, true, -1)
			});
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002C7C File Offset: 0x00000E7C
		public static Pawn PawnOwner(CompShield compShield)
		{
			Apparel apparel = compShield.parent as Apparel;
			bool flag = apparel != null;
			Pawn result;
			if (flag)
			{
				result = apparel.Wearer;
			}
			else
			{
				Pawn pawn = compShield.parent as Pawn;
				result = ((pawn != null) ? pawn : null);
			}
			return result;
		}

		// Token: 0x04000008 RID: 8
		public static readonly Texture2D FullShieldBarTex = SolidColorMaterials.NewSolidColorTexture(new Color(0.2f, 0.2f, 0.24f));

		// Token: 0x04000009 RID: 9
		public static readonly Texture2D EmptyShieldBarTex = SolidColorMaterials.NewSolidColorTexture(Color.clear);

		// Token: 0x0400000A RID: 10
		public static Dictionary<Pawn, float[]> pawnStats = new Dictionary<Pawn, float[]>();
	}
}
