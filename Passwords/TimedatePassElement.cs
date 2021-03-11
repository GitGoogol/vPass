using System;
using System.Collections.Generic;
using VariableData;

namespace Passwords
{
    public class TimedatePassElement : PassElement
    {
        private Dictionary<string, string> sData;

        public TimedatePassElement(Dictionary<string, string> serverData) :base(serverData)
        {
            sData = serverData;
        }

        override public string PassCommand
        {
            get
            {
                return "Timedate";
            }

        }
        
        override public string PassType
        {
            get
            {
                return "Zeit/Datum";
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
