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

namespace Chat
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        ApplicationContextcs db;

        public Registr()
        {
            InitializeComponent();

            db = new ApplicationContextcs();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)    //  Код для панели
        {
            if (e.LeftButton == MouseButtonState.Pressed)   // С помощью этого кода можно перемещать окно за панель
            {
                DragMove();
            }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
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

        private void Button_Avtoriz(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string name = TextBoxName.Text.Trim();
            string fam = TextBoxFam.Text.Trim();
            string pass = PasswordBox.Password.Trim();
            string pass_2 = PasswordBox_2.Password.Trim();


            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Это поле введено не коректно!";
                TextBoxLogin.Background = Brushes.DarkRed;
            }
            if (name.Length < 5)
            {
                TextBoxName.ToolTip = "Это поле введено не коректно!";
                TextBoxName.Background = Brushes.DarkRed;
            }
            if (fam.Length < 1)
            {
                TextBoxFam.ToolTip = "Это поле введено не коректно!";
                TextBoxFam.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                PasswordBox.ToolTip = "Это поле введено не коректно!";
                PasswordBox.Background = Brushes.DarkRed;
            }
            else if (pass != pass_2)
            {
                PasswordBox_2.ToolTip = "Это поле введено не коректно!";
                PasswordBox_2.Background = Brushes.DarkRed;
            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;
                TextBoxName.ToolTip = "";
                TextBoxName.Background = Brushes.Transparent;
                TextBoxFam.ToolTip = "";
                TextBoxFam.Background = Brushes.Transparent;
                PasswordBox.ToolTip = "";
                PasswordBox.Background = Brushes.Transparent;
                PasswordBox_2.ToolTip = "";
                PasswordBox_2.Background = Brushes.Transparent;

                MessageBox.Show("Регистрация прошла успешно");

                User user = new User(login, name, fam, pass);   //Создание нового объекта
                db.Users.Add(user); //  Добавление объекта в БД
                db.SaveChanges();   //  Сохранение объекта в БД
            }

        }
    }
}
