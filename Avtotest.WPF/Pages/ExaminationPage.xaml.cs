using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.IO;
using Avtotest.WPF.Databases;
using Avtotest.WPF.Models;

namespace Avtotest.WPF.Pages
{
    /// <summary>
    /// Interaction logic for ExaminationPage.xaml
    /// </summary>
    public partial class ExaminationPage : Page
    {
        public ExaminationPage()
        {
            InitializeComponent();
            GenerateQuestionIndexButtons();
            ShowQuestionText();
        }

        List<Button> buttonsList = new List<Button>();
        int currentQuestionIndex = 0;
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
            {
                MainWindow.Instance.WindowState = WindowState.Maximized;
                foreach (var button in buttonsList)
                {
                    button.Width = (MainWindow.Instance.Width - 30)/ 20;
                }
            }
                
        }
        private void Min_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
                MainWindow.Instance.WindowState = WindowState.Minimized;
        }

        private void Drag_Panel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) MainWindow.Instance.DragMove();
            if(e.ClickCount ==2)
            {
                if (MainWindow.Instance.WindowState == WindowState.Maximized) MainWindow.Instance.WindowState = WindowState.Normal;
                else
                {
                    MainWindow.Instance.WindowState = WindowState.Maximized;
                    foreach (var button in buttonsList)
                    {
                        button.Width = (MainWindow.Instance.Width - 50) / 20;
                    }
                }
                    
            }

        }

        private void GenerateQuestionIndexButtons()
        {
            int buttonsCount = 20;
            for (int i = 0; i < buttonsCount; i++)
            {
                var button = new Button();
                button.Style = FindResource("QuestionIndexButtonStyle") as Style;
                button.Content = i+1;
                button.Width = (MainWindow.Instance.Width-50) / 20;
                button.Click += QuestionIndexButton_Click;
                QuestionsIndexPanel.HorizontalAlignment = HorizontalAlignment.Center;
                QuestionsIndexPanel.Children.Add(button);
                buttonsList.Add(button);
            }
        }
        private void QuestionIndexButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            currentQuestionIndex = int.Parse(button.Content.ToString()!)-1;
            ShowQuestionText();
        }

        private void ShowImage(string imageName)
        {
            QuestionImage.Fill = new ImageBrush(new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "QuestionImages", $"{imageName}.png"))));
            //QuestionImage.Source = new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "QuestionImages", $"{imageName}.png")));
        }
        private void ShowQuestionText()
        {
            QuestionText.Text = "";
            ChoicesPanel.Children.Clear();
            var question = Database.Db.QuestionsDb.Questions[currentQuestionIndex];
            QuestionText.Style = FindResource("QuestionTextStyle") as Style;
            QuestionText.Text =$"{currentQuestionIndex + 1}. {question.Question}";
            if (question.Media.Exist) ShowImage((currentQuestionIndex+1).ToString());
            else
               QuestionImage.Fill = new ImageBrush(new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "QuestionImages", "panda.jpg"))));
            ShowChoiceButtons(question.Choices);
        }

        private void ShowChoiceButtons(List<Choice> choices)
        {
            int buttonsCount = choices.Count;
            for (int i = 0; i < buttonsCount; i++)
            {
                var button = new Button();
                button.Style = FindResource("ChoiceButtonStyle") as Style;// cs dagi style ni UI dagi style ga o'zlashtirib olaman
                button.DataContext = choices[i];
                button.Tag = i;
                button.Click += Button_Click;
                ChoicesPanel.Children.Add(button);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var button = sender as Button;
            var choice = button!.DataContext as Choice;
            
            if (choice!.Answer)
            {
                button.Background = new SolidColorBrush(Colors.Green);
                button.Foreground = new SolidColorBrush(Colors.Snow);
                buttonsList[currentQuestionIndex].Background= new SolidColorBrush(Colors.Green);
            }
            else
            {
                button.Background = new SolidColorBrush(Colors.Red);
                button.Foreground = new SolidColorBrush(Colors.Snow);
                buttonsList[currentQuestionIndex].DataContext = new { Background = new { Color = new SolidColorBrush(Colors.Red) }  };
            }
            currentQuestionIndex++;
            ShowQuestionText();
        }
    }
}
