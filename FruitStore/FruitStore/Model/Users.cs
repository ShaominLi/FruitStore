using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitStore.Model
{
    public class Users
    {
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private string userVName;

        public string UserVName
        {
            get { return userVName; }
            set { userVName = value; }
        }
        private string userPsw;

        public string UserPsw
        {
            get { return userPsw; }
            set { userPsw = value; }
        }
        private string userTName;

        public string UserTName
        {
            get { return userTName; }
            set { userTName = value; }
        }
        private string userAdress;

        public string UserAdress
        {
            get { return userAdress; }
            set { userAdress = value; }
        }
        private string userPhone;

        public string UserPhone
        {
            get { return userPhone; }
            set { userPhone = value; }
        }
        
        public Users(string username, string userpsw, string usertname, string useradd=null, string userphone=null)
        {
            UserVName = username;
            UserPsw = userpsw;
            UserTName = usertname;
            UserAdress = useradd;
            UserPhone = userphone;
        }
    }
}