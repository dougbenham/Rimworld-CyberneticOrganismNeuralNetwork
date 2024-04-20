using System;
using Verse;

namespace CONN
{
	// Token: 0x02000018 RID: 24
	internal class HediffCompRecreationGiver : HediffComp
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000033B1 File Offset: 0x000015B1
		public HediffCompProperties_RecreationGiver Props
		{
			get
			{
				return (HediffCompProperties_RecreationGiver)this.props;
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000033C0 File Offset: 0x000015C0
		public override void CompPostTick(ref float severityAdjustment)
		{
			bool flag = Find.TickManager.TicksGame % this.Props.eachNumberOfTicks == 0;
			if (flag)
			{
				bool @bool = Rand.Bool;
				if (@bool)
				{
					base.Pawn.needs.joy.GainJoy(this.Props.recreationToGive, DefOfs.Gaming_Cerebral);
				}
				else
				{
					base.Pawn.needs.joy.GainJoy(this.Props.recreationToGive, DefOfs.Television);
				}
			}
			base.CompPostTick(ref severityAdjustment);
		}
	}
}
