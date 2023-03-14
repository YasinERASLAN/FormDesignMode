
using System;
using System.Windows.Forms;

namespace GenelSurecler
{

    public partial class Form1 : Form , System.IDisposable
    {
        public Form CurrentForm = null;
        public Form1(){InitializeComponent();}

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.CurrentForm != null)
            {
                this.CurrentForm.Visible = false;
                System.Threading.Thread.SpinWait((int)1000000);
                this.CurrentForm.Close();
                System.Threading.Thread.SpinWait((int)1000000);
                this.CurrentForm = null;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.CurrentForm == null)
            {
                MessageBox.Show("Açık Form Bulunmamaktadır."); return;
            }
            if (this.CurrentForm.Name == "Panel")
            {
                if (!this.CurrentForm.DO_DesignModeStateGet())
                {
                    this.CurrentForm.DO_DesignMode(true, this.FrmPanel.panel2);
                }
                return;
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (this.CurrentForm == null) 
            {
                MessageBox.Show("Açık Form Bulunmamaktadır.");return;
            }
            if (this.CurrentForm.Name == "Panel")
                {
                if (this.CurrentForm.DO_DesignModeStateGet())
                {
                    this.CurrentForm.DO_DesignMode(false, this.FrmPanel.panel2);
                }
                return;
            }

        }

        public GenelSurecler.Panel FrmPanel = null;

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.panel4.Controls.Clear();
            this.FrmPanel = new GenelSurecler.Panel();
            this.FrmPanel.FormBorderStyle = FormBorderStyle.None;
            this.FrmPanel.Dock = DockStyle.Fill;
            this.FrmPanel.TopLevel = false;
            this.panel4.Controls.Add(this.FrmPanel);
            this.panel4.Tag = this.FrmPanel;
            //this.FrmPanel.Owner = this;
            //yeni.BringToFront();
            this.FrmPanel.Show();
            this.CurrentForm = this.FrmPanel;
        }
    }

}