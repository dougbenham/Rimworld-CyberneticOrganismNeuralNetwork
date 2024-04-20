using System;
using RimWorld;
using Verse;

namespace CONN
{
	// Token: 0x02000006 RID: 6
	public class CompUseEffect_PassionGiver : CompUseEffect
	{
		// Token: 0x0600000E RID: 14 RVA: 0x000027B0 File Offset: 0x000009B0
		public virtual bool CanBeUsedBy(Pawn p, out string failReason)
		{
			bool flag = !p.skills.skills.FindAll((SkillRecord s) => !s.TotallyDisabled && s.passion < Passion.Major).Any<SkillRecord>();
			bool result;
			if (flag)
			{
				failReason = "CONN.CantGetOtherPassion".Translate(p);
				result = false;
			}
			else
			{
				result = base.CanBeUsedBy(p, ref failReason);
			}
			return result;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002824 File Offset: 0x00000A24
		public override void DoEffect(Pawn user)
		{
			bool flag = user.skills.skills.FindAll((SkillRecord s) => !s.TotallyDisabled && s.passion == Passion.None).Any<SkillRecord>();
			if (flag)
			{
				SkillDef def = user.skills.skills.Find((SkillRecord s) => !s.TotallyDisabled && s.passion == Passion.None).def;
				bool @bool = Rand.Bool;
				if (@bool)
				{
					user.skills.GetSkill(def).passion = Passion.Minor;
					Messages.Message("CONN.GettingMinorPassion".Translate(user, def), user, MessageTypeDefOf.PositiveEvent, true);
				}
				else
				{
					user.skills.GetSkill(def).passion = Passion.Major;
					Messages.Message("CONN.GettingMajorPassion".Translate(user, def), user, MessageTypeDefOf.PositiveEvent, true);
				}
			}
			else
			{
				bool flag2 = user.skills.skills.FindAll((SkillRecord s) => !s.TotallyDisabled && s.passion == Passion.Minor).Any<SkillRecord>();
				if (flag2)
				{
					SkillDef def2 = user.skills.skills.Find((SkillRecord s) => !s.TotallyDisabled && s.passion == Passion.Minor).def;
					user.skills.GetSkill(def2).passion = Passion.Major;
					Messages.Message("CONN.GettingMajorPassion".Translate(user, def2), user, MessageTypeDefOf.PositiveEvent, true);
				}
			}
			this.parent.SplitOff(1).Destroy(DestroyMode.Vanish);
		}
	}
}
