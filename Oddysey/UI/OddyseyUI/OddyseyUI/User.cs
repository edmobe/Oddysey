using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OddyseyUI
{
    [XmlRoot("User")]
    public class User
    {
        
        public string Name;
        public string LastName;
        public string NickName;
        public string Password;
        public string Favs;
        public string Age;
        public string Friends;

        public void SetMainParameter(string name, string lastname, string nickname, string password, string age)
        {
            Name = name;
            LastName = lastname;
            NickName = nickname;
            Password = password;
            Age = age;
        }
        public void SetLogParameter(string nickname, string password)
        {
            NickName = nickname;
            Password = password;
        }
    }
}
