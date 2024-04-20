using System;
using Verse;

namespace CONN
{
	// Token: 0x02000019 RID: 25
	public class CONNSettings : ModSettings
	{
		// Token: 0x0600003C RID: 60 RVA: 0x00003458 File Offset: 0x00001658
		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look<bool>(ref this.enableMote, "enableMote", true, false);
			Scribe_Values.Look<bool>(ref this.enableMoteDraft, "enableMoteDraft", false, false);
			Scribe_Values.Look<int>(ref this.maxTraits, "maxTraits", 3, false);
		}

		// Token: 0x04000010 RID: 16
		public bool enableMote = true;

		// Token: 0x04000011 RID: 17
		public bool enableMoteDraft = false;

		// Token: 0x04000012 RID: 18
		public int maxTraits = 3;

		// Token: 0x04000013 RID: 19
		public string maxTraitsBuffer;
	}
}
