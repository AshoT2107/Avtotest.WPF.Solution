using Avtotest.WPF.Enums;
using Avtotest.WPF.Pages;
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

namespace Avtotest.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow? _instance;
        public static MainWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainWindow();
                return _instance;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            _instance = this;

            //Frame.Source = new Uri(@"Pages/MainMenuPage.xaml", UriKind.Relative);
            MainFrame.Navigate(new MainMenuPage());
        }

        public void DisplayPage(EPages page)
        {
            switch (page)
            {
                case EPages.Examination:
                    MainFrame.Navigate(new ExaminationPage());
                    break;
                case EPages.Tickets:MainFrame.Navigate(new TicketPage()); break;
                case EPages.Menu: MainFrame.Navigate(new MainMenuPage()); break;
            }
        }
    }
}
