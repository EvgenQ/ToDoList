using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus
{
	class NPC
	{
		public string Wampus { get; private set; } = "[W]";
		public string Bat { get; private set; } = "[B]";
		public string DeathPit { get; private set; } = "[O]";
		public string Player { get; private set; } = "[@]";
	}
}
