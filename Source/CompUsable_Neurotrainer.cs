using RimWorld;
using Verse;

namespace CONN
{
	internal class CompUsable_Neurotrainer : CompUsable
	{
		protected new virtual string FloatMenuOptionLabel => string.Format(Props.useLabel, skill.skillLabel);
		
		public override void PostExposeData()
		{
			base.PostExposeData();
			Scribe_Defs.Look(ref skill, "skill");
		}

		public override void Initialize(CompProperties props)
		{
			base.Initialize(props);
			skill = DefDatabase<SkillDef>.GetNamed("Shooting");
		}

		public override string TransformLabel(string label)
		{
			return label;
		}

		public override bool AllowStackWith(Thing other)
		{
			if (base.AllowStackWith(other))
			{
				var compUsable_Neurotrainer = other.TryGetComp<CompUsable_Neurotrainer>();
				return compUsable_Neurotrainer != null && compUsable_Neurotrainer.skill == skill;
			}

			return false;
		}

		public override void PostSplitOff(Thing piece)
		{
			base.PostSplitOff(piece);
			var compUsable_Neurotrainer = piece.TryGetComp<CompUsable_Neurotrainer>();
			if (compUsable_Neurotrainer != null)
			{
				compUsable_Neurotrainer.skill = skill;
			}
		}

		public SkillDef skill;
	}
}
