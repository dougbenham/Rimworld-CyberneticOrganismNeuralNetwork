using System;
using RimWorld;
using Verse;

namespace CONN
{
	// Token: 0x02000008 RID: 8
	internal class CompUsable_Neurotrainer : CompUsable
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002B34 File Offset: 0x00000D34
		protected new virtual string FloatMenuOptionLabel
		{
			get
			{
				return string.Format(base.Props.useLabel, this.skill.skillLabel);
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002B61 File Offset: 0x00000D61
		public override void PostExposeData()
		{
			base.PostExposeData();
			Scribe_Defs.Look<SkillDef>(ref this.skill, "skill");
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002B7C File Offset: 0x00000D7C
		public override void Initialize(CompProperties props)
		{
			base.Initialize(props);
			this.skill = DefDatabase<SkillDef>.GetNamed("Shooting", true);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002B98 File Offset: 0x00000D98
		public override string TransformLabel(string label)
		{
			return label;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002BAC File Offset: 0x00000DAC
		public override bool AllowStackWith(Thing other)
		{
			bool flag = !base.AllowStackWith(other);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				CompUsable_Neurotrainer compUsable_Neurotrainer = other.TryGetComp<CompUsable_Neurotrainer>();
				result = (compUsable_Neurotrainer != null && compUsable_Neurotrainer.skill == this.skill);
			}
			return result;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002BF4 File Offset: 0x00000DF4
		public override void PostSplitOff(Thing piece)
		{
			base.PostSplitOff(piece);
			CompUsable_Neurotrainer compUsable_Neurotrainer = piece.TryGetComp<CompUsable_Neurotrainer>();
			bool flag = compUsable_Neurotrainer != null;
			if (flag)
			{
				compUsable_Neurotrainer.skill = this.skill;
			}
		}

		// Token: 0x04000001 RID: 1
		public SkillDef skill;
	}
}
