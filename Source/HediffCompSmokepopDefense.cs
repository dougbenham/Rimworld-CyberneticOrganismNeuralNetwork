using RimWorld;
using UnityEngine;
using Verse;

namespace CONN
{
	internal class HediffCompSmokepopDefense : HediffComp
	{
		public HediffCompProperties_SmokepopDefense Props => (HediffCompProperties_SmokepopDefense)props;

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
			var flag = Find.TickManager.TicksGame > lastUsedSmoke + Props.rechargeTime * 60;
			bool result;
			if (flag)
			{
				var pawn = Pawn;
				var flag2 = !dinfo.Def.isExplosive && dinfo.Def.harmsHealth && dinfo.Def.ExternalViolenceFor(pawn) && dinfo.Weapon != null && dinfo.Weapon.IsRangedWeapon;
				if (flag2)
				{
					GenExplosion.DoExplosion(pawn.Position, pawn.Map, Props.smokeRadius, DamageDefOf.Smoke, null, -1, -1f, null, null, null, null, null, 0f, 1, GasType.BlindSmoke);
					lastUsedSmoke = Find.TickManager.TicksGame;
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

		private int lastUsedSmoke = -99999;
	}
}
