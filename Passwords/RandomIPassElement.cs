using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passwords
{
    public class RandomIPassElement : PassElement
    {
        private Dictionary<string, string> sData;

        public RandomIPassElement(Dictionary<string, string> serverData) : base(serverData)
        {
            sData = serverData;
        }

        override public string PassParameter
        {
            get
            {
                return base.PassParameter;
            }

            set
            {
                string strTmp = value==null ? "":value;
                normalizeValue(ref strTmp);
                base.PassParameter = strTmp;
            }
        }

        private void normalizeValue(ref string strTmp)
        {
            string outString = "";
            for (int i = 0; i < strTmp.Length; i++)
            {
                if (Char.IsLetter(strTmp[i]))
                    outString += strTmp.Substring(i, 1);
            }
            strTmp = outString;
        }

        override public string PassCommand
        {
            get
            {
                return "Rnd";
            }

        }

        override public string PassType
        {
            get
            {
                return "Zufallszahl";
            }
        }

        override public string[] getAvailableParms()
        {
            return new string[] { "" };
        }

        override public string getPassData()
        {
            string outString = "";
            if (PassParameter != null && PassParameter != "")
            {
                for (int i = 0; i < PassParameter.Length; i++)
                {
                    char[] rvsArray;
                    if (Char.IsLower(PassParameter[i]))
                    {
                        rvsArray = sData[PassParameter.ToUpper()[i].ToString()].ToCharArray();
                        Array.Reverse(rvsArray);
                        outString += new string(rvsArray);
                    }
                    else
                        outString += sData[PassParameter[i].ToString()];
                }
                return outString;
            }
            else
                return "";
        }

        public override bool checkElement()
        {
            return String.Compare(CheckValue, getPassData()) == 0 ? true : false;
        }
    }
}
