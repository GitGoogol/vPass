using PassElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    class VarDataHandler
    {
        #region Private Member
        string pPath;
        static Random rnd = new Random();
        MSGLogger msgLogger;
        #endregion

        #region Public Member
        public Dictionary<string, PassElement> varData { get; private set; }
        #endregion

        #region Constructor
        public VarDataHandler(string parmPath, MSGLogger logger)
        {
            msgLogger = logger;
            msgLogger("VarDataHandler: Datenpfade für Codeelemente prüfen");
            if (!Directory.Exists(parmPath)) throw new Exception("Path for variable parameter doesn't exist");
            if (Directory.GetDirectories(parmPath).Length < 1) throw new Exception("At least one directory for parameters must be available");
            pPath = parmPath;
            varData = new Dictionary<string, PassElement>();
        }
        #endregion

        #region Public Methods
        public void generateNewVarData()
        {
            varData.Clear();
            msgLogger("VarDataHandler: evtl. vorhandene variable Daten löschen");
            List<Exception> eList = new List<Exception>();

            foreach (string subDir in Directory.GetDirectories(pPath))
            {
                try
                {
                    PassElement tmpElement = new DynPassElement(Path.GetFileName(subDir));
                    if(!((IUIPassElement)tmpElement).setImgPath(subDir))throw new Exception("Image path could not be set");
                    varData.Add(Path.GetFileName(subDir), tmpElement);  //GetFileName gibt den letzten Teil des Pfades zurück
                }
                catch (Exception e)
                {
                    eList.Add(new Exception("Error at creating pass elements", e));
                }
            }
            if (eList.Count > 0)
            {
                varData.Clear();
                throw new AggregateException(eList);
            }
            else
            {
                msgLogger("VarDataHandler: neue variable Daten erzeugt");
                shuffleDictionary();
                msgLogger("VarDataHandler: variable Daten gemischt");
            }
        }

        #endregion

        #region Private Methods
        private void shuffleDictionary()
        {
            msgLogger("VarDataHandler: variable Daten mischen");
            varData = varData.OrderBy(x => rnd.Next())
              .ToDictionary(item => item.Key, item => item.Value);
        }
        #endregion
    }
}
