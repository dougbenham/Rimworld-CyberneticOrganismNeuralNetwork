using System;
using Verse;

namespace CONN
{
	// Token: 0x02000014 RID: 20
	public class MoteFlashLight : Mote
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000032FD File Offset: 0x000014FD
		public override float Alpha
		{
			get
			{
				return 0.4f;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00003304 File Offset: 0x00001504
		protected override bool EndOfLife
		{
			get
			{
				return false;
			}
		}
	}
}
