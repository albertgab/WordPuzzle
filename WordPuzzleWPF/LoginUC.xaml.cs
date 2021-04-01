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

namespace WordPuzzleWPF
{

    /// <summary>
    /// Interaction logic for LoginUC.xaml
    /// </summary>
    /// public event EventHandler UserControlClicked;
    public partial class LoginUC : UserControl
    { 
        public event Action<string> onUserCodeFetched;
        public event EventHandler UserControlClicked;


        public LoginUC()
        {
            InitializeComponent();
        }

        private void clickkk(object sender, RoutedEventArgs e)
        {
            if (UserControlClicked != null)
            {
                UserControlClicked(this, EventArgs.Empty);
            }

            //MainWindow
            onUserCodeFetched("asd");


        }
    }
}
