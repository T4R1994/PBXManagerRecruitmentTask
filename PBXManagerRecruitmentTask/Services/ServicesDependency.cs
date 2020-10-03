using GalaSoft.MvvmLight.Ioc;
using PBXManagerRecruitmentTask.Common.Interfaces;
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
			_iocInstance.Register<IAgentManager, AgentManager>();
			_iocInstance.Register<IPbxProvider, PbxProvider>();
			_iocInstance.Register<IPbxManager, PbxManager>();
		}
	}
}
