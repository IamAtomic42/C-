using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTK
{
    internal class Account
    {
        private string userID;
        private string pass;

        public string UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }

        public string Pass
        {
            get
            {
                return Pass;
            }

            set
            {
                Pass = value;
            }
        }

        public Account(string userID, string password)
        {
            this.userID = userID;
            this.pass = password;

        }
    }
}
