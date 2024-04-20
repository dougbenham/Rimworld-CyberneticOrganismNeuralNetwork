using UnityEngine;
using Verse;

namespace CONN
{
	internal class CONNMod : Mod
	{
		public CONNMod(ModContentPack content) : base(content)
		{
			settings = GetSettings<CONNSettings>();
		}

		public override string SettingsCategory()
		{
			return "CONN.Settings".Translate();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			var listing_Standard = new Listing_Standard();
			listing_Standard.Begin(inRect);
			listing_Standard.CheckboxLabeled("CONN.EnableMote".Translate() + ": ", ref settings.enableMote);
			var enableMote = settings.enableMote;
			if (enableMote)
			{
				listing_Standard.CheckboxLabeled("CONN.EnableMoteDraft".Translate() + ": ", ref settings.enableMoteDraft);
			}
			listing_Standard.GapLine();
			listing_Standard.Label("CONN.MaxTraits".Translate() + ":");
			listing_Standard.TextFieldNumeric(ref settings.maxTraits, ref settings.maxTraitsBuffer, 3f, 20f);
			listing_Standard.End();
			settings.Write();
		}

		public static CONNSettings settings;
	}
}
