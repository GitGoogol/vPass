using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Passwords
{
    public class FixPassElement : PassElement
    {
        private string fixPartRaw;

        private Dictionary<string,string> sData;

        public FixPassElement(Dictionary<string, string> serverData) : base(serverData)
        {
            sData = serverData;
        }
        
        public string FixPartRaw
        {
            get { return fixPartRaw; }
            set
            {
                fixPartRaw = value == null ? "" : value;
                PassParameter = cryptSHA1(fixPartRaw);
            }
        }
        
        override public string PassCommand
        {
            get
            {
                return "Fix";
            }

        }
        
        override public string PassType
        {
            get
            {
                return "Fixanteil";
            }
        }

        override public string[] getAvailableParms()
        {
            return new string[] { "" };

        }


        override public string getPassData()
        {

            if (PassParameter != null && PassParameter != "")
                return FixPartRaw;
            else
                return "";

        }

        public override bool checkElement()
        {
            return String.Compare(cryptSHA1(CheckValue), PassParameter) == 0 ? true : false;
        }

        public static string cryptSHA1(string dataToCrypt)
        {
            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //create new instance
            using (SHA1 sha1 = SHA1.Create())
            {
                //convert the input text to array of bytes
                byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(dataToCrypt));

                //loop for each byte and add it to StringBuilder
                for (int i = 0; i < hashData.Length; i++)
                {
                    returnValue.Append(hashData[i].ToString());
                }
            }
            // return hexadecimal string
            return returnValue.ToString();
        }
    }
}
