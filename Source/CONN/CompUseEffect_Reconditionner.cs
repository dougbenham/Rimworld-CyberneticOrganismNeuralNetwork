using System;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace CONN
{
	// Token: 0x02000005 RID: 5
	public class CompUseEffect_Reconditionner : CompUseEffect
	{
		// Token: 0x0600000A RID: 10 RVA: 0x0000261C File Offset: 0x0000081C
		public override void DoEffect(Pawn user)
		{
			Pawn pawn = PawnGenerator.GeneratePawn(new PawnGenerationRequest(PawnKindDefOf.Colonist, Faction.OfPlayer, PawnGenerationContext.NonPlayer, -1, true, false, false, false, false, 1f, false, true, false, true, true, false, false, false, false, 0f, 0f, null, 1f, null, null, null, null, null, null, null, null, null, null, null, null, false, false, false, false, null, null, null, null, null, 0f, DevelopmentalStage.Adult, null, null, null, false));
			user.story.Childhood = pawn.story.Childhood;
			user.story.Adulthood = pawn.story.Adulthood;
			this.DiscardGeneratedPawn(pawn);
			this.RefreshPawnStat(user);
			this.parent.SplitOff(1).Destroy(DestroyMode.Vanish);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002704 File Offset: 0x00000904
		private void DiscardGeneratedPawn(Pawn pawn)
		{
			bool flag = Find.WorldPawns.Contains(pawn);
			if (flag)
			{
				Find.WorldPawns.RemovePawn(pawn);
			}
			Find.WorldPawns.PassToWorld(pawn, PawnDiscardDecideMode.Discard);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000273C File Offset: 0x0000093C
		private void RefreshPawnStat(Pawn pawn)
		{
			Pawn_WorkSettings workSettings = pawn.workSettings;
			if (workSettings != null)
			{
				workSettings.Notify_DisabledWorkTypesChanged();
			}
			Pawn_SkillTracker skills = pawn.skills;
			if (skills != null)
			{
				skills.Notify_SkillDisablesChanged();
			}
			bool flag = !pawn.Dead && pawn.RaceProps.Humanlike;
			if (flag)
			{
				pawn.needs.mood.thoughts.situational.Notify_SituationalThoughtsDirty();
			}
		}
	}
}
