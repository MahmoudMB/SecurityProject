using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Ceaser : ICryptographicTechnique<string, int>
    {
        public string Encrypt(string plainText, int key)
        {
            //    throw new NotImplementedException();

            string cypherText = "";
            foreach(char c in plainText)
            {
                cypherText += (char)((((c + key) - 97) % 26) + 97);
            }

            return cypherText;
        }

        public string Decrypt(string cipherText, int key)
        {
            //   throw new NotImplementedException();
            string plainText = "";
            string cipherText1 = cipherText.ToLower();
            foreach (char c in cipherText1)
            {

                if (((c - key) - 97)<0)
                    plainText += (char)((((c - key) - 97 + 26) % 26) + 97);
                else 
                plainText += (char)((((c - key) -97) % 26) + 97);

            

            }

            return plainText.ToUpper();

        }

        public int Analyse(string plainText, string cipherText)
        {
            //throw new NotImplementedException();
            string cipherText1 = cipherText.ToLower();
            int e = 0;
            char P = plainText[0];
             char C = cipherText1[0];
        
            int seqP = P - 97;
            int seqC = C - 97;

            if (seqP > seqC)
                e = (26 - (seqP - seqC));
            else
                e = (seqC - seqP);
            return e;

        }
    }
}
