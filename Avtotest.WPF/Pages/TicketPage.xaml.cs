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

namespace Avtotest.WPF.Pages
{
    /// <summary>
    /// Interaction logic for TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        public TicketPage()
        {
            InitializeComponent();
            GenerateTicketsList();
        }

        private void Drag_Panel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) MainWindow.Instance.DragMove();
            if (e.ClickCount == 2)
            {
                if (MainWindow.Instance.WindowState == WindowState.Maximized) MainWindow.Instance.WindowState = WindowState.Normal;
                else MainWindow.Instance.WindowState = WindowState.Maximized;
            }
        }

        private void Exit_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void Max_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.Instance.WindowState == WindowState.Maximized)
            {
                MainWindow.Instance.WindowState = WindowState.Normal;
            }
            else
                MainWindow.Instance.WindowState = WindowState.Maximized;
        }

        private void Min_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.Instance.WindowState = WindowState.Minimized;
        }

        private void GenerateTicketsList()
        {
            TicketButtonsPanel.Children.Clear();
            
            for (int i = 0; i < 35; i++)
            {
                var button = new Button();
                button.Style = FindResource("TicketButtonStyle") as Style;
                button.Template = FindResource("TicketButtonTemplate") as ControlTemplate;
                if(i==1)
                    button.DataContext = new { Ticket = new { Text = $"{i+1}. Ticket 12/20" } };
                else if(i==4)
                    button.DataContext = new { Ticket = new { Text = $"{i+1}. ✅" } };
                else
                button.DataContext = new { Ticket = new { Text = $"{i + 1}. Ticket" } };
                TicketButtonsPanel.Children.Add(button);
            }

        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.DisplayPage(Enums.EPages.Menu);
        }
    }
}
