using PassElements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public delegate void MSGLogger(string message);
    class UIHandler
    {
        #region Private Members
        static Random rnd = new Random();
        FlowLayoutPanel varPassPanel, varDataPanel;
        TextBox resultBox;
        TextBox codeBox;
        Button delButton;
        Form uiForm;
        Stopwatch sW;
        MSGLogger msgLogger;
        TrackBar imgSizer;
        GroupBox grpQueryDataContainer;
        PrivateFontCollection privateFontCollection;
        FontFamily captchaFont;

        #endregion

        #region Public Members
        public event EventHandler<PassEventArgs> elementAddRequest;
        public string appMode { get; set; }
        #endregion

        #region Constructor
        public UIHandler(Form PassUIForm)
        {
            msgLogger = writeLog;
            appMode = "generate";
            sW = new Stopwatch();
            sW.Start();
            uiForm = PassUIForm;
            grpQueryDataContainer = (GroupBox)(PassUIForm.Controls.Find("grpQueryData", true))[0];
            varPassPanel = (FlowLayoutPanel)(PassUIForm.Controls.Find("varPasswordPanel", true))[0];
            varDataPanel = (FlowLayoutPanel)(PassUIForm.Controls.Find("flowGeneratePanel", true))[0];
            imgSizer= (TrackBar)(PassUIForm.Controls.Find("trkImgSize", true))[0];
            resultBox = (TextBox)(PassUIForm.Controls.Find("varPasswordResult", true))[0];
            codeBox = (TextBox)(PassUIForm.Controls.Find("codeBox", true))[0];
            delButton = (Button)(PassUIForm.Controls.Find("btnDelete", true))[0];
            delButton.Click += delButton_Click;
            privateFontCollection = new PrivateFontCollection();
            captchaFont = new FontFamily("Consolas");
            
        }

        #endregion

        #region Public Methods
        public void setCustomCaptchaFont()
        {
            privateFontCollection.AddFontFile(@".\Resources\LetterFont.ttf");
            captchaFont = privateFontCollection.Families[0];
        }

        public void writeLog(string strMessage)
        {
            TextBox tmpBox;
            if (appMode == "generate") tmpBox = (TextBox)(uiForm.Controls.Find("txtLogGenerate", true))[0];
            else tmpBox = (TextBox)(uiForm.Controls.Find("txtLogLogin", true))[0];
            tmpBox.AppendText(sW.Elapsed.Minutes + ":" + sW.Elapsed.Seconds + "." + sW.Elapsed.Milliseconds + "  " + strMessage + "\r\n");
        }

        public void fillLayoutPanel(Dictionary<string, PassElement> varData)
        {
            varDataPanel.Controls.Clear();
            msgLogger("UiHandler: FlowPanel für variable Inhalte geleert");
            foreach (KeyValuePair<string, PassElement> pElement in varData)
            {
                PictureBox tmp1PictBox = new PictureBox();
                string tmpLocation = ((IUIPassElement)pElement.Value).getRandomImgPath();

                tmp1PictBox.Image = createCaptcha(((DynPassElement)pElement.Value).PassData, tmpLocation);
                tmp1PictBox.SizeMode = PictureBoxSizeMode.Zoom;
                tmp1PictBox.Height = 130;
                tmp1PictBox.Width = 130;
                tmp1PictBox.Tag = pElement.Value;
                tmp1PictBox.Name = pElement.Value.PassParameter;
                tmp1PictBox.DoubleClick += TmpPictBox_DoubleClick;
                tmp1PictBox.MouseHover += TmpPictBox_MouseHover;
                tmp1PictBox.MouseLeave += TmpPictBox_MouseLeave;
                Binding sizeBinding = new Binding("Size", imgSizer, "Value");
                sizeBinding.Format += SizeConvertEventHandler;
                tmp1PictBox.DataBindings.Add(sizeBinding);
                varDataPanel.Controls.Add(tmp1PictBox);
            }
            msgLogger("UiHandler: FlowPanel mit variablen Inhalten gefüllt");

        }

        public void initDisplay()
        {
            varPassPanel.Controls.Clear();
            addFixPassElement();
            resultBox.Clear();
            gatherPassInfo();
        }
        #endregion

        #region Private Methods
        private Image createCaptcha(string code, string imgLocation)
        {

            Color[] colRnd = new Color[] { Color.Lime, Color.Blue };
            Bitmap bitmap = new Bitmap(imgLocation);

            Graphics g = Graphics.FromImage(bitmap);

            int rndIx = rnd.Next(0, 2);
            SolidBrush textCol = new SolidBrush(colRnd[rndIx]);
            int counter = 0;
            for (int i = 0; i < code.Length; i++)
            {
                g.DrawString(code[i].ToString(), new Font(captchaFont, 40 + rnd.Next(5, 8)), textCol, new PointF(counter, rnd.Next(1, 30)));
                counter += 30;
            }
            g.Dispose();
            return bitmap;
        }

        private void addFixPassElement()
        {
            TextBox fixPassBox = new TextBox();
            fixPassBox.TextAlign = HorizontalAlignment.Left;
            fixPassBox.Font = new System.Drawing.Font("Arial", 12f);
            fixPassBox.Name = "FixPassTextBox" + varPassPanel.Controls.Count;
            fixPassBox.TextChanged += fixPassBox_TextChanged;
            fixPassBox.Leave += fixPassBox_Leave;
            varPassPanel.Controls.Add(fixPassBox);
            fixPassBox.Focus();
        }

        private void addVarPassElement(PassElement pE)
        {
            if (varPassPanel.Controls[varPassPanel.Controls.Count - 1].GetType() == typeof(TextBox))
            {
                if (((TextBox)varPassPanel.Controls[varPassPanel.Controls.Count - 1]).Text == "")
                    varPassPanel.Controls.Remove(varPassPanel.Controls[varPassPanel.Controls.Count - 1]);
            }

            Label pElement = new Label();
            pElement.Font = new System.Drawing.Font("Arial", 14f);
            pElement.TextAlign = ContentAlignment.BottomLeft;
            pElement.Text = pE.PassCommand + "(" + pE.PassParameter + ")";
            Size size = TextRenderer.MeasureText(pElement.Text, pElement.Font);
            pElement.Height = size.Height + 5;
            pElement.Width = size.Width;
            pElement.Tag = pE;
            varPassPanel.Controls.Add(pElement);
            addFixPassElement();
            gatherPassInfo();
        }

        private void gatherPassInfo()
        {
            PassElement tmpE = null;
            PseudoPassElement ppe;
            bool pseudoAdded = false;
            StringBuilder resultBuilder = new StringBuilder();
            StringBuilder codeBuilder = new StringBuilder();
            foreach (object tmpPassElement in varPassPanel.Controls)
            {
                if (tmpPassElement.GetType() == typeof(TextBox))
                {
                    if (((TextBox)tmpPassElement).Text != "")
                    {
                        tmpE = (FixPassElement)((TextBox)tmpPassElement).Tag;
                        resultBuilder.Append(((TextBox)tmpPassElement).Text);
                        codeBuilder.Append(tmpE.PassCommand + "(" + tmpE.PassParameter + ")" + Environment.NewLine);
                    }
                    else
                        codeBuilder.Append("");
                }
                else
                {
                    tmpE = (DynPassElement)((Label)tmpPassElement).Tag;
                    resultBuilder.Append(((DynPassElement)tmpE).PassData);
                    codeBuilder.Append(tmpE.PassCommand + "(" + tmpE.PassParameter + ")" + Environment.NewLine);
                }
                
                if(rnd.Next(0,2)==1)
                {
                    ppe = new PseudoPassElement();
                    codeBuilder.Append(ppe.PassCommand + "(" + ppe.PassParameter + ")" + Environment.NewLine);
                    pseudoAdded = true;
                }

            }
            if(!pseudoAdded)
            {
                ppe = new PseudoPassElement();
                codeBuilder.Append(ppe.PassCommand + "(" + ppe.PassParameter + ")" + Environment.NewLine);
            }

            PassEventArgs pEventArgs = new PassEventArgs(resultBuilder.ToString(), codeBuilder.ToString());
            codeBox.Clear(); codeBox.AppendText(codeBuilder.ToString());
            resultBox.Clear(); resultBox.AppendText(resultBuilder.ToString());
            onElementAddRequest(this, pEventArgs);
        }
        #endregion

        #region EventHandler

        private void TmpPictBox_MouseLeave(object sender, EventArgs e)
        {
            if (varDataPanel.Parent != (uiForm.Controls.Find("grpGenerateData", true))[0])
            {

            }
        }

        private void TmpPictBox_MouseHover(object sender, EventArgs e)
        {
            if (varDataPanel.Parent != (uiForm.Controls.Find("grpGenerateData", true))[0])
            {
                varDataPanel.Visible = false;
                string code = ((DynPassElement)((PictureBox)sender).Tag).PassData;
                Graphics g = grpQueryDataContainer.CreateGraphics();
                Color[] colRnd = new Color[] { Color.Lime, Color.Blue };
                int rndIx = rnd.Next(0, 2);
                SolidBrush textCol = new SolidBrush(colRnd[rndIx]);
                int counter = 0;
                for (int i = 0; i < code.Length; i++)
                {
                    g.DrawString(code[i].ToString(), new Font(captchaFont, 70 + rnd.Next(5, 8)), textCol, new PointF(counter, rnd.Next(1, 70)));
                    counter += 30;
                }
                
                g.Dispose();
            }
        }

        private void TmpPictBox_DoubleClick(object sender, EventArgs e)
        {
            msgLogger("UiHandler: Doppelklick auf " + ((PictureBox)sender).Name);
            if (varDataPanel.Parent == (uiForm.Controls.Find("grpGenerateData", true))[0])
                addVarPassElement((PassElement)((PictureBox)sender).Tag);
        }

        private void fixPassBox_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(((TextBox)sender).Text, ((TextBox)sender).Font);
            if (size.Width > ((TextBox)sender).Width || size.Width > 100)
                ((TextBox)sender).Width = size.Width + 10;
            if (((TextBox)sender).Text != "")
            {
                ((TextBox)sender).Tag = new FixPassElement(((TextBox)sender).Text);
            }
            else
                ((TextBox)sender).Tag = null;
            gatherPassInfo();
        }

        private void fixPassBox_Leave(object sender, EventArgs e)
        {
        }

        private void onElementAddRequest(object sender, PassEventArgs eventArgs)
        {
            if (elementAddRequest != null)
            {
                elementAddRequest(sender, eventArgs);
            }
        }
        
        private void delButton_Click(object sender, EventArgs e)
        {
            if (varPassPanel.Controls[varPassPanel.Controls.Count - 1].GetType() == typeof(TextBox))
            {
                if (((TextBox)varPassPanel.Controls[varPassPanel.Controls.Count - 1]).Text == "")
                {
                    if (varPassPanel.Controls.Count > 1)
                    {
                        varPassPanel.Controls.Remove(varPassPanel.Controls[varPassPanel.Controls.Count - 2]);
                        if (varPassPanel.Controls.Count > 1 && varPassPanel.Controls[varPassPanel.Controls.Count - 2].GetType() == typeof(TextBox))
                            varPassPanel.Controls.Remove(varPassPanel.Controls[varPassPanel.Controls.Count - 1]);
                    }
                }
                else
                {
                    ((TextBox)varPassPanel.Controls[varPassPanel.Controls.Count - 1]).Text = "";
                }
            }
            else
                varPassPanel.Controls.Remove(varPassPanel.Controls[varPassPanel.Controls.Count - 1]);
            gatherPassInfo();
        }

        private void SizeConvertEventHandler(object sender, ConvertEventArgs e)
        {
            Size newSize = new Size();
            newSize.Height = (int)((Convert.ToDouble(e.Value) / 50) * 130);
            newSize.Width = (int)((Convert.ToDouble(e.Value) / 50) * 130);
            e.Value = newSize;
        }

        #endregion
    }


    public class PassEventArgs : EventArgs
    {
        public string resultText { get; private set; }
        public string codeText { get; private set; }

        public PassEventArgs(string rText, string cText)
        {
            resultText = rText;
            codeText = cText;
        }
    }
}
