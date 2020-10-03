using PBXManagerRecruitmentTask.Common.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBXManagerRecruitmentTask.Common.Interfaces
{
	public interface IPbxProvider
	{
		event NewCallEventHandler NewCall;
		void GenerateCall();
	}
}
