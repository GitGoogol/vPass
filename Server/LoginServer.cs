using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using VariableData;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;
using System.Xml;

namespace Server
{
    public delegate void MSGLogger(string message);
    public class LoginServer
    {
        #region Private Members
        VarDataHandler pDH;
        Dictionary<Type, VarDataHandler> serverData;
        MSGLogger msgLogger;
        private VarPassword vPassword;
        SecureString secPassString = new SecureString();
        #endregion

        #region Public Members


        public VarPassword varPassword
        {
            get { return vPassword; }
            set { vPassword = value; }
        }

        public bool varDataAvailable { get; private set; }

        #endregion

        #region Constructor
        public LoginServer(MSGLogger messageLogger)
        {
            msgLogger = messageLogger;
            vPassword = new VarPassword();
            serverData = new Dictionary<Type, VarDataHandler>();
            varDataAvailable = false;
            readConfigData();
        }
        #endregion

        #region Public Methods
        public void initServer()
        {
            //vorhandene Daten löschen
            serverData.Clear();
            msgLogger("evtl. vorhandene Zufallsdaten gelöscht");

            //passLoginServer = new LoginServer(msgLogger);
            createVarData(new VarRandomI());
            msgLogger("neue Zufallszahlen erzeugt");
            createVarData(new VarTime());
            msgLogger("neue Zeit-/Datumsinformationen erzeugt");
            createVarData(new VarColor());
            msgLogger("neue Farbzuweisungen erstellt");
            createVarData(new VarRandomA());
            msgLogger("neue Zufallsbuchstaben erstellt");
        }

        public void fillVarDataDisplay(GroupBox tlpGroupBox)
        {
            if (serverData != null && varDataAvailable)
            {
                foreach (var item in tlpGroupBox.Controls)
                {
                    if (item.GetType() == typeof(TableLayoutPanel))
                    {
                        //((TableLayoutPanel)item).Controls.Clear();
                        serverData[(Type)((TableLayoutPanel)item).Tag].fillLayoutPanel((TableLayoutPanel)item);
                        msgLogger("Tabelle für " + ((Type)((TableLayoutPanel)item).Tag).ToString() + " in Groupbox " + tlpGroupBox.Name + " gefüllt");
                    }
                }
            }

        }

        public Dictionary<string, string> getServerData(Type creatorType)
        {
            if (serverData == null) throw new Exception("No valid server data available");
            return ((VarDataHandler)serverData[creatorType]).varData;
        }

        public void getDecryptedPasswordData(TextBox txtBox)
        {
            if (vPassword.elementsCount < 1)
            {
                msgLogger("Kein Passwortfile generiert. Zu wenig Elemente um etwas darzustellen");
                return;
            }
            txtBox.Clear();
            msgLogger("Darstellung für entschlüsselte Passwortdatei gelöscht");
            for (int i = 0; i < varPassword.elementsCount; i++)
            {
                txtBox.AppendText((varPassword.getElement(i))[0] + " (" + (varPassword.getElement(i))[1] + ")" + Environment.NewLine);
            }
            msgLogger("Darstellung für entschlüsselte Passwortdatei gefüllt");
        }

        public bool generatePasswordFile()
        {
            if (vPassword.elementsCount < 1)
            {
                msgLogger("Kein Passwortfile generiert. Zu wenig Elemente");
                return false;
            }
            IFormatter binFormatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();

            using (FileStream fileStream = new FileStream("rawPassword.txt", FileMode.Create))
            {
                msgLogger("Öffne Filestream zum Erzeugen eines NICHT verschlüsselten Passwortfiles");
                binFormatter.Serialize(fileStream, varPassword);
                msgLogger("Serialisierung und unverschlüsseltes Schreiben in File");
            }
            binFormatter.Serialize(memStream, varPassword);
            msgLogger("Serialisierung Passwort Objekt in RAM");

            encryptStream(memStream, "encryptedPassword.bin", secPassString);
            msgLogger("Passwortobjekt serialisiert und verschlüsselt and Filestream übergeben");
            memStream.Close();

            MessageBox.Show("unverschlüsselte (rawPasswort.txt) und verschlüsselte (encryptedPassword.bin) Datei gespeichert");
            return true;
        }

