using Verse;

namespace CONN
{
	internal class HediffCompRecreationGiver : HediffComp
	{
		public HediffCompProperties_RecreationGiver Props => (HediffCompProperties_RecreationGiver)props;

		public override void CompPostTick(ref float severityAdjustment)
		{
			var flag = Find.TickManager.TicksGame % Props.eachNumberOfTicks == 0;
			if (flag)
			{
				var @bool = Rand.Bool;
				if (@bool)
				{
					Pawn.needs.joy.GainJoy(Props.recreationToGive, DefOfs.Gaming_Cerebral);
				}
				else
				{
					Pawn.needs.joy.GainJoy(Props.recreationToGive, DefOfs.Television);
				}
			}
			base.CompPostTick(ref severityAdjustment);
		}
	}
}
