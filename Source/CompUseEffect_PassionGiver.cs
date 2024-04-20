using RimWorld;
using Verse;

namespace CONN
{
	public class CompUseEffect_PassionGiver : CompUseEffect
	{
		public override AcceptanceReport CanBeUsedBy(Pawn p)
		{
			if (!p.skills.skills.FindAll(s => !s.TotallyDisabled && s.passion < Passion.Major).Any())
			{
				return "CONN.CantGetOtherPassion".Translate(p);
			}

			return base.CanBeUsedBy(p);
		}

		public override void DoEffect(Pawn user)
		{
			if (user.skills.skills.FindAll(s => !s.TotallyDisabled && s.passion == Passion.None).Any())
			{
				var def = user.skills.skills.Find(s => !s.TotallyDisabled && s.passion == Passion.None).def;
				if (Rand.Bool)
				{
					user.skills.GetSkill(def).passion = Passion.Minor;
					Messages.Message("CONN.GettingMinorPassion".Translate(user, def), user, MessageTypeDefOf.PositiveEvent);
				}
				else
				{
					user.skills.GetSkill(def).passion = Passion.Major;
					Messages.Message("CONN.GettingMajorPassion".Translate(user, def), user, MessageTypeDefOf.PositiveEvent);
				}
			}
			else
			{
				if (user.skills.skills.FindAll(s => !s.TotallyDisabled && s.passion == Passion.Minor).Any())
				{
					var def2 = user.skills.skills.Find(s => !s.TotallyDisabled && s.passion == Passion.Minor).def;
					user.skills.GetSkill(def2).passion = Passion.Major;
					Messages.Message("CONN.GettingMajorPassion".Translate(user, def2), user, MessageTypeDefOf.PositiveEvent);
				}
			}
			parent.SplitOff(1).Destroy();
		}
	}
}