        public bool loadCheckPasswordFile()
        {
            if (!File.Exists("encryptedPassword.bin"))
            {
                msgLogger("keine Datei (encryptedPassword.bin) vorhanden");
                return false;
            }
            using (FileStream fileStream = new FileStream("encryptedPassword.bin", FileMode.Open, FileAccess.Read))
            {
                msgLogger("Öffne Filestream zum Lesen eines Passwortfiles");
                IFormatter binFormatter = new BinaryFormatter();
                MemoryStream memOutStream = new MemoryStream();
                try
                { DecryptFile(fileStream, memOutStream, secPassString); }
                catch
                {
                    fileStream?.Close();
                    memOutStream?.Close();
                    msgLogger("verschlüsselte Datei konnte nicht gelesen werden");
                    return false; 
                }
                msgLogger("Passwortfile entschlüsselt und in RAM geladen");

                memOutStream.Seek(0, SeekOrigin.Begin);

                varPassword = (VarPassword)binFormatter.Deserialize(memOutStream);
                msgLogger("Passwortdaten deserialisiert und Passwortobjekt erzeugt");

                fileStream.Close();
                memOutStream.Close();

            }

            msgLogger("verschlüsselte Datei eingelesen und entschlüsselt");
            return true;
        }

        public bool checkPassword(string text)
        {
            VarDataChecker vDC = new VarDataChecker(this);
            msgLogger("Aufruf Passwortchecker");
            return vDC.checkPassword(text);

        }
        #endregion

        #region Private Methods

        private void readConfigData()
        {
            //Stichwort DPAPI DataProtectionApplicationProgrammingInterface
            //http://www.cool-it.at/blog/September-2012/Passworter-in-App-Config-verschlusselt-ablegen
            secPassString.Clear();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection section = config.GetSection("applicationSettings/protectedSection");
            if (section != null)
            {
                if (!section.SectionInformation.IsProtected && !section.ElementInformation.IsLocked)
                {
                    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    section.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
                var settingsXml = new XmlDocument();
                settingsXml.LoadXml(section.SectionInformation.GetRawXml());
                foreach (char pChar in settingsXml.SelectSingleNode("//setting[@name='Password']/value").InnerText)
                {
                    secPassString.AppendChar(pChar);
                }
            }
        }

        private void createVarData(IDataCreator iDC)
        {
            pDH = new VarDataHandler();
            msgLogger("Start Generierung variable Daten: " + iDC.GetType().ToString());
            pDH.setDataType(iDC);
            msgLogger("variable Daten generiert: " + iDC.GetType().ToString());
            serverData.Add(iDC.GetType(), pDH);
            varDataAvailable = true;
        }

        private void encryptStream(MemoryStream fsInput, string sOutputFilename, SecureString sKey)
        {
            using (FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write))
            {
                AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider();
                aesProvider.Mode = CipherMode.CBC;
                aesProvider.Key = ASCIIEncoding.ASCII.GetBytes(new System.Net.NetworkCredential(string.Empty, sKey).Password);
                aesProvider.IV = ASCIIEncoding.ASCII.GetBytes(new System.Net.NetworkCredential(string.Empty, sKey).Password.Substring(4, 16));
                ICryptoTransform aesencrypt = aesProvider.CreateEncryptor();
                CryptoStream cryptostream = new CryptoStream(fsEncrypted, aesencrypt, CryptoStreamMode.Write);


                byte[] bytearrayinput = fsInput.ToArray();
                cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Close();
                fsInput.Close();
                fsEncrypted.Close();
            }
            msgLogger("Aes Verschlüsselung des serialisierten Objekts");
        }

        private void DecryptFile(FileStream fsread, MemoryStream fsDecrypted, SecureString sKey)
        {
            AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider();
            aesProvider.Mode = CipherMode.CBC;
            //Set secret key For AES algorithm.
            aesProvider.Key = ASCIIEncoding.ASCII.GetBytes(new System.Net.NetworkCredential(string.Empty, sKey).Password);
            //Set initialization vector.
            aesProvider.IV = ASCIIEncoding.ASCII.GetBytes(new System.Net.NetworkCredential(string.Empty, sKey).Password.Substring(4, 16));

            //Create a AES decryptor from the AES instance.
            ICryptoTransform aesdecrypt = aesProvider.CreateDecryptor();

            //Create crypto stream set to read and do a 
            //AES decryption transform on incoming bytes.
            CryptoStream cryptostreamDecr = new CryptoStream(fsread, aesdecrypt, CryptoStreamMode.Read);
            try
            {
                cryptostreamDecr.CopyTo(fsDecrypted);
            }
            catch (Exception e)
            {
                throw new Exception("Datei nicht vorhanden oder beschädigt", e);
            }
            finally
            {
                cryptostreamDecr?.Close();
            }
            msgLogger("Aes Entschlüsselung des verschlüsselten Files");
        }



        #endregion
    }

}
