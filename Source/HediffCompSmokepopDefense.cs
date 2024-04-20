using RimWorld;
using UnityEngine;
using Verse;

namespace CONN
{
	internal class HediffCompSmokepopDefense : HediffComp
	{
		public HediffCompProperties_SmokepopDefense Props => (HediffCompProperties_SmokepopDefense) props;

		public override void CompExposeData()
		{
			base.CompExposeData();
			Scribe_Values.Look(ref lastUsedSmoke, "lastUsedSmoke", -99999);
			Scribe_Values.Look(ref Props.rechargeTime, "rechargeTime", 1);
			Scribe_Values.Look(ref Props.smokeRadius, "smokeRadius");
		}

		public override void CompPostMake()
		{
			Props.smokeRadius = Random.Range(Props.smokeRadius * 0.9f, Props.smokeRadius * 1.1f);
			Props.rechargeTime = Mathf.RoundToInt(Random.Range(Props.rechargeTime * 0.9f, Props.rechargeTime * 1.1f));
		}

		public bool TryTriggerSmokepopDefense(DamageInfo dinfo)
		{
			if (Find.TickManager.TicksGame > lastUsedSmoke + Props.rechargeTime * 60 &&
			    !dinfo.Def.isExplosive &&
			    dinfo.Def.harmsHealth &&
			    dinfo.Def.ExternalViolenceFor(Pawn) &&
			    dinfo.Weapon != null &&
			    dinfo.Weapon.IsRangedWeapon)
			{
				GenExplosion.DoExplosion(Pawn.Position, Pawn.Map, Props.smokeRadius, DamageDefOf.Smoke, null, -1, -1f, null, null, null, null, null, 0f, 1, GasType.BlindSmoke);
				lastUsedSmoke = Find.TickManager.TicksGame;
				return true;
			}

			return false;
		}

		private int lastUsedSmoke = -99999;
	}
}
