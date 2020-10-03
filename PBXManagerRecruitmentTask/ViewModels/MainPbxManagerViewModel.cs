using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
		private string _newAgentName;
		public string NewAgentName 
		{
			get => _newAgentName;
			set => Set(ref _newAgentName, value);
		}

		public RelayCommand AddAgentCommand { get; private set; }
		public RelayCommand<Agent> RemoveAgentCommand { get; private set; }
		public RelayCommand MakeCallCommand { get; private set; }

		public ObservableCollection<Agent> Agents { get; } = new ObservableCollection<Agent>()
		{
			new Agent() { Name = "Tom" },
			new Agent() { Name = "Carl" }
		};

		public ObservableCollection<string> ConsoleItems { get; } = new ObservableCollection<string>()
		{
			"test1",
			"Aplikacja ma być cały czas responsywna, niedopuszczalne jest zamrożenie wątku UI. Aplikacja ma być cały czas responsywna, niedopuszczalne jest zamrożenie wątku UI."
		};

		public MainPbxManagerViewModel()
		{
			AddAgentCommand = new RelayCommand(AddAgent, CanAddAgent);
			RemoveAgentCommand = new RelayCommand<Agent>(RemoveAgent);
			MakeCallCommand = new RelayCommand(MakeCall);
		}

		private void AddAgent() 
		{
			Agents.Add(new Agent { Name = NewAgentName });

			ConsoleItems.Add($"Added agent: {NewAgentName}");
			ClearNewAgentName();
		}

		private bool CanAddAgent() => !string.IsNullOrWhiteSpace(NewAgentName) && !Agents.Any(i => NewAgentName == i.Name);

		private void RemoveAgent(Agent agent)
		{
			if(agent != null)
			{
				Agents.Remove(agent);
				ConsoleItems.Add($"Removed agent: {agent.Name}");
			}		
		}

		private void MakeCall()
		{
			ConsoleItems.Add($"Call with id: _ was invoked manually.");
		}

		private void ClearNewAgentName() 
		{
			NewAgentName = "";
		}
	}
}
