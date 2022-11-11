# Dark Chat

**Dark Chat** был создан для общения с ботом, если вам **очень скучно** :smile:

## Начало работы

Перед использованием работы необходимо выполгить следующие действия:<br>
* скачать проект с **GitHub**;
* распаковать скачанный архив.

___
### Необходимые условия

Для работы с программой нужен ПК с операционный системой **Windows 7** *и новее.*
___

### Работа с программой

Работа с программой начинается с **Авторизации/Регистрации**<br>

![Авторизация](https://sun9-64.userapi.com/impg/HzphTgiMVsuWSYgwJFNMs2iUPbOIJQbhog--xg/cySwZXvGOnE.jpg?size=468x292&quality=96&sign=c838b214b7230ab46a52a658d8eda0e2&type=album)<br>
![Регистрация](https://sun9-24.userapi.com/impg/SbHN6qBbVWnhD3Avn3FqGbso80HbsJCultObVg/8bvBJ47LkV8.jpg?size=532x633&quality=96&sign=2c2608b032cb48a0b477da4d2a801000&type=album)<br>

После авторизации запускается тот самый **Dark Chat**<br>

![Dark Chat](https://sun9-26.userapi.com/impg/Elgyv2RqJb2NxuaR9qtLYrjroOXdXzppK0bp-A/N1zDXcQDQrs.jpg?size=1199x651&quality=96&sign=c90e3a8b915c33b9b280be46c5747a29&type=album)<br>
___
## Установка

* запустить **Visual Studio**;
* зайти на вкладку *Открыть проект или решение*;
* найти проект в проводнике;
* Открыть файл с расширением **.sln**;<br>
![Вид файла](https://sun9-3.userapi.com/impg/c1dskYLoxYOLM9IpaOdcLEAysTXfgwXMGK6QYQ/YOrQ8Nql2zg.jpg?size=145x30&quality=96&sign=e9a9f1ef8b4bfdcdab5e0b727fa08fb3&type=album)<br>
* и запустить проект.

___
## Код программы :sweat_smile:

Проверка на **правильность введенных данных** (*"Защита от дурака"*)<br>

``` C#
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
```
<br>

**Проверка введенных данных с БД**<br>

``` C#
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
```

____
## Авторы

* **Полковникова Анастасия** - *Основная работа* - [PolkovnikovaA](https://github.com/PolkovnikovaA)
* **Власова Анастасия** - *Соавтор* - [Anastasiy1307](https://github.com/Anastasiy1307)<br>
![Logo](https://cdn.dribbble.com/users/1210505/screenshots/3893792/dark_chat_1.png)<br>
**Ссылка на проект** [Dark Chat](https://github.com/PolkovnikovaA/Dark_Chathttps://github.com/PolkovnikovaA/Dark_Chat)


