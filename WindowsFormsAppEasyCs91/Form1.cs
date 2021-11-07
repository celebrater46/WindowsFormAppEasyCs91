using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEasyCs91
{
    public partial class Form1 : Form
    {
        private TableLayoutPanel tlp;
        private RadioButton[] rb = new RadioButton[4];
        private Image cim;
        private Image[] mim = new Image[4];
        private PictureBox pb;
        private Label lb;
        private int num;
        private bool isOpen; // Is the card open?
        private string picturePass = "C:\\Users\\Enin\\RiderProjects\\WindowsFormsAppEasyCs91\\WindowsFormsAppEasyCs91\\img\\";
        
        // private Label lb;
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "Trump Game";
            this.Width = 650;
            this.Height = 450;

            // For Test
            // lb = new Label();
            // lb.Text = "HelloWorld";
            // lb.Width = 250;
            // lb.Parent = this;

            tlp = new TableLayoutPanel();
            tlp.Dock = DockStyle.Fill;
            tlp.ColumnCount = 4;
            tlp.RowCount = 2;
            
            for (int i = 0; i < rb.Length; i++)
            {
                mim[i] = Image.FromFile(picturePass + "mark" + i + ".bmp");
                // mim[i] = Image.FromFile(string.Format("C:\\Users\\Enin\\RiderProjects\\WindowsFormsAppEasyCs91\\WindowsFormsAppEasyCs91\\img\\mark{0}.bmp", i));
                // mim[i] = Image.FromFile("C:\\Users\\Enin\\RiderProjects\\WindowsFormsAppEasyCs91\\WindowsFormsAppEasyCs91\\img\\mark1.bmp");
                // mim[i] = Image.FromFile("C:\\Users\\Enin\\RiderProjects\\WindowsFormsAppEasyCs91\\WindowsFormsAppEasyCs91\\img\\test.png");
                rb[i] = new RadioButton();
                rb[i].Image = mim[i];
                rb[i].AutoSize = true;
                rb[i].Parent = tlp;
            }
            
            // cim = Image.FromFile(picturePass + "card.bmp");
            cim = Image.FromFile("C:\\Users\\Enin\\RiderProjects\\WindowsFormsAppEasyCs91\\WindowsFormsAppEasyCs91\\img\\card.bmp");
            // cim = Image.FromFile("C:\\Users\\Enin\\RiderProjects\\WindowsFormsAppEasyCs91\\WindowsFormsAppEasyCs91\\img\\test.png");
            pb = new PictureBox();
            pb.Image = cim;
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            pb.Anchor = AnchorStyles.Right;
            pb.Parent = tlp;
            
            lb = new Label();
            // lb.Font = new Font("SansSefif", 50, FontStyle.Bold);
            lb.Font = new Font("SansSerif", 50, FontStyle.Bold);
            lb.AutoSize = true;
            lb.Anchor = AnchorStyles.None;
            lb.Parent = tlp;
            
            tlp.SetColumnSpan(pb, 2);
            tlp.SetColumnSpan(lb, 2);
            
            tlp.Parent = this;
            
            isOpen = false;
            Random rn = new Random();
            num = rn.Next(4);
            
            pb.Click += new EventHandler(PbClick);
        }

        public void PbClick(Object sender, EventArgs e)
        {
            // if (!isOpen)
            if (isOpen == false)
            {
                isOpen = true;
                pb.Image = mim[num];
        
                if (rb[num].Checked == true)
                {
                    lb.ForeColor = Color.DeepPink;
                    lb.Text = "HIT!!";
                }
                else
                {
                    lb.ForeColor = Color.SlateBlue;
                    lb.Text = "MISS!!";
                }
            }
            else
            {
                isOpen = false;
                lb.Text = "";
                pb.Image = cim;
        
                Random rn = new Random();
                num = rn.Next(4);
            }
        }
    }
}