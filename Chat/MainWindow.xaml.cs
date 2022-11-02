using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Chat.MVVM.Model;
using Chat.Core;
using System.IO;
using System.Text;
using System.ServiceModel.Channels;

namespace Chat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Messanges { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)    //  Код для панели
        {
            if (e.LeftButton == MouseButtonState.Pressed)   // С помощью этого кода можно перемещать окно за панель
            {
                DragMove();
            }
        }

        private void ButtonMinimize_Click1(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized; //  С помощью этого кода можно свернуть окно
        }

        private void WindowStateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)    //  С помощью этого кода можно увеличить или уменьшить окно
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); //  Закрывает окно
        }
      




        public void m1(object sender, RoutedEventArgs e)
        {

            //MessageBox message = new


            string path = @"D:\Сообщения.txt";   // путь к файлу

            
            // запись в файл
            File.AppendAllText(path, "\r\n" + isxod.Text);



            if (isxod.Text == "Привет" || isxod.Text == "привет")
            {
                
                Mess.Text = "Бот Гоша";
                Mess1.Text = "Здоровались уже";
            }
            else if (isxod.Text == "Как дела?" || isxod.Text == "как дела?" || isxod.Text == "Как дела" || isxod.Text == "как дела")
            {
                Mess2.Text = "Бот Гоша";
                Mess3.Text = "Все хорошо";
            }
        }

        public void Click_Diagramm(object sender, RoutedEventArgs e)
        {
            Diagramm diagramm = new Diagramm();
            diagramm.Show();
        }

            

        }
}
