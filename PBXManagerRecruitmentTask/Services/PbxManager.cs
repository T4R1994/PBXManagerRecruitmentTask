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
	public class PbxManager: IPbxManager
	{
		private readonly IAgentManager _agentManager;
		private readonly IPbxProvider _pbxProvider;

		private readonly ConcurrentQueue<Call> _queueOfCalls = new ConcurrentQueue<Call>();

		private readonly ConcurrentDictionary<string, CancellationTokenSource> _agentsWithTaskCancellationTokenSources = new ConcurrentDictionary<string, CancellationTokenSource>();

		public event CallProcessingStartedHandler CallStarted;
		public event CallProcessingEndedEventHandler CallEnded;
		public event CallQueuedEventHandler CallQueued;

		public PbxManager(IAgentManager agentManager, IPbxProvider pbxProvider)
		{
			_agentManager = agentManager;
			_pbxProvider = pbxProvider;

			_pbxProvider.NewCall += PbxProvider_NewCall;

			_agentManager.AgentCreated += AgentManager_AgentCreated;
			_agentManager.AgentRemoved += AgentManager_AgentRemoved;
		}

		public int GetCallNamberOnQueue()
		{
			return _queueOfCalls.Count;
		}

		private void AgentManager_AgentRemoved(object sender, RemovedAgentEventArgs args)
		{
			if(_agentsWithTaskCancellationTokenSources.TryRemove(args.RemovedAgent.Name, out var cts))
			{
				cts.Cancel();
			}
		}

		private void AgentManager_AgentCreated(object sender, AddedAgentEventArgs args)
		{
			if(!_agentsWithTaskCancellationTokenSources.ContainsKey(args.NewAgent.Name))
			{
				var agent = args.NewAgent;
				var cts = new CancellationTokenSource();
				var ctoken = cts.Token;

				Task.Factory.StartNew(() => 
				{
					ctoken.ThrowIfCancellationRequested();

					while (!ctoken.IsCancellationRequested)
					{
						if(_queueOfCalls.TryDequeue(out var call))
						{
							CallStarted?.Invoke(this, new CallProcessingStartedEventArgs { CallAnswerer = agent, PrecessedCall = call });
							Thread.Sleep(call.DurationInSec * 1000);
							CallEnded?.Invoke(this, new CallProcessingEndedEventArgs { CallAnswerer = agent, PrecessedCall = call });
						}
					}
				}, ctoken, TaskCreationOptions.LongRunning, TaskScheduler.Default);

				_agentsWithTaskCancellationTokenSources.TryAdd(args.NewAgent.Name, cts);
			}			
		}

		private void PbxProvider_NewCall(object sender, NewCallEventArgs args)
		{
			_queueOfCalls.Enqueue(args.NewCall);
			CallQueued?.Invoke(this, new CallQueuedEventArgs { QueuedCall = args.NewCall, CurrentQueuedCallCount = _queueOfCalls.Count });		
		}
	}
}
