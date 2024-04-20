using RimWorld;
using Verse;

namespace CONN
{
	public class CompUseEffect_LearnSkill : CompUseEffect
	{
		public override AcceptanceReport CanBeUsedBy(Pawn p)
		{
			if (p.skills.skills.FindAll(s => s.Level < 20).Count == 0)
			{
				return "CONN.NoSkillCanBeLearned".Translate(p);
			}

			return base.CanBeUsedBy(p);
		}

		public override void DoEffect(Pawn user)
		{
			foreach (var skillRecord in user.skills.skills)
			{
				var flag = skillRecord.Level < 20;
				if (flag)
				{
					skillRecord.Level += 2;
				}
			}
			Messages.Message("CONN.SkillsLearned".Translate(user), user, MessageTypeDefOf.PositiveEvent);
			parent.SplitOff(1).Destroy();
		}
	}
}
