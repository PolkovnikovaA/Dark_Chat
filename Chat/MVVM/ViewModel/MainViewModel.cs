using Chat.Core;
using Chat.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        /* Команды */

        public RelayCommand SendCommand { get; set; }   //  Отправка сообщений

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set { _selectedContact = value;
                OnPropertyChanged();
            }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set 
            { 
                _message = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Username = "Гость",
                    UsernameColor = "#409aff",
                    //ImageSource = "https://w7.pngwing.com/pngs/660/841/png-transparent-computer-icons-guest-angle-white-text.png" + "\n" + "\n" + "\n",
                    Message = Message + "\n" + "\n" + "\n",
                    FirstMassege = false
                });

                Message = "";
            });

            Messages.Add(new MessageModel
            {
                Username = "Бот Гоша",
                UsernameColor = "#409aff",
                //ImageSource = "https://cdn-icons-png.flaticon.com/512/4712/4712038.png",
                Message = "Извините, Никиты дома нет( Но с вами буду болтать Я :)",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMassege = true
            });



            for (int i = 0; i < 1; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"Бот Никита",
                    ImageSource = "https://cdn-icons-png.flaticon.com/512/4712/4712038.png",
                    Messages = Messages
                });
            }
        }

    }
}
