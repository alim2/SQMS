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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Data;
using DevExpress.Mvvm.Native;
using DevExpress.Xpf.Core;

namespace SQMS.View
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogInView : UserControl
    {


        private MainWindow _myMainWindow;

        public LogInView(MainWindow myMainWindow)
        {
            InitializeComponent();
            _myMainWindow = myMainWindow;

        }

        private void Log_In_Tile_Click(object sender, EventArgs e)
        {
            var myHome = new Home();
            _myMainWindow.SreenNav.Content = myHome;
        }

        private void UserNameText_Loaded(object sender, RoutedEventArgs e)
        {
            UserNameText.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
        }



    }
}
