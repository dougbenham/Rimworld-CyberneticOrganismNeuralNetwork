using RimWorld;
using Verse;

namespace CONN
{
	public class CompUseEffect_TraitReset : CompUseEffect
	{
		/// <inheritdoc />
		public override AcceptanceReport CanBeUsedBy(Pawn p)
		{
			if (p.story.traits.allTraits.Count == 0)
				return "CONN.NoPossibleTraitToRemove".Translate(p);

			if (p.story != null && p.story.Childhood?.disallowedTraits != null && p.story.traits.allTraits.FindAll(t => !p.story.Childhood.disallowedTraits.Any(te => te.def == t.def)).Any())
				return "CONN.NoPossibleTraitToRemove".Translate(p);

			if (p.story != null && p.story.Adulthood?.disallowedTraits != null && p.story.traits.allTraits.FindAll(t => !p.story.Adulthood.disallowedTraits.Any(te => te.def == t.def)).Any())
				return "CONN.NoPossibleTraitToRemove".Translate(p);

			return base.CanBeUsedBy(p);
		}

		public override void DoEffect(Pawn user)
		{
			user.story.traits.allTraits = new();

			var childTraits = user.story?.Childhood?.forcedTraits;
			if (childTraits != null)
			{
				foreach (var backstoryTrait in childTraits)
					user.story.traits.GainTrait(new(backstoryTrait.def, backstoryTrait.degree));
			}

			var adultTraits = user.story?.Adulthood?.forcedTraits;
			if (adultTraits != null)
			{
				foreach (var backstoryTrait in adultTraits)
					user.story.traits.GainTrait(new(backstoryTrait.def, backstoryTrait.degree));
			}

			CompUseEffect_AddRandomTrait.RefreshPawnStat(user);
			parent.SplitOff(1).Destroy();
		}
	}
}
