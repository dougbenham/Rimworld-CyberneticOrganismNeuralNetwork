using System;
using RimWorld;
using UnityEngine;
using Verse;

namespace CONN
{
	// Token: 0x0200001C RID: 28
	internal class HediffCompSmokepopDefense : HediffComp
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00003610 File Offset: 0x00001810
		public HediffCompProperties_SmokepopDefense Props
		{
			get
			{
				return (HediffCompProperties_SmokepopDefense)this.props;
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003620 File Offset: 0x00001820
		public override void CompExposeData()
		{
			base.CompExposeData();
			Scribe_Values.Look<int>(ref this.lastUsedSmoke, "lastUsedSmoke", -99999, false);
			Scribe_Values.Look<int>(ref this.Props.rechargeTime, "rechargeTime", 1, false);
			Scribe_Values.Look<float>(ref this.Props.smokeRadius, "smokeRadius", 0f, false);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003680 File Offset: 0x00001880
		public override void CompPostMake()
		{
			this.Props.smokeRadius = UnityEngine.Random.Range(this.Props.smokeRadius * 0.9f, this.Props.smokeRadius * 1.1f);
			this.Props.rechargeTime = Mathf.RoundToInt(UnityEngine.Random.Range((float)this.Props.rechargeTime * 0.9f, (float)this.Props.rechargeTime * 1.1f));
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000036FC File Offset: 0x000018FC
		public bool TryTriggerSmokepopDefense(DamageInfo dinfo)
		{
			bool flag = Find.TickManager.TicksGame > this.lastUsedSmoke + this.Props.rechargeTime * 60;
			bool result;
			if (flag)
			{
				Pawn pawn = base.Pawn;
				bool flag2 = !dinfo.Def.isExplosive && dinfo.Def.harmsHealth && dinfo.Def.ExternalViolenceFor(pawn) && dinfo.Weapon != null && dinfo.Weapon.IsRangedWeapon;
				if (flag2)
				{
					GenExplosion.DoExplosion(pawn.Position, pawn.Map, this.Props.smokeRadius, DamageDefOf.Smoke, null, -1, -1f, null, null, null, null, null, 0f, 1, new GasType?(GasType.BlindSmoke), false, null, 0f, 1, 0f, false, null, null, null, true, 1f, 0f, true, null, 1f);
					this.lastUsedSmoke = Find.TickManager.TicksGame;
					result = true;
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x04000017 RID: 23
		private int lastUsedSmoke = -99999;
	}
}
