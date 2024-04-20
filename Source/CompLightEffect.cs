using RimWorld;
using UnityEngine;
using Verse;

namespace CONN
{
	public class CompLightEffect : HediffComp
	{
		public CompProperties_LightEffect Props => (CompProperties_LightEffect) props;

		public override void CompPostTick(ref float severityAdjustment)
		{
			if (CONNMod.settings.enableMote)
			{
				if (CONNMod.settings.enableMoteDraft && !Pawn.Drafted)
					ClearMote();
				else
				{
					if (Pawn != null && Pawn.Spawned && !Pawn.Dead && !Pawn.InBed())
						CreateOrMoveMote(Pawn.TrueCenter());
					else
						ClearMote();
				}
			}
			else
				ClearMote();
		}

		public void CreateOrMoveMote(Vector3 pawnPos)
		{
			if (mote == null)
			{
				mote = (MoteFlashLight) ThingMaker.MakeThing(Props.visualMote);
				mote.Scale = 1.9f * Props.size;
				mote.exactPosition = pawnPos;
				GenSpawn.Spawn(mote, pawnPos.ToIntVec3(), Pawn.Map);
			}
			else
				mote.exactPosition = pawnPos;
		}

		/// <inheritdoc />
		public override void Notify_PawnDied(DamageInfo? dinfo, Hediff culprit = null)
		{
			mote?.DeSpawn();
		}

		public override void Notify_PawnKilled()
		{
			mote?.DeSpawn();
		}

		public override void CompPostPostRemoved()
		{
			mote?.DeSpawn();
		}

		private void ClearMote()
		{
			if (mote != null && mote.Spawned)
			{
				mote.DeSpawn();
			}
			mote = null;
		}

		private MoteFlashLight mote;
	}
}
