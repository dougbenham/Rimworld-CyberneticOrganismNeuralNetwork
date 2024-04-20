using RimWorld;
using RimWorld.Planet;
using Verse;

namespace CONN
{
	public class CompUseEffect_Reconditionner : CompUseEffect
	{
		public override void DoEffect(Pawn user)
		{
			var pawn = PawnGenerator.GeneratePawn(new(PawnKindDefOf.Colonist, Faction.OfPlayer, PawnGenerationContext.NonPlayer, -1, true, false, false, false));
			user.story.Childhood = pawn.story.Childhood;
			user.story.Adulthood = pawn.story.Adulthood;
			DiscardGeneratedPawn(pawn);
			RefreshPawnStat(user);
			parent.SplitOff(1).Destroy();
		}

		private void DiscardGeneratedPawn(Pawn pawn)
		{
			if (Find.WorldPawns.Contains(pawn))
				Find.WorldPawns.RemovePawn(pawn);
			Find.WorldPawns.PassToWorld(pawn, PawnDiscardDecideMode.Discard);
		}

		private void RefreshPawnStat(Pawn pawn)
		{
			pawn.workSettings?.Notify_DisabledWorkTypesChanged();
			pawn.skills?.Notify_SkillDisablesChanged();
			if (!pawn.Dead && pawn.RaceProps.Humanlike)
				pawn.needs.mood.thoughts.situational.Notify_SituationalThoughtsDirty();
		}
	}
}
