using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [Serializable]
    public class VarPassword
    {
        List<string[]> varPassword = new List<string[]>();

        public int elementsCount
        {
            get { return varPassword.Count(); }
        }

        public void addElement(string[] passElement)
        {
            //passElement[0]=command; passElement[1]=parameter
            varPassword.Add(passElement);
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
        
    }
}
