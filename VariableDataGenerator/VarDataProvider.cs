using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VariableData
{
    
    public abstract class VarDataProvider
    {
        #region Private Members
        IDataCreator dataCreator;
        #endregion

        #region Contstructor
        public VarDataProvider()
        {}
        #endregion

        #region Public Methods
        public Dictionary<string,string> generateVarData()
        {
            dataCreator.createVarData();
            return dataCreator.getVarData();
        }

        public void setDataCreator(IDataCreator iDC)
        {
            dataCreator = iDC;
        }
        #endregion
    }
}
