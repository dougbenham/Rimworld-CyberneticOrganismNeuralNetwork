using System;
using RimWorld;
using Verse;

namespace CONN
{
	// Token: 0x02000007 RID: 7
	public class CompUseEffect_LearnSkill : CompUseEffect
	{
		// Token: 0x06000011 RID: 17 RVA: 0x00002A04 File Offset: 0x00000C04
		public virtual bool CanBeUsedBy(Pawn p, out string failReason)
		{
			bool flag = p.skills.skills.FindAll((SkillRecord s) => s.Level < 20).Count == 0;
			bool result;
			if (flag)
			{
				failReason = "CONN.NoSkillCanBeLearned".Translate(p);
				result = false;
			}
			else
			{
				result = base.CanBeUsedBy(p, ref failReason);
			}
			return result;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002A78 File Offset: 0x00000C78
		public override void DoEffect(Pawn user)
		{
			foreach (SkillRecord skillRecord in user.skills.skills)
			{
				bool flag = skillRecord.Level < 20;
				if (flag)
				{
					skillRecord.Level += 2;
				}
			}
			Messages.Message("CONN.SkillsLearned".Translate(user), user, MessageTypeDefOf.PositiveEvent, true);
			this.parent.SplitOff(1).Destroy(DestroyMode.Vanish);
		}
	}
}
