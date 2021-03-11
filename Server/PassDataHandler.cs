using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VariableData;

namespace Server
{
    class VarDataHandler : VarDataProvider
    {
        #region Private Member
        int dictCount;
        IDataCreator tmpIDC;
        Random rnd;
        #endregion

        #region Public Member
        public Dictionary<string, string> varData { get; private set; }
        #endregion

        #region Constructor
        public VarDataHandler()
        {

        }
        #endregion

        #region Public Methods

        public void setDataType(IDataCreator iDC)
        {
            tmpIDC = iDC;
            this.setDataCreator(iDC);
            varData = this.generateVarData();
            dictCount = varData.Count;
        }

        public void fillLayoutPanel(TableLayoutPanel tLP)
        {
            Label row1Lbl;
            Label row2Lbl;
            tLP.AutoSize = false;   //ansonsten sehr langsam
            tLP.Controls.Clear();

            for (int i = 0; i < dictCount; i++)
            {
                row1Lbl = new Label();
                row1Lbl.AutoSize = true;
                row1Lbl.Text = varData.Keys.ElementAt(i);
                
                if (tmpIDC.GetType() == typeof(VarRandomA))
                {
                    row1Lbl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    row1Lbl.TextAlign = ContentAlignment.MiddleCenter;
                    PictureBox pictBox = new PictureBox();
                    pictBox.Image = createCaptcha(varData.Values.ElementAt(i));
                    pictBox.Size = new Size(50, 50);

                    tLP.Controls.Add(row1Lbl, i, 0);
                    tLP.Controls.Add(pictBox, i, 1);
                }
                else
                {
                    row2Lbl = new Label();
                    row2Lbl.AutoSize = true;
                    if (tmpIDC.GetType() == typeof(VarColor))
                    {
                        row2Lbl.Text = "   ";
                        row2Lbl.BackColor = Color.FromName(varData.Values.ElementAt(i));
                    }
                    else
                        row2Lbl.Text = varData.Values.ElementAt(i);

                    tLP.Controls.Add(row1Lbl, i, 0);
                    tLP.Controls.Add(row2Lbl, i, 1);
                }
            }
            tLP.AutoSize = true;
        }
        #endregion

        #region Private Methods
        private Image createCaptcha(string code)
        {
            Color[] colRnd = new Color[] { Color.White, Color.PapayaWhip};
            rnd = new Random(System.DateTime.Now.Millisecond);
            Bitmap bitmap = new Bitmap(50, 50, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Yellow);
            Rectangle rect = new Rectangle(0, 0, 50, 50);
            SolidBrush b = new SolidBrush(Color.Black);
            int rndIx = rnd.Next(0, 2);
            SolidBrush White = new SolidBrush(colRnd[rndIx]);
            int counter = 0;
            g.DrawRectangle(pen, rect);
            g.FillRectangle(b, rect);
            for (int i = 0; i < code.Length; i++)
            {
                g.DrawString(code[i].ToString(), new Font("Georgia", 20 + rnd.Next(1, 3)), White, new PointF( counter, rnd.Next(1,15)));
                counter += 20;
            }
            SolidBrush sB = new SolidBrush(colRnd[1-rndIx]);
            DrawRandomLines(g,sB );
            g.Dispose();
            //bitmap.Dispose();
            return bitmap;
        }

        private void DrawRandomLines(Graphics g, SolidBrush sB)
        {
            //For Creating Lines on The Captcha 
            for (int i = 0; i < 10; i++)
            {
                g.DrawLines(new Pen(sB, 1), GetRandomPoints());
            }

        }

        private Point[] GetRandomPoints()
        {
            Point[] points = { new Point(rnd.Next(1, 50), rnd.Next(1, 50)), new Point(rnd.Next(1, 50), rnd.Next(1, 50)) };
            return points;
        }
        #endregion
    }
}
