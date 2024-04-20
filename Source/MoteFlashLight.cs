using Verse;

namespace CONN
{
	public class MoteFlashLight : Mote
	{
		public override float Alpha => 0.4f;

		protected override bool EndOfLife => false;
	}
}
