using RimWorld;
using Verse;

namespace CONN
{
	public class CompUseEffect_PassionGiver : CompUseEffect
	{
		public override AcceptanceReport CanBeUsedBy(Pawn p)
		{
			if (!p.skills.skills.FindAll(s => !s.TotallyDisabled && s.passion < Passion.Major).Any())
				return "CONN.CantGetOtherPassion".Translate(p);

			return base.CanBeUsedBy(p);
		}

		public override void DoEffect(Pawn user)
		{
			var skill = user.skills.skills.FirstOrDefault(s => !s.TotallyDisabled && s.passion == Passion.None);
			if (skill != null)
			{
				if (Rand.Bool)
				{
					skill.passion = Passion.Minor;
					Messages.Message("CONN.GettingMinorPassion".Translate(user, skill.def), user, MessageTypeDefOf.PositiveEvent);
				}
				else
				{
					skill.passion = Passion.Major;
					Messages.Message("CONN.GettingMajorPassion".Translate(user, skill.def), user, MessageTypeDefOf.PositiveEvent);
				}
			}
			else
			{
				skill = user.skills.skills.FirstOrDefault(s => !s.TotallyDisabled && s.passion == Passion.Minor);
				if (skill != null)
				{
					skill.passion = Passion.Major;
					Messages.Message("CONN.GettingMajorPassion".Translate(user, skill.def), user, MessageTypeDefOf.PositiveEvent);
				}
			}
			parent.SplitOff(1).Destroy();
		}
	}
}
