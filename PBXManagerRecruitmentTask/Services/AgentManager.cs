using PBXManagerRecruitmentTask.Common.EventModels;
using PBXManagerRecruitmentTask.Common.Interfaces;
using PBXManagerRecruitmentTask.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PBXManagerRecruitmentTask.Services
{
	public class AgentManager : IAgentManager
	{
		
		private ConcurrentDictionary<string, Agent> _allAgents = new ConcurrentDictionary<string, Agent>();

		public event AddedAgentEventHandler AgentCreated;
		public event RemovedAgentEventHandler AgentRemoved;

		public void AddAgent(Agent agentModel)
		{
			if (agentModel == null) return;

			if(!_allAgents.ContainsKey(agentModel.Name))
			{
				if(_allAgents.TryAdd(agentModel.Name, agentModel))
				{
					AgentCreated.Invoke(this, new AddedAgentEventArgs(agentModel));
				}
			}
		}

		public void AddAgent(string name)
		{
			AddAgent(new Agent { Name = name });
		}

		public bool CheckAgentName(string name)
		{
			return _allAgents.ContainsKey(name);
		}

		public void RemoveAgent(Agent agent)
		{
			if (agent == null) return;

			if (_allAgents.ContainsKey(agent.Name))
			{
				if (_allAgents.TryRemove(agent.Name, out var agentModel))
				{
					AgentRemoved.Invoke(this, new RemovedAgentEventArgs(agentModel));
				}
			}
		}

		public void RemoveAgent(string name)
		{
			RemoveAgent(new Agent { Name = name });
		}

		public IEnumerable<Agent> GetAllAgents()
		{
			return _allAgents.Values;
		}
	}
}
