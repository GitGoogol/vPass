using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace PassElements
{
    public class FixPassElement : PassElement
    {
        private string fixPartRaw;
        private string pParameter;
                       
        override public string PassCommand
        {
            get
            {
                return "Fix";
            }

        }

        public override string PassParameter
        {
            get
            {
                return pParameter;
            }
        }

        public FixPassElement(string passParameter):this(passParameter, true)
        {
            
        }

        public FixPassElement(string passParameter, bool doEncryption):base(passParameter)
        {
            if (doEncryption)
            {
                fixPartRaw = passParameter == null ? "" : passParameter;
                pParameter = cryptSHA1(fixPartRaw);
            }
            else
            {
                fixPartRaw = null;
                pParameter = passParameter;
            }

        }

        public override bool checkElement()
        {
            if (CheckValue != null && CheckValue != "")
                return String.Compare(cryptSHA1(CheckValue), pParameter) == 0 ? true : false;
            else
                return pParameter == "" ? true : false;
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
