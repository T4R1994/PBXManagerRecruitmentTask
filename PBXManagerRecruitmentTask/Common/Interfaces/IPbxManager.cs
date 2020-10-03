using PBXManagerRecruitmentTask.Common.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBXManagerRecruitmentTask.Common.Interfaces
{
	public interface IPbxManager
	{
		int GetCallNamberOnQueue();
		event CallProcessingStartedHandler CallStarted;
		event CallProcessingEndedEventHandler CallEnded;
		event CallQueuedEventHandler CallQueued;
	}
}
