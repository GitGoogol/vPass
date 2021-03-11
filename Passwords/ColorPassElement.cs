using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariableData;

namespace Passwords
{
    public class ColorPassElement : PassElement
    {
        private Dictionary<string, string> sData;

        public ColorPassElement(Dictionary<string, string> serverData) :base(serverData)
        {
            sData = serverData;
        }

        override public string PassCommand
        {
            get
            {
                return "Color";
            }

        }
        
        override public string PassType
        {
            get
            {
                return "Farbe";
            }
        }

        override public string[] getAvailableParms()
        {
            List<string> availableParms = new List<string>();
            foreach (string item in sData.Keys)
            {
                availableParms.Add(item);
            }
            return availableParms.ToArray();
        }

        override public string getPassData()
        {
            if (PassParameter != null && PassParameter != "")
                return sData[PassParameter];
            else
                return "";
        }

        public override bool checkElement()
        {
            return String.Compare(CheckValue, getPassData()) == 0 ? true : false;
        }
    }
}
