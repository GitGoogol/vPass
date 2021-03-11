using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassElements
{
    public abstract class PassElement
    {
        string chkValue;
        public PassElement(string passParameter) { }
        public abstract string PassCommand { get; }
        public abstract string PassParameter { get; }
        public abstract bool checkElement();
        public string CheckValue
        {
            get { return chkValue; }
            set { chkValue = value; }
        }
    }
}
