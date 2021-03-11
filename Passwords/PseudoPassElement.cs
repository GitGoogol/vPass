using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassElements
{
    public class PseudoPassElement:PassElement
    {

        #region Private Member
        readonly int MINPSEUDOLENGTH = 16;
        readonly int MAXPSEUDOLENGTH = 32;
        static Random rnd;
        string pParameter;
        #endregion

        #region Public Member
        override public string PassParameter
        {
            get
            {
                return pParameter;
            }
        }

        override public string PassCommand
        {
            get
            {
                return "Pseudo";
            }
        }
        #endregion

        #region Constructor
        public PseudoPassElement() : base("")
        {
            rnd = new Random();
            pParameter = generateRandomParm();
        }
        #endregion

        #region Public Methods
        
        public override bool checkElement()
        {
            return true;
        }
        #endregion

        #region Private Methods
        private string generateRandomParm()
        {
            string parmData = "";
            int varLen = rnd.Next(MINPSEUDOLENGTH, MAXPSEUDOLENGTH+ 1);
            for (int i = 0; i < varLen; i++)
            {
                parmData += ((char)rnd.Next(32, 127)).ToString();
            }
            return parmData;
        }
        #endregion
    }
}
