using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Passwords;
using VariableData;

namespace Server
{
    class VarDataChecker
    {
        LoginServer passLoginServer;

        public VarDataChecker(LoginServer loginServer)
        {
            passLoginServer = loginServer;
        }

        public bool checkPassword(string userVarPassword)
        {
            ////Problem wird auftauchen wenn der Fixanteil am Schluss kommt

            if (userVarPassword.Length == 0) return false;
            int fixElementLength = 0;
            int fixElementStart = 0;
            int peekPosition = 0;
            string valPassword="";

            PassElement[] pElements = new PassElement[passLoginServer.varPassword.elementsCount];
            for (int i = 0; i < passLoginServer.varPassword.elementsCount; i++)
                pElements[i] = getPassElement(passLoginServer.varPassword.getElement(i));

            for (int i = 0; i < pElements.Length; i++)
            {
                if (peekPosition >= userVarPassword.Length) break;
                
                if(pElements[i].GetType()!=typeof(FixPassElement) )
                {  
                    if (pElements[i].getPassData().Length > userVarPassword.Substring(peekPosition).Length) break;      
                    pElements[i].CheckValue = userVarPassword.Substring(peekPosition, pElements[i].getPassData().Length);
                    peekPosition = peekPosition + pElements[i].getPassData().Length;
                }
                else if (pElements[i].GetType() == typeof(FixPassElement) && i== passLoginServer.varPassword.elementsCount-1)
                {
                    pElements[i].CheckValue = userVarPassword.Substring(peekPosition);
                }
                else if(pElements[i].GetType() == typeof(FixPassElement) && i< passLoginServer.varPassword.elementsCount-1)
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
                }
                else
                {
                    throw new Exception("Element kann nicht ausgewertet werden");
                }
            }

            foreach (PassElement item in pElements)
            {
                if (!item.checkElement()) return false;
                valPassword += item.CheckValue;
            }

            return String.Compare(userVarPassword, valPassword) == 0 ? true : false;
        }

        private bool compareElements(PassElement passElement, string userVarPassword, ref int startPos)
        {
            if (passElement.PassCommand == "Fix")
            {
                if (passElement.getPassData() == FixPassElement.cryptSHA1(userVarPassword))
                {
                    startPos = startPos + passElement.PassParameter.Length;
                    return true;
                }

            }
            else
            {
                if (passElement.getPassData().Length <= userVarPassword.Substring(startPos).Length)
                {
                    if (passElement.getPassData() == userVarPassword.Substring(startPos, passElement.getPassData().Length))
                    {
                        startPos = startPos + passElement.getPassData().Length;
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
                    pE = new FixPassElement(new Dictionary<string, string>());
                    break;
                case "Rnd":
                    pE = new RandomIPassElement(passLoginServer.getServerData(typeof(VarRandomI)));
                    break;
                case "Timedate":
                    pE = new TimedatePassElement(passLoginServer.getServerData(typeof(VarTime)));
                    break;
                case "Color":
                    pE = new ColorPassElement(passLoginServer.getServerData(typeof(VarColor)));
                    break;
                case "RndA":
                    pE = new RandomAPassElement(passLoginServer.getServerData(typeof(VarRandomA)));
                    break;
                default:
                    throw new Exception("Kein gültiges Passwortelement");
            }
            pE.PassParameter = v[1];
            return pE;
        }
    }
}
