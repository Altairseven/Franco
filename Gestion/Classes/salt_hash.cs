using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestion.Classes {
    class newSalt {

        //genera un salt random

        public string Salt = "";
        
        public newSalt(int size) {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            Salt = Convert.ToBase64String(buff);
        }
    }

    class hashIt {

        public string Hash = "";

        //hashea solo el string que se le pasa.
        public hashIt(string toHash) {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(toHash);
            System.Security.Cryptography.SHA256Managed sha256String =
                            new System.Security.Cryptography.SHA256Managed();
            byte[] newhash = sha256String.ComputeHash(bytes);
            Hash = Convert.ToBase64String(newhash);
        }
        //concatena un string y un salt y los hashea juntos.
        public hashIt(string toHash, string salt) {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(toHash + salt);
            System.Security.Cryptography.SHA256Managed sha256String =
                            new System.Security.Cryptography.SHA256Managed();
            byte[] newhash = sha256String.ComputeHash(bytes);
            Hash = Convert.ToBase64String(newhash);
        }
    }
}
