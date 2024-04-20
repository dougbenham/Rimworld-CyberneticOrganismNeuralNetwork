using System;
using RimWorld;
using UnityEngine;
using Verse;

namespace CONN
{
	// Token: 0x02000013 RID: 19
	public class CompLightEffect : HediffComp
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00003134 File Offset: 0x00001334
		public CompProperties_LightEffect Props
		{
			get
			{
				return (CompProperties_LightEffect)this.props;
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003154 File Offset: 0x00001354
		public override void CompPostTick(ref float severityAdjustment)
		{
			bool enableMote = CONNMod.settings.enableMote;
			if (enableMote)
			{
				Pawn pawn = base.Pawn;
				bool flag = CONNMod.settings.enableMoteDraft && !pawn.Drafted;
				if (flag)
				{
					this.ClearMote();
				}
				else
				{
					bool flag2 = pawn != null && pawn.Spawned && !pawn.Dead && !pawn.InBed();
					if (flag2)
					{
						this.CreateOrMoveMote(pawn.TrueCenter());
					}
					else
					{
						this.ClearMote();
					}
				}
			}
			else
			{
				this.ClearMote();
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000031E8 File Offset: 0x000013E8
		public void CreateOrMoveMote(Vector3 pawnPos)
		{
			bool flag = this.mote == null;
			if (flag)
			{
				this.mote = (MoteFlashLight)ThingMaker.MakeThing(this.Props.visualMote, null);
				this.mote.Scale = 1.9f * this.Props.size;
				this.mote.exactPosition = pawnPos;
				GenSpawn.Spawn(this.mote, pawnPos.ToIntVec3(), base.Pawn.Map, WipeMode.Vanish);
			}
			else
			{
				this.mote.exactPosition = pawnPos;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003278 File Offset: 0x00001478
		public virtual void Notify_PawnDied()
		{
			MoteFlashLight moteFlashLight = this.mote;
			if (moteFlashLight != null)
			{
				moteFlashLight.DeSpawn(DestroyMode.Vanish);
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000328D File Offset: 0x0000148D
		public override void Notify_PawnKilled()
		{
			MoteFlashLight moteFlashLight = this.mote;
			if (moteFlashLight != null)
			{
				moteFlashLight.DeSpawn(DestroyMode.Vanish);
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000032A2 File Offset: 0x000014A2
		public override void CompPostPostRemoved()
		{
			MoteFlashLight moteFlashLight = this.mote;
			if (moteFlashLight != null)
			{
				moteFlashLight.DeSpawn(DestroyMode.Vanish);
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000032B8 File Offset: 0x000014B8
		private void ClearMote()
		{
			bool flag = this.mote != null && this.mote.Spawned;
			if (flag)
			{
				this.mote.DeSpawn(DestroyMode.Vanish);
			}
			this.mote = null;
		}

		// Token: 0x0400000D RID: 13
		private MoteFlashLight mote;
	}
}
