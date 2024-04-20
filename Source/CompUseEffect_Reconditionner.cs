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
			var workSettings = pawn.workSettings;
			workSettings?.Notify_DisabledWorkTypesChanged();
			var skills = pawn.skills;
			skills?.Notify_SkillDisablesChanged();
			var flag = !pawn.Dead && pawn.RaceProps.Humanlike;
			if (flag)
			{
				pawn.needs.mood.thoughts.situational.Notify_SituationalThoughtsDirty();
			}
		}
	}
}
