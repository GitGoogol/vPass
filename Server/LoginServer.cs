using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;
using System.Xml;
using PassElements;

namespace Server
{
    public class LoginServer
    {
        #region Private Members
        readonly string IMGPATH = @".\imgs\";
        readonly int AESPASSLENGTH = 32;
        readonly string AESFILLSTRING = "&JHI-l498.,a7*/-2+#+h heG88anz8GT/%E/&*kl4(/&T4//tgeH6Gg78dz+*1-*+asg5§hf74fH(g34gf7/%Fp%GF8";
        VarDataHandler vDataHandler;
        UIHandler uiHandler;
        MSGLogger msgLogger;
        private VarPassword vPassword;
        private string appMode;
        SecureString secPassString = new SecureString();
        #endregion

        #region Public Members
        public string passwordCode { get; private set; }
        public string passwordResult { get; private set; }
        public bool varDataAvailable { get; private set; }
        public VarPassword varPassword
        {
            get { return vPassword; }
            set { vPassword = value; }
        }
        public string applicationMode
        {
            get { return appMode; }
            set
            {
                appMode = value;
                uiHandler.appMode = appMode;
                msgLogger("Server: Application Mode gewechselt: " + appMode);
            }
        }
        #endregion

        #region Constructor
        public LoginServer(Form PassUIForm)
        {
            varDataAvailable = false;
            uiHandler = new UIHandler(PassUIForm);
            msgLogger = uiHandler.writeLog;
            msgLogger("Server: UIHandler Instanz erstellt");
            vPassword = new VarPassword(msgLogger);
            msgLogger("Server: VarPassword Instanz erstellt");
            vDataHandler = new VarDataHandler(IMGPATH, msgLogger);
            msgLogger("Server: VarDataHandler Instanz erstellt mit Pfad: " + IMGPATH);
            //uiHandler = new UIHandler(PassUIForm);
            //msgLogger = uiHandler.writeLog;
            //msgLogger("Server: UIHandler Instanz erstellt");
            uiHandler.elementAddRequest += addElementHandler;
            msgLogger = uiHandler.writeLog;
            msgLogger("Server: Konfigurationsdaten einlesen");
            readConfigData();
            msgLogger("Server: Konfigurationsdaten eingelesen");
        }
        #endregion

        #region Public Methods
        public bool setCustomCaptchaFont(string fontPath)
        {
            return uiHandler.setCustomCaptchaFont(fontPath);
        }

        public void initServer()
        {
            msgLogger("Server: Init Server");
            //vorhandene Daten löschen und neue erzeugen
            uiHandler.initDisplay();
            vDataHandler.generateNewVarData();
            varDataAvailable = true;
        }

        public void reloadVarDataDisplay()
        {
            initServer();
            if (varDataAvailable)
            {
                msgLogger("Server: Flow Panel mit variablen Daten füllen");
                uiHandler.fillLayoutPanel(vDataHandler.varData);
            }

        }

        public string getVarServerData(string parmString)
        {
            msgLogger("Server: variable Daten abrufen");
            return ((DynPassElement)vDataHandler.varData[parmString]).PassData;
        }

        public void getDecryptedPasswordData(TextBox txtBox)
        {
            if (vPassword.elementsCount < 1)
            {
                msgLogger("Server: Kein Passwortfile generiert. Zu wenig Elemente um etwas darzustellen");
                return;
            }
            txtBox.Clear();
            msgLogger("Server: Darstellung für entschlüsselte Passwortdatei gelöscht");

            txtBox.AppendText(passwordCode);
            msgLogger("Server: Darstellung für entschlüsselte Passwortdatei gefüllt");
        }

        public bool generatePasswordFile()
        {
            if (passwordCode == null || passwordCode == "")
            {
                msgLogger("Server: Kein Passwortfile generiert. Zu wenig Elemente");
                return false;
            }
            if (!parsePassCode())
            {
                msgLogger("Server: Error at parsing password code for file generation");
                return false;
            }

            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(passwordCode));
            msgLogger("Server: Serialisierung Passwort Objekt in RAM");

