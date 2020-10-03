using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PBXManagerRecruitmentTask
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			DispatcherHelper.Initialize();
			InitalizeDependencies();
		}

		private void InitalizeDependencies() 
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			ViewModels.ViewModelDependency.RegisterViewModels();
			Services.ServicesDependency.RegisterServices();
		}
	}
}
