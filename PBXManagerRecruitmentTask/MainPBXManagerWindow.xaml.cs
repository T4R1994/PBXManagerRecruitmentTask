using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PBXManagerRecruitmentTask
{
	/// <summary>
	/// Interaction logic for MainPBXManagerWindow.xaml
	/// </summary>
	public partial class MainPBXManagerWindow : Window
	{
		public MainPBXManagerWindow()
		{
			InitializeComponent();
		}

		private void ItemsControl_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			// Scroll to bottom only when the scroll is on the bottom 
			if(ConsoleScroller.VerticalOffset == ConsoleScroller.ScrollableHeight)
			{
				ConsoleScroller.ScrollToBottom();
			}
			
		}

		private void GridTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}
	}
}
