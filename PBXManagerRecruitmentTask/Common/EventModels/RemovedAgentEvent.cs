using PBXManagerRecruitmentTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBXManagerRecruitmentTask.Common.EventModels
{
	public delegate void RemovedAgentEventHandler(object sender, RemovedAgentEventArgs args);

	public class RemovedAgentEventArgs : EventArgs 
	{
		public Agent RemovedAgent { get; }

		public RemovedAgentEventArgs(Agent agent)
		{
			RemovedAgent = agent;
		}
	}
}
