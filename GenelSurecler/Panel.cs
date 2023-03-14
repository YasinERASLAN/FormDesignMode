using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenelSurecler
{
    public partial class Panel : Form
    {
        public Panel()
        {InitializeComponent();}

        private void Panel_Shown(object sender, EventArgs e)
        {
            // Sayfanın tasarımını düzenlemek için gerekli hazırlıklardır. Sayfa yüklenince tasarım moduda yüklenir.
            this.DO_DesignModeLoad(this.panel2, 5);
            this.DO_ComponentEdition_MouseDown_Event(this.ForDesign_Edition_MouseDown);
            this.DO_EditionalComponents_Update(new List<string>() { "Button", "TextBox", "GroupBox", "RichTextBox", "Panel", "Label" });
            this.DO_DragDropComponents_Update(new List<string>() { "Panel", "GroupBox" });
        }

        private void ForDesign_Edition_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ((System.Windows.Forms.Control)sender).BackColor = System.Drawing.Color.HotPink;
            }
        }

        private void Panel_Load(object sender, EventArgs e)
        {
        }

        //-/////////////////////////////////////////

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.DO_DesignModeStateGet()) { 
                try
                {
                    checked
                    {
                        this.textBox4.Text = System.Convert.ToDouble((System.Convert.ToDouble(textBox1.Text) + System.Convert.ToDouble(textBox2.Text)) * System.Convert.ToDouble(textBox3.Text)).ToString();
                    }
                }
                catch (Exception exx)
                {
                    MessageBox.Show("Verilerde veya Program Çalışmasında hata oluşmuştur.\nHata : \n" + exx.Message + "\n" + exx.StackTrace);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!this.DO_DesignModeStateGet())
            {
                try
                {
                    richTextBox1.Text = "";
                    string veri = "";
                    foreach (int item in Enumerable.Range(1, 200))
                    {
                        if (item % 3 == 0 && item % 5 == 0) { if (item > 100) { veri = "zagzig"; } else { veri = "zigzag"; } }
                        else if (item % 5 == 0) { veri = "zag"; }
                        else if (item % 3 == 0) { veri = "zig"; }
                        else { veri = item.ToString(); }
                        if (item % 10 == 0) { veri = veri + ",\n"; } else { veri = veri + ","; }
                        richTextBox1.Text += veri;
                    }
                }
                catch (Exception exx)
                {
                    MessageBox.Show("Verilerde veya Program Çalışmasında hata oluşmuştur.\nHata : \n" + exx.Message + "\n" + exx.StackTrace);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!this.DO_DesignModeStateGet())
            {
                try
                {
                    uint sayi = System.Convert.ToUInt32(textBox5.Text);
                    if (sayi > 1 && sayi < 16)
                    {
                        String satir2 = "";
                        richTextBox2.Text = "";
                        for (int ii = 0; ii <= sayi; ii++)
                        {
                            for (int i = 0; i <= sayi; i++)
                            {
                                if (ii == 0)
                                { satir2 += (ii + i).ToString() + "\t"; }
                                else
                                {
                                    if (i == 0) { satir2 += (ii + i).ToString() + "\t"; } else { satir2 += (ii * i).ToString() + "\t"; }
                                }
                            }
                            richTextBox2.Text += satir2 + "\n";
                            satir2 = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show(" 1 ile 15'e kadar sayıları girebilirsiniz. Tekrar sayı girişi yapınız. ");
                    }
                }
                catch (Exception exx)
                {
                    MessageBox.Show("Verilerde veya Program Çalışmasında hata oluşmuştur.\nHata : \n" + exx.Message + "\n" + exx.StackTrace);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!this.DO_DesignModeStateGet())
            {
                try
                {
                    uint sayi = System.Convert.ToUInt32(textBox6.Text);
                    label2.Text = Fibonacci((int)sayi).ToString();
                }
                catch (Exception exx)
                {
                    MessageBox.Show("Verilerde veya Program Çalışmasında hata oluşmuştur.\nHata : \n" + exx.Message + "\n" + exx.StackTrace);
                }
            }
        }

        private double Fibonacci(int n)
        {
            checked
            {
                double firstnumber = 0;
                double secondnumber = 1;
                double result = 0;
                if (n == 0) return 0;
                if (n == 1) return 1;
                for (int i = 2; i < n; i++)
                {
                    result = firstnumber + secondnumber;
                    firstnumber = secondnumber;
                    secondnumber = result;
                }
                return result;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!this.DO_DesignModeStateGet())
            {
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "txt files (*.txt)|*.txt";
                    dialog.InitialDirectory = @Application.StartupPath.ToString();
                    dialog.Title = " Seçmek istediğiniz dosyanın konumunu bularak seçiniz. ( 1 Tane dosya seçebilirsiniz. ) ";
                    List<double> sayilar = new List<double>();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (System.IO.File.Exists(dialog.FileName))
                        {
                            foreach (string kvp in (System.IO.File.ReadAllLines((string)dialog.FileName, (Encoding)System.Text.Encoding.UTF8)))
                            {
                                string[] nn = kvp.Split(' ');
                                foreach (string item in nn)
                                {
                                    if (item.Replace(",", ".").Trim().ToString().Length > 0)
                                    { sayilar.Add(System.Convert.ToDouble(item.Replace(",", ".").Trim().ToString())); }
                                }
                            }
                        }
                        sayilar.Sort();
                        sayilar.Reverse();
                        foreach (double item in sayilar)
                        {
                            richTextBox3.Text += item.ToString() + "\n";
                        }
                    }
                }
                catch (Exception exx)
                {
                    MessageBox.Show("Verilerde veya Program Çalışmasında hata oluşmuştur.\nHata : \n" + exx.Message + "\n" + exx.StackTrace);
                }
            }
        }
        //-//////////////////////////////////////////

    }

}





