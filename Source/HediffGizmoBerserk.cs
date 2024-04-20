using System;
using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace CONN
{
	// Token: 0x02000011 RID: 17
	internal class HediffGizmoBerserk : HediffWithComps
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00003048 File Offset: 0x00001248
		public override IEnumerable<Gizmo> GetGizmos()
		{
			yield return new Command_Action
			{
				icon = ContentFinder<Texture2D>.Get("UI/Commands/Berserk", true),
				defaultLabel = "CONN.BerserkLabel".Translate(),
				defaultDesc = "CONN.BerserkDesc".Translate(),
				action = delegate()
				{
					bool flag = !this.pawn.Dead && this.pawn.Faction == Faction.OfPlayer;
					if (flag)
					{
						bool flag2 = this.pawn.MentalStateDef != MentalStateDefOf.Berserk;
						if (flag2)
						{
							this.pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Berserk, "Caused by the berserker chip", true, false, null, false, false, false);
						}
						else
						{
							this.pawn.mindState.mentalStateHandler.CurState.RecoverFromState();
							this.pawn.mindState.mentalStateHandler.Reset();
						}
					}
				},
				hotKey = KeyBindingDefOf.Misc3
			};
			yield break;
		}
	}
}
