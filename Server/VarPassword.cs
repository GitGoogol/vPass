using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class VarPassword
    {
        MSGLogger msgLogger;
        List<string[]> varPassword = new List<string[]>();
        
        public event EventHandler<PassElementArgs> elementAdded;
        
        public int elementsCount
        {
            get { return varPassword.Count(); }
        }

        #region Constructor
        public VarPassword(MSGLogger logger)
        {
            msgLogger = logger;       
        }
        #endregion

        public void addElement(string[] passElement)
        {
            //passElement[0]=command; passElement[1]=parameter
            varPassword.Add(passElement);
            PassElementArgs pArgs = new PassElementArgs(passElement[0], passElement[1]);
            onElementAdded(pArgs);
        }
        public string[] getElement(int intIndex)
        {
            if (intIndex >= varPassword.Count || intIndex<0) throw new Exception("Wrong index");
            return varPassword[intIndex];
        }
        public void clearElements()
        {
            varPassword.Clear();
        }

        private void onElementAdded(PassElementArgs eventArgs)
        {
            if (elementAdded != null)
            {
                elementAdded(this, eventArgs);
            }
        }
    }

    public class PassElementArgs:EventArgs
    {
        public string varCommand { get; private set; }
        public string varParameter { get; private set; }
        
        public PassElementArgs(string vCommand, string vParameter)
        {
            varCommand = vCommand;
            varParameter = vParameter;
        }
    }
}
