using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Threading;
using PBXManagerRecruitmentTask.Common.EventModels;
using PBXManagerRecruitmentTask.Common.Interfaces;
using PBXManagerRecruitmentTask.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBXManagerRecruitmentTask.ViewModels
{
	public class MainPbxManagerViewModel : ViewModelBase
	{
		private readonly IPbxManager _pbxManager;
		private readonly IAgentManager _agentManager;
		private readonly IPbxProvider _pbxProvider;

		private string _newAgentName;
		public string NewAgentName 
		{
			get => _newAgentName;
			set => Set(ref _newAgentName, value);
		}

		public RelayCommand AddAgentCommand { get; private set; }
		public RelayCommand<Agent> RemoveAgentCommand { get; private set; }
		public RelayCommand MakeCallCommand { get; private set; }

		public ObservableCollection<Agent> Agents { get; } = new ObservableCollection<Agent>();
		public ObservableCollection<string> ConsoleItems { get; } = new ObservableCollection<string>();

		public MainPbxManagerViewModel(IPbxManager pbxManager, IAgentManager agentManager, IPbxProvider pbxProvider)
		{
			_pbxManager = pbxManager;
			_agentManager = agentManager;
			_pbxProvider = pbxProvider;

			_agentManager.AgentCreated += AgentManager_AgentCreated;
			_agentManager.AgentRemoved += AgentManager_AgentRemoved;

			_pbxManager.CallStarted += PbxManager_CallStarted;
			_pbxManager.CallEnded += PbxManager_CallEnded;
			_pbxManager.CallQueued += PbxManager_CallQueued;

			AddAgentCommand = new RelayCommand(AddAgent, CanAddAgent);
			RemoveAgentCommand = new RelayCommand<Agent>(RemoveAgent);
			MakeCallCommand = new RelayCommand(MakeCall);

			InitializeAgentList();
		}

		private void PbxManager_CallQueued(object source, CallQueuedEventArgs args)
		{
			DispatcherHelper.CheckBeginInvokeOnUI(() =>
			{
				ConsoleItems.Add($"The call with id {args.QueuedCall.Id} has been queued.");
				ConsoleItems.Add($"Calls in queue: {args.CurrentQueuedCallCount}.");
			});
		}

		private void PbxManager_CallEnded(object sender, CallProcessingEndedEventArgs args)
		{
			DispatcherHelper.CheckBeginInvokeOnUI(() =>
			{
				ConsoleItems.Add($"Agent: {args.CallAnswerer.Name}, FINISHED a call with id: {args.PrecessedCall.Id} after {args.PrecessedCall.DurationInSec} sec.");
			});
		}

		private void PbxManager_CallStarted(object sender, CallProcessingStartedEventArgs args)
		{
			DispatcherHelper.CheckBeginInvokeOnUI(() =>
			{
				ConsoleItems.Add($"Agent: {args.CallAnswerer.Name}, STARTED a call with id: {args.PrecessedCall.Id}.");
			});
		}

		private void AgentManager_AgentRemoved(object sender, RemovedAgentEventArgs e)
		{
			Agents.Remove(e.RemovedAgent);
			ConsoleItems.Add($"Removed agent: {e.RemovedAgent.Name}");
		}

		private void AgentManager_AgentCreated(object sender, Common.EventModels.AddedAgentEventArgs args)
		{
			Agents.Add(args.NewAgent);
			ConsoleItems.Add($"Added agent: {NewAgentName}");
			ClearNewAgentName();
		}

		private void AddAgent() 
		{
			_agentManager.AddAgent(NewAgentName);
		}

		private bool CanAddAgent() => !string.IsNullOrWhiteSpace(NewAgentName);

		private void RemoveAgent(Agent agent)
		{
			if(agent != null)
			{
				_agentManager.RemoveAgent(agent);			
			}		
		}

		private void MakeCall()
		{
			_pbxProvider.GenerateCall();
		}

		private void ClearNewAgentName() 
		{
			NewAgentName = string.Empty;
		}

		private void InitializeAgentList() 
		{
			foreach(var agent in _agentManager.GetAllAgents())
			{
				Agents.Add(agent);
			}
		}
	}
}
