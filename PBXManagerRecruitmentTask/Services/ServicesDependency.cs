using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBXManagerRecruitmentTask.Services
{
	public static class ServicesDependency
	{
		private static SimpleIoc _iocInstance = SimpleIoc.Default;

		public static void RegisterServices()
		{
			//_iocInstance.Register<MainPbxManagerViewModel>();
		}
	}
}
