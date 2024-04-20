using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace CONN
{
	internal class HediffGizmoBerserk : HediffWithComps
	{
		public override IEnumerable<Gizmo> GetGizmos()
		{
			yield return new Command_Action
			{
				icon = ContentFinder<Texture2D>.Get("UI/Commands/Berserk"),
				defaultLabel = "CONN.BerserkLabel".Translate(),
				defaultDesc = "CONN.BerserkDesc".Translate(),
				action = delegate
				{
					var flag = !pawn.Dead && pawn.Faction == Faction.OfPlayer;
					if (flag)
					{
						var flag2 = pawn.MentalStateDef != MentalStateDefOf.Berserk;
						if (flag2)
						{
							pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Berserk, "Caused by the berserker chip", true);
						}
						else
						{
							pawn.mindState.mentalStateHandler.CurState.RecoverFromState();
							pawn.mindState.mentalStateHandler.Reset();
						}
					}
				},
				hotKey = KeyBindingDefOf.Misc3
			};
		}
	}
}
