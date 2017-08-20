using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestion.Classes {
    class Login_func {

        LINQDataContext db = new LINQDataContext(Program.Global_ConString);
        


        public bool check_password(string username, string password) {
            var querry = (from a in db.Users
                           where a.username == username
                           select new {
                               salt = a.salt,
                               password = a.password
                           }).Single();

            

            
            hashIt hash = new hashIt(password.Trim(),querry.salt.Trim());
            if (hash.Hash == querry.password.Trim()) {
                MessageBox.Show("ggwp");
                return true;
            }
            else {
                MessageBox.Show("Buuuu");
                return false;
            }
        }


    }
}
