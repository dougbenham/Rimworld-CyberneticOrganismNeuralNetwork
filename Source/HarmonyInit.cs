using System.Reflection;
using HarmonyLib;
using Verse;

namespace CONN
{
	[StaticConstructorOnStartup]
	public class HarmonyInit
	{
		static HarmonyInit()
		{
			var harmony = new Harmony("doug.conn");
			harmony.PatchAll(Assembly.GetExecutingAssembly());
		}
	}
}
