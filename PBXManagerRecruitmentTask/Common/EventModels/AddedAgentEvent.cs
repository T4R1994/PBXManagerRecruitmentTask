using PBXManagerRecruitmentTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBXManagerRecruitmentTask.Common.EventModels
{
	public delegate void AddedAgentEventHandler(object sender, AddedAgentEventArgs args);

	public class AddedAgentEventArgs: EventArgs 
	{
		public Agent NewAgent { get; }

		public AddedAgentEventArgs(Agent agent)
		{
			NewAgent = agent;
		}
	}
}
