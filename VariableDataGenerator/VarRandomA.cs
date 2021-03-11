using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableData
{

    public class VarRandomA : IDataCreator
    {
        #region Private Members
        Random rnd;
        Dictionary<string, string> rndDict;
        #endregion

        #region Public Members
        public string creatorType { get; private set; }
        #endregion

        #region Constructor
        public VarRandomA()
        {
            creatorType = "RandomA";
            rnd = new Random(System.DateTime.Now.Millisecond);
            rndDict = new Dictionary<string, string>();
        }
        #endregion


        public void createVarData()
        {
            char[] rndAlfa = getRandomChar();
            
            for (int i = 0; i <= 9; i++)
            {
                rndDict[i.ToString()] = getVariation(rndAlfa);
            }
        }

        private char[] getRandomChar()
        {
            char[] resChar = new char[3];
            int[] tmpInt = new int[3];

            int[] offset = new int[] { rnd.Next(0, 2) == 0 ? 65 : 97, rnd.Next(0, 2) == 0 ? 65 : 97, rnd.Next(0, 2) == 0 ? 65 : 97 };
            do
            {
                tmpInt[0] = rnd.Next(0, 26);
                tmpInt[1] = rnd.Next(0, 26);
                tmpInt[2] = rnd.Next(0, 26);
            } while (tmpInt[0] == tmpInt[1] && tmpInt[0] == tmpInt[2]);

            resChar[0] = (char)(tmpInt[0] + offset[0]);
            resChar[1] = (char)(tmpInt[1] + offset[1]);
            resChar[2] = (char)(tmpInt[2] + offset[2]);
            return resChar;
        }

        private string getVariation(char[] rndAlfa)
        {
            int varLength = rnd.Next(1, 3);
            string strVariation = "";
            
            for (int i = 0; i < varLength; i++)
            {
                strVariation += rndAlfa[rnd.Next(0, 3)].ToString();
            }
            return strVariation;

        }

        public Dictionary<string, string> getVarData()
        {
            if (rndDict != null)
                return rndDict;
            else
                throw new Exception("create var data was not executed before");
        }
    }
}
