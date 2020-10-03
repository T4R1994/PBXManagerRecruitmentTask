using PBXManagerRecruitmentTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBXManagerRecruitmentTask.Common.EventModels
{
	public delegate void NewCallEventHandler(object sender, NewCallEventArgs args);
	public class NewCallEventArgs: EventArgs
	{
		public Call NewCall { get; set; }
	}
}
