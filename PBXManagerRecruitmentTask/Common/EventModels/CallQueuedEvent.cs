using PBXManagerRecruitmentTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBXManagerRecruitmentTask.Common.EventModels
{
	public delegate void CallQueuedEventHandler(object source, CallQueuedEventArgs args);
	public class CallQueuedEventArgs
	{
		public Call QueuedCall { get; set; }
		public int CurrentQueuedCallCount { get; set; }
	}
}
