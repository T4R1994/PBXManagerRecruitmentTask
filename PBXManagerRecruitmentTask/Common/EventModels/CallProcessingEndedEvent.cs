using PBXManagerRecruitmentTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBXManagerRecruitmentTask.Common.EventModels
{

	public delegate void CallProcessingEndedEventHandler(object sender, CallProcessingEndedEventArgs args);
	public class CallProcessingEndedEventArgs
	{
		public Agent CallAnswerer { get; set; }
		public Call PrecessedCall { get; set; }
	}
}
