using System.Collections.Generic;
using RimWorld;
using Verse;

namespace CONN
{
	public class Recipe_InstallArtificialBodyPartAndClearPawnFromCache : Recipe_InstallArtificialBodyPart
	{
		public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients, Bill bill)
		{
			base.ApplyOnPawn(pawn, part, billDoer, ingredients, bill);
			var flag = HarmonyUtilities.pawnStats.ContainsKey(pawn);
			if (flag)
			{
				HarmonyUtilities.pawnStats.Remove(pawn);
			}
		}
	}
}
