using Verse;

namespace CONN
{
	public class CONNSettings : ModSettings
	{
		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look(ref enableMote, "enableMote", true);
			Scribe_Values.Look(ref enableMoteDraft, "enableMoteDraft");
			Scribe_Values.Look(ref maxTraits, "maxTraits", 3);
		}

		public bool enableMote = true;

		public bool enableMoteDraft;

		public int maxTraits = 3;

		public string maxTraitsBuffer;
	}
}
