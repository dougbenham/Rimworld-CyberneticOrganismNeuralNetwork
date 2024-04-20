using System;
using UnityEngine;
using Verse;

namespace CONN
{
	// Token: 0x0200001A RID: 26
	internal class CONNMod : Mod
	{
		// Token: 0x0600003E RID: 62 RVA: 0x000034C4 File Offset: 0x000016C4
		public CONNMod(ModContentPack content) : base(content)
		{
			CONNMod.settings = base.GetSettings<CONNSettings>();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000034DA File Offset: 0x000016DA
		public override string SettingsCategory()
		{
			return "CONN.Settings".Translate();
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000034EC File Offset: 0x000016EC
		public override void DoSettingsWindowContents(Rect inRect)
		{
			Listing_Standard listing_Standard = new Listing_Standard();
			listing_Standard.Begin(inRect);
			listing_Standard.CheckboxLabeled("CONN.EnableMote".Translate() + ": ", ref CONNMod.settings.enableMote, null, 0f, 1f);
			bool enableMote = CONNMod.settings.enableMote;
			if (enableMote)
			{
				listing_Standard.CheckboxLabeled("CONN.EnableMoteDraft".Translate() + ": ", ref CONNMod.settings.enableMoteDraft, null, 0f, 1f);
			}
			listing_Standard.GapLine(12f);
			listing_Standard.Label("CONN.MaxTraits".Translate() + ":", -1f, null);
			listing_Standard.TextFieldNumeric<int>(ref CONNMod.settings.maxTraits, ref CONNMod.settings.maxTraitsBuffer, 3f, 20f);
			listing_Standard.End();
			CONNMod.settings.Write();
		}

		// Token: 0x04000014 RID: 20
		public static CONNSettings settings;
	}
}
