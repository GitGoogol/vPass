using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passwords
{
    public abstract class PassElement
    {
        private string passParameter;
        private string chkValue="";
        //public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler<EventArgs> parmsChanged;
        public abstract string PassCommand { get; }
        public abstract string PassType { get; }
        
        virtual public string PassParameter
        {
            get
            {
                return passParameter;
            }

            set
            {
                passParameter = value == null ? "" : value;

                onRaisParmsChanged(new EventArgs());
            }
        }
        
        public string CheckValue
        {
            get { return chkValue; }
            set { chkValue = value; }
        }
        
        private void onRaisParmsChanged(EventArgs eventArgs)
        {
            if (parmsChanged != null)
            {
                parmsChanged(this, eventArgs);
            }
        }

        public PassElement(Dictionary<string, string> serverData)
        {
        }

        public override string ToString()
        {
            return PassType;
        }
        
        public abstract bool checkElement();
        public abstract string[] getAvailableParms();
        public abstract string getPassData();
    }
}
