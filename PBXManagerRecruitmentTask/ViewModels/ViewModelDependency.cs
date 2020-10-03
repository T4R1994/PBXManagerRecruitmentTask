using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBXManagerRecruitmentTask.ViewModels
{
	public static class ViewModelDependency
	{

		private static SimpleIoc _iocInstance = SimpleIoc.Default;
		
		public static void RegisterViewModels()
		{
			_iocInstance.Register<MainPbxManagerViewModel>();
		}
	}
}
