using PBXManagerRecruitmentTask.Common.EventModels;
using PBXManagerRecruitmentTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBXManagerRecruitmentTask.Common.Interfaces
{
	public interface IAgentManager
	{
		IEnumerable<Agent> GetAllAgents();
		bool CheckAgentName(string name);
		void AddAgent(Agent agentModel);
		void AddAgent(string name);
		event AddedAgentEventHandler AgentCreated;
		void RemoveAgent(Agent agent);
		void RemoveAgent(string name);
		event RemovedAgentEventHandler AgentRemoved;
	}
}
