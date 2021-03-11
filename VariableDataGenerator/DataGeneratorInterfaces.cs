using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableData
{
    public interface IDataCreator
    {
        string creatorType { get; }
        void createVarData();
        Dictionary<string, string> getVarData();
    }

}
