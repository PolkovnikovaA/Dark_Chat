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
using System.Data;

namespace Chat
{
    /// <summary>
    /// Логика взаимодействия для Avtoriz.xaml
    /// </summary>
    public partial class Avtoriz : Window
    {
        public Avtoriz()
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

        private void Button_Registr(object sender, RoutedEventArgs e)
        {
            Registr vxoregistrd = new Registr();
            vxoregistrd.Show();
            Hide();
        }

        private void Button_Click_Vxod(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass = PasswordBox.Password.Trim();

            // Проверка значений
            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Это поле введено не коректно!";
                TextBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                PasswordBox.ToolTip = "Это поле введено не коректно!";
                PasswordBox.Background = Brushes.DarkRed;
            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;
                PasswordBox.ToolTip = "";
                PasswordBox.Background = Brushes.Transparent;

                User authUser = null;
                using (ApplicationContextcs db = new ApplicationContextcs())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();    //  Проверка введеных данных с БД
                }

                if(authUser != null)
                {
                    MainWindow vxod = new MainWindow();
                    vxod.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Вы ввели что-то не коректно!");
                }

                
            }
        }
    }
}