            File.WriteAllText("rawPassword.txt", passwordCode);
            msgLogger("Server: Unverschlüsseltes Passwortfile schreiben");

            encryptStream(memStream, "encryptedPassword.bin", secPassString);
            msgLogger("Server: Passwortobjekt serialisiert und verschlüsselt and Filestream übergeben");
            memStream.Close();

            MessageBox.Show("unverschlüsselte (rawPasswort.txt) und verschlüsselte (encryptedPassword.bin) Datei gespeichert");
            return true;
        }

        public bool loadCheckPasswordFile()
        {
            if (!File.Exists("encryptedPassword.bin"))
            {
                msgLogger("Server: keine Datei (encryptedPassword.bin) vorhanden");
                return false;
            }
            using (FileStream fileStream = new FileStream("encryptedPassword.bin", FileMode.Open, FileAccess.Read))
            {
                msgLogger("Server: Öffne Filestream zum Lesen eines Passwortfiles");
                MemoryStream memOutStream = new MemoryStream();
                try
                { DecryptFile(fileStream, memOutStream, secPassString); }
                catch
                {
                    fileStream?.Close();
                    memOutStream?.Close();
                    msgLogger("Server: verschlüsselte Datei konnte nicht gelesen werden");
                    return false;
                }
                msgLogger("Server: Passwortfile entschlüsselt und in RAM geladen");

                memOutStream.Seek(0, SeekOrigin.Begin);
                passwordCode = Encoding.ASCII.GetString(memOutStream.ToArray());
                msgLogger("Server: Passwortcode eingelesen und Stream in String konvertiert");
                if (!parsePassCode()) return false;

                msgLogger("Server: Passwortdaten deserialisiert und Passwortobjekt erzeugt");

                fileStream.Close();
                memOutStream.Close();

            }

            msgLogger("Server: verschlüsselte Datei eingelesen und entschlüsselt");
            return true;
        }

        public bool checkPassword(string text)
        {
            VarDataChecker vDC = new VarDataChecker(vDataHandler.varData, varPassword, msgLogger);
            msgLogger("Server: Aufruf Passwortchecker");
            return vDC.checkPassword(text);

        }
        #endregion

        #region Private Methods

        private bool parsePassCode()
        {            
            msgLogger("Server: Lösche evtl. vorhandenen Passwort Code");
            varPassword.clearElements();
            msgLogger("Server: Parse Passwort Code");
            if (passwordCode == null || passwordCode == "") return false;
            string[] tmpCode = passwordCode.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string codeItem in tmpCode)
            {
                string[] tmpCodeElement = codeItem.Split(')')[0].Split('(');
                varPassword.addElement(tmpCodeElement);
            }
            return true;
        }

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
                    msgLogger("Server: Protected section in konfigurationsdatei noch nicht verschlüsselt");
                    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    section.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                    msgLogger("Server: Protected section verschlüsselt und gespeichert");
                }
                var settingsXml = new XmlDocument();
                settingsXml.LoadXml(section.SectionInformation.GetRawXml());
                msgLogger("Server: Konfigurationsdatei entschlüsseln und SecureString zuweisen");
                foreach (char pChar in settingsXml.SelectSingleNode("//setting[@name='Password']/value").InnerText)
                {
                    if (secPassString.Length < AESPASSLENGTH)
                        secPassString.AppendChar(pChar);
                }
                int charPos = 0;
                while (secPassString.Length<AESPASSLENGTH && charPos<AESFILLSTRING.Length)
                {
                    secPassString.AppendChar(AESFILLSTRING[charPos++]);
                }
            }
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
            msgLogger("Server: Aes Verschlüsselung des serialisierten Objekts");
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
            msgLogger("Server: Aes Entschlüsselung des verschlüsselten Files");
        }

        #endregion

        #region EventHandler
        private void addElementHandler(object sender, PassEventArgs e)
        {
            msgLogger("Server: Request update Elemente");
            passwordCode = e.codeText;
            passwordResult = e.resultText;
        }
        #endregion
    }

}
