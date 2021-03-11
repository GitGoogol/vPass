using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassElements
{
    public class DynPassElement : PassElement, IUIPassElement
    {
        #region Private Member
        readonly int MAXDATALENGTH = 4;
        readonly int MINDATALENGTH = 2;
        string pParameter;
        string passData;
        string imgPath = "";
        string[] imgFiles;
        List<String> validChars;
        static Random rnd = new Random();
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
                return "Dyn";
            }

        }

        public string PassData
        {
            get { return passData; }
            set { passData = value; }
        }

        #endregion

        #region Constructor
        public DynPassElement(string passParameter) : base(passParameter)
        {
            validChars = new List<string>();
            fillCharsList();
            generatePassData();
            pParameter = passParameter;
        }
        #endregion

        #region Public Methods
        public void generatePassData()
        {
            passData = "";
            int varLen = rnd.Next(MINDATALENGTH, MAXDATALENGTH + 1);
            for (int i = 0; i < varLen; i++)
            {
                passData += validChars[rnd.Next(0, validChars.Count)];
            }

        }

        public override bool checkElement()
        {
            if (CheckValue != null && CheckValue != "")
                return String.Compare(CheckValue, passData) == 0 ? true : false;
            else
                return pParameter == "" ? true : false;
        }
        #endregion

        #region Private Methods
        private void fillCharsList()
        {
            int nO = 0;
            for (int i = 65; i <= 90; i++)
            {
                validChars.Add(((char)i).ToString());    //capital letters
                validChars.Add(((char)(i + 32)).ToString());//small letters
                validChars.Add((nO++).ToString());  //numbers
                nO = nO == 10 ? 0 : nO;
            }
            validChars.Add("!");
            validChars.Add("?");
            validChars.Add("#");
            validChars.Add("@");
            validChars.Add("<");
            validChars.Add(">");
        }

        public string getRandomImgPath()
        {
            if (imgPath == "") throw new Exception("No valid image path available. Use the set-method first");
            return (imgFiles[rnd.Next(0, imgFiles.Length)]);
        }

        public bool setImgPath(string imagePath)
        {
            if (!Directory.Exists(imagePath)) return false;
            var iFiles = Directory.EnumerateFiles(imagePath)
                .Where(s => s.ToLower().EndsWith(".jpg"));
            imgFiles = iFiles.ToArray();
            if (imgFiles.Length < 1) return false;
            else imgPath = imagePath;
            return true;
        }
        #endregion
    }
}
