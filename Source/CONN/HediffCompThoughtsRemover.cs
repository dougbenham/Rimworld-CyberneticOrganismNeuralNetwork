using System;
using RimWorld;
using Verse;

namespace CONN
{
	// Token: 0x0200001E RID: 30
	internal class HediffCompThoughtsRemover : HediffComp
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000048 RID: 72 RVA: 0x0000384D File Offset: 0x00001A4D
		public HediffCompProperties_ThoughtsRemover Props
		{
			get
			{
				return (HediffCompProperties_ThoughtsRemover)this.props;
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000385C File Offset: 0x00001A5C
		public override void CompPostTick(ref float severityAdjustment)
		{
			bool flag = Find.TickManager.TicksGame % 2500 == 0;
			if (flag)
			{
				Pawn_NeedsTracker needs = base.Pawn.needs;
				Need_Mood need_Mood = (needs != null) ? needs.mood : null;
				bool flag2 = need_Mood != null;
				if (flag2)
				{
					for (int i = 0; i < this.Props.thoughtsToClear.Count; i++)
					{
						need_Mood.thoughts.memories.RemoveMemoriesOfDef(this.Props.thoughtsToClear[i]);
					}
				}
			}
			base.CompPostTick(ref severityAdjustment);
		}
	}
}
