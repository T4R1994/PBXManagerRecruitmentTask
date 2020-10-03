using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBXManagerRecruitmentTask.Models
{
	public class Call
	{
		public string Id { get; set; }
		public int DurationInSec { get; set; }

		public static Call NewCall()
		{
			return new Call
			{
				Id = Guid.NewGuid().ToString(),
				DurationInSec = new Random().Next(1, 10)
			};
		}
	}
}
