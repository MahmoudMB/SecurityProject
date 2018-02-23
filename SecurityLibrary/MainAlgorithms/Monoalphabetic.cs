using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Monoalphabetic : ICryptographicTechnique<string, string>
    {
        public string Analyse(string plainText, string cipherText)
        {
            Dictionary<char, char> dic = new Dictionary<char, char>();
            string tmp = "";
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            char[] al = alpha.ToCharArray();

            foreach (char e in alpha)
            {
                dic[e] = e;
            }

        

            string p = plainText.ToLower();
            string c = cipherText.ToLower();
            string tmp2 = "";
            for (int i = 0; i < p.Length; i++)
            {
                    dic[p[i]] = c[i];

                if (!tmp.Contains(p[i]))
                    tmp += p[i];

                if (!tmp2.Contains(c[i]))
                    tmp2 += c[i];

             
            }


;            foreach(char a in alpha)
            {

                if (!tmp.Contains(a))
                {
                    dic[a] = '0';
                }

            }

            string tmp4 = "";
            foreach(char d in alpha)
            {

                if (!tmp2.Contains(d))
                    tmp4 += d;
            }

            int j = 0;

            string tmp3 = "";
            foreach (KeyValuePair<char, char> f in dic)
            {
                if (f.Value == '0')
                {

                    tmp3 += f.Key;
                
                    
                }
               
           
          
            }

            foreach (char r in tmp3)
            {

                dic[r] = tmp4[j];
                j++;
            }

            string key = "";
            foreach (KeyValuePair<char, char> f in dic)
            {
                

                    key += f.Value;
            }
           


            return key;
      
        }

        public string Decrypt(string cipherText, string key)
        {
            //throw new NotImplementedException();

            string plainText = "";
            foreach (char c in cipherText.ToLower())
            {
                for(int i = 0;i<key.Length;i++)
                {
                    if (c==key[i])
                    {
                        plainText += (char)(i + 97);
                        break;
                    }
                }

            }
            return plainText;


        }

        public string Encrypt(string plainText, string key)
        {
            //    throw new NotImplementedException();

            string cypherText = "";
            foreach(char c in plainText)
            {
                int seq = c - 97;

                cypherText += key[seq];

            }

            return cypherText;
        }

        /// <summary>
        /// Frequency Information:
        /// E   12.51%
        /// T	9.25
        /// A	8.04
        /// O	7.60
        /// I	7.26
        /// N	7.09
        /// S	6.54
        /// R	6.12
        /// H	5.49
        /// L	4.14
        /// D	3.99
        /// C	3.06
        /// U	2.71
        /// M	2.53
        /// F	2.30
        /// P	2.00
        /// G	1.96
        /// W	1.92
        /// Y	1.73
        /// B	1.54
        /// V	0.99
        /// K	0.67
        /// X	0.19
        /// J	0.16
        /// Q	0.11
        /// Z	0.09
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns>Plain text</returns>
        public string AnalyseUsingCharFrequency(string cipher)
        {
            //throw new NotImplementedException();

            string temparr = "";
            int count = 0;
            
            double[] numberOfRep = new double[26];
            for (int i = 0; i < cipher.Length; i++)
            {
               
                double numberofChars = 0.0;
                if (count == 26)
                    break;

                for (int j=0;j<cipher.Length;j++)
                {
                    if (!temparr.Contains(cipher[i]))
                    {
                        
                        if (cipher[i] == cipher[j])
                            numberofChars++;
                    }

                }
                numberOfRep[count] = numberofChars / 26;
                temparr += cipher[i];
                count++;


            }




            return null;
        }
    }
}
