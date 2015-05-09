using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.LayoutControl;
using MessagingToolkit.QRCode.Codec;


namespace SQMS.View
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        private int _counter;

        public Home()
        {
            InitializeComponent();
            GetContent();
            _counter = 0;
        }

        private void GetContent()
        {
            string[] arr = {"Deposit", "Withdraw", "Remitance", "Account Info", "Credit Card", "Debit Card"};
            
            for (int i = 0; i < arr.Length; i++)
            {

                Tile b = new Tile
                {
                    Content = arr[i],
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Height = 80,
                    Width = 300,
                    FontSize = 22,
                    Margin = new Thickness(40, 10, 20, 0),
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    MinHeight = i
                };
                b.Click += b_Click;

                HomeFlow.Children.Add(b);
            }
        }

        private void ShowReport(string category, string path, string catName)
        {
            var myqr = new QRCodeEncoder();
            Bitmap img = myqr.Encode(category + _counter);
            img.Save(path + _counter + ".jpg", ImageFormat.Jpeg);

            BitmapImage bim = new BitmapImage();
            bim.BeginInit();
            bim.UriSource = new Uri(path + _counter + ".jpg", UriKind.Relative);
            bim.CacheOption = BitmapCacheOption.OnLoad;
            bim.EndInit();

            new Window1(bim, category + _counter, catName).Show();
        }

        private void b_Click(object sender, EventArgs e)
        {
            var v = (Tile) sender;
            _counter++;

            switch (Convert.ToInt32(v.MinHeight))
            {
                case 0:
                    ShowReport("D ", "../../View/QR Image/deposit/","Deposit");
                    break;
                case 1:
                    ShowReport("W ", "../../View/QR Image/withdraw/","Withdraw");
                    break;
                case 2:
                    ShowReport("R ", "../../View/QR Image/remitance/", "Remitance");
                    break;
                case 3:
                    ShowReport("A ", "../../View/QR Image/accinfo/", "Account Info.");
                    break;
                case 4:
                    ShowReport("CC ", "../../View/QR Image/credit/", "Credit Card");
                    break;
                case 5:
                    ShowReport("DC ", "../../View/QR Image/debit/", "Debit Card");
                    break;
            }
            
        }//

    }
}
