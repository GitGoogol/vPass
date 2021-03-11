using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableData
{
    public class VarColor:IDataCreator
    {
        #region Private Members
        Random rnd;
        HashSet<int> numbers;
        Dictionary<string, string> colorDict;
        string[] varColors;
        #endregion

        #region Public Members
        public string creatorType { get; private set; }
        #endregion

        #region Constructor
        public VarColor()
        {
            creatorType = "Color";
            rnd = new Random(System.DateTime.Now.Millisecond);
            colorDict = new Dictionary<string, string>();
            numbers = new HashSet<int>();
            varColors = new string[] { "Black", "Red", "Green", "Blue", "White" };
        }
        #endregion


        public void createVarData()
        {
            int[] tmpArray = new int[5];
            while(numbers.Count<5)
            {
                numbers.Add(rnd.Next(0, 5));
            }
            numbers.CopyTo(tmpArray);
            colorDict["A"] = varColors[tmpArray[0]];
            colorDict["E"] = varColors[tmpArray[1]];
            colorDict["I"] = varColors[tmpArray[2]];
            colorDict["O"] = varColors[tmpArray[3]];
            colorDict["U"] = varColors[tmpArray[4]];

        }

        public Dictionary<string, string> getVarData()
        {
            if (colorDict != null)
                return colorDict;
            else
                throw new Exception("create var data was not executed before");
        }
    }
}
