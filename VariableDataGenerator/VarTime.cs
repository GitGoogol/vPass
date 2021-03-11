using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace VariableData
{
    public class VarTime : IDataCreator
    {
        #region Private Members
        DateTime dt;
        Dictionary<string, string> timeDict;
        DateTimeFormatInfo dtfi;
        #endregion

        #region Public Members
        public string creatorType { get; private set; }
        #endregion

        #region Constructor
        public VarTime()
        {
            creatorType = "Timedate";
            dt = DateTime.Now;
            timeDict = new Dictionary<string, string>();
            dtfi = new DateTimeFormatInfo();
        }
        #endregion

        public void createVarData()
        {
            timeDict["Day"] = dtfi.GetDayName(dt.DayOfWeek);
            timeDict["Month"] = dtfi.GetMonthName(dt.Month);
            timeDict["Year"] = dt.Year.ToString();
            timeDict["Hour"] = dt.Hour.ToString();
            timeDict["Minute"] = dt.Minute.ToString();
            timeDict["Second"] = dt.Second.ToString();
            timeDict["Millisecond"] = dt.Millisecond.ToString();
        }

        public Dictionary<string, string> getVarData()
        {
            if (timeDict != null)
                return timeDict;
            else
                throw new Exception("create var data was not executed before");
        }
    }
}
