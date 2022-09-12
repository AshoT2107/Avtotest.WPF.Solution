using Avtotest.WPF.Enums;
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
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void Max_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.Instance.WindowState == WindowState.Normal) MainWindow.Instance.WindowState = WindowState.Maximized;
            else MainWindow.Instance.WindowState = WindowState.Normal;
        }

        private void Drag_Panel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                MainWindow.Instance.DragMove();
            if(e.ClickCount == 2)
            {
                if (MainWindow.Instance.WindowState == WindowState.Normal) MainWindow.Instance.WindowState = WindowState.Maximized;
                else MainWindow.Instance.WindowState = WindowState.Normal;
            }
        }

        private void Min_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                MainWindow.Instance.WindowState = WindowState.Minimized;
        }

        private void Exit_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void StartExamination_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.DisplayPage(EPages.Examination);
        }

        private void TicketsList_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.DisplayPage(EPages.Tickets);
        }
    }
}
