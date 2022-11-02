using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    internal class User
    {

        public int id { get; set; }

        private string login, name, fam, pass;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Fam
        {
            get { return fam; }
            set { fam = value; }
        }
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        public User() { }    //Без него работать не будет

        public User(string login, string name, string fam, string pass)
        {
            this.login = login;
            this.name = name;
            this.fam = fam;
            this.pass = pass;
        }
    }



}

