using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBXManagerRecruitmentTask.ViewModels
{
	public class ViewModelLocator
	{
		public MainPbxManagerViewModel Main => SimpleIoc.Default.GetInstance<MainPbxManagerViewModel>();
	}
}
