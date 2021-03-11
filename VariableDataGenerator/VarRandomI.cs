using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableData
{
    public class VarRandomI : IDataCreator
    {
        #region Private Members
        Random rnd;
        Dictionary<string, string> rndDict;
        #endregion

        #region Public Members
        public string creatorType { get; private set; }
        #endregion

        #region Constructor
        public VarRandomI()
        {
            creatorType = "Random";
            rnd = new Random(System.DateTime.Now.Millisecond);
            rndDict = new Dictionary<string, string>();
        }
        #endregion


        public void createVarData()
        {
            string rndNo;
            rndNo = getValidRndNo();

            for (int i = 65; i <= 90; i++)
            {
                rndDict[((char)i).ToString()] = getVariation(rndNo);
            }
        }

        private string getValidRndNo()
        {
            string tmpCheckNo = "";
            do
            {
                tmpCheckNo = rnd.Next(100, 1000).ToString();
                if (tmpCheckNo[0] == tmpCheckNo[1] && tmpCheckNo[0] == tmpCheckNo[2]) tmpCheckNo = "";
            } while (tmpCheckNo == "");

            return tmpCheckNo;
        }

        private string getVariation(string rndNo)
        {
            if (rndNo.Length != 3) throw new Exception("Zufallszahl muss 3 Stellen haben");
            int varLength = rnd.Next(1, 3);
            string strVariation = "";
            char[] chVariation = new char[] { rndNo[0], rndNo[1], rndNo[2] };
            for (int i = 0; i < varLength; i++)
            {
                strVariation += chVariation[rnd.Next(0, 3)].ToString();
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
