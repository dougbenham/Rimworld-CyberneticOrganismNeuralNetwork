using System;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace CONN
{
	// Token: 0x02000015 RID: 21
	[StaticConstructorOnStartup]
	public class HarmonyInit
	{
		// Token: 0x06000034 RID: 52 RVA: 0x00003310 File Offset: 0x00001510
		static HarmonyInit()
		{
			Harmony harmony = new Harmony("kikohi.conn");
			harmony.PatchAll(Assembly.GetExecutingAssembly());
		}
	}
}
