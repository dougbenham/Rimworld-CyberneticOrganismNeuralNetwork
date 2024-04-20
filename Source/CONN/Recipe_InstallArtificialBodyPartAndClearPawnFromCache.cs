using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace CONN
{
	// Token: 0x02000016 RID: 22
	public class Recipe_InstallArtificialBodyPartAndClearPawnFromCache : Recipe_InstallArtificialBodyPart
	{
		// Token: 0x06000036 RID: 54 RVA: 0x00003340 File Offset: 0x00001540
		public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients, Bill bill)
		{
			base.ApplyOnPawn(pawn, part, billDoer, ingredients, bill);
			bool flag = HarmonyUtilities.pawnStats.ContainsKey(pawn);
			if (flag)
			{
				HarmonyUtilities.pawnStats.Remove(pawn);
			}
		}
	}
}
