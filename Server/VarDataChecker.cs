using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassElements;

namespace Server
{
    class VarDataChecker
    {
        Dictionary<string, PassElement> varData;
        VarPassword varPassword;
        MSGLogger msgLogger;
        public VarDataChecker(Dictionary<string,PassElement> varServerData, VarPassword varServerPassword, MSGLogger logger)
        {
            msgLogger = logger;
            varData = varServerData;
            varPassword = varServerPassword;
        }

        public bool checkPassword(string userVarPassword)
        {

            if (userVarPassword.Length == 0) return false;
            int fixElementLength = 0;
            int fixElementStart = 0;
            int peekPosition = 0;
            string valPassword="";

            msgLogger("PasswordChecker: temporäre Passwortelemente gemäß varPassword anlegen");
            PassElement[] pElements = new PassElement[varPassword.elementsCount];
            for (int i = 0; i < varPassword.elementsCount; i++)
                pElements[i] = getPassElement(varPassword.getElement(i));

            for (int i = 0; i < pElements.Length; i++)
            {
                if (peekPosition >= userVarPassword.Length) break;
                
                if(pElements[i].GetType() != typeof(FixPassElement))
                {
                    
                    if (((DynPassElement)pElements[i]).PassData.Length > userVarPassword.Substring(peekPosition).Length) break;
                    msgLogger("PasswordChecker: dynamisches Element merken: " + userVarPassword.Substring(peekPosition, ((DynPassElement)pElements[i]).PassData.Length));
                    pElements[i].CheckValue = userVarPassword.Substring(peekPosition, ((DynPassElement)pElements[i]).PassData.Length);
                    peekPosition = peekPosition + ((DynPassElement)pElements[i]).PassData.Length;
                }
                else if (pElements[i].GetType() == typeof(FixPassElement) && i== varPassword.elementsCount-1)
                {
                    msgLogger("PasswordChecker: fixes Element an letzer Position merken: " + userVarPassword.Substring(peekPosition));
                   pElements[i].CheckValue = userVarPassword.Substring(peekPosition);
                }
                else if(pElements[i].GetType() == typeof(FixPassElement) && i< varPassword.elementsCount-1)
                {
                    fixElementLength = 0;
                    fixElementStart = peekPosition;
                    do
                    {
                        pElements[i].CheckValue = userVarPassword.Substring(fixElementStart, fixElementLength);
                        peekPosition = (fixElementStart + fixElementLength);
                        fixElementLength++;
                    } while (!pElements[i].checkElement() && peekPosition<userVarPassword.Length);
                    if (peekPosition >= userVarPassword.Length && !pElements[i].checkElement()) break;
                    msgLogger("PasswordChecker: fixes Element merken: " + userVarPassword.Substring(fixElementStart, fixElementLength-1));
                }
                else
                {
                    throw new Exception("Element kann nicht ausgewertet werden");
                }
            }

            msgLogger("PasswordChecker: vergleiche einzelne Elemente mit erzeugten Klartextelementen");
            foreach (PassElement item in pElements)
            {
                if (!item.checkElement()) return false;
                valPassword += item.CheckValue;
            }

            msgLogger("PasswordChecker: vergleiche Usereingabe mit generiertem Passwort: " + (String.Compare(userVarPassword, valPassword) == 0 ? "Übereinstimmung" : "Falsch"));
            return String.Compare(userVarPassword, valPassword) == 0 ? true : false;
        }

        private bool compareElements(PassElement passElement, string userVarPassword, ref int startPos)
        {
            if (passElement.PassCommand == "Fix")
            {
                if (passElement.PassParameter == FixPassElement.cryptSHA1(userVarPassword))
                {
                    startPos = startPos + passElement.PassParameter.Length;
                    return true;
                }

            }
            else
            {
                if (((DynPassElement)passElement).PassData.Length <= userVarPassword.Substring(startPos).Length)
                {
                    if (((DynPassElement)passElement).PassData == userVarPassword.Substring(startPos, ((DynPassElement)passElement).PassData.Length))
                    {
                        startPos = startPos + ((DynPassElement)passElement).PassData.Length;
                        return true;
                    }
                }
            }
            return false;
        }

        private PassElement getPassElement(string[] v)
        {
            PassElement pE;
            switch (v[0])
            {
                case "Fix":
                    pE = new FixPassElement(v[1],false);
                    break;
                case "Dyn":
                    pE = varData[v[1]];
                    break;
                default:
                    throw new Exception("Kein gültiges Passwortelement");
            }
            return pE;
        }

    }
}
