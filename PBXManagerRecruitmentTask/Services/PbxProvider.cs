using PBXManagerRecruitmentTask.Common.EventModels;
using PBXManagerRecruitmentTask.Common.Interfaces;
using PBXManagerRecruitmentTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PBXManagerRecruitmentTask.Services
{
	public class PbxProvider : IPbxProvider
	{
		public event NewCallEventHandler NewCall;

		public PbxProvider()
		{
			StartGeneratingCalls();
		}

		public void GenerateCall()
		{
			NewCall(this, new NewCallEventArgs { NewCall = Call.NewCall() });
		}

		private void StartGeneratingCalls()
		{
			Task.Factory.StartNew(DoWork, TaskCreationOptions.LongRunning);
		}

		private void DoWork()
		{
			var random = new Random();
			Func<int> numberGenerator = () => random.Next(1, 5);
			while(true)
			{
				Thread.Sleep(numberGenerator() * 1000);
				NewCall(this, new NewCallEventArgs { NewCall = Call.NewCall() });
			}
		}


	}
}
