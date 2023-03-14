namespace System.Windows.Forms
{
    public static class FormDesign
    {


        /// <summary>
        /// Form sınıfının içine tanımlı genişletilmiş sınıfdır.
        /// Form içinde olan bir paneli baz alarak seçili komponent tiplerine göre componentleri tasarım moduna alır.
        /// Tasarım veya Runtime modundaki seçili nesneler için mouseclick olayını yönetir.
        /// İstenilen tipteki ögeler seçilebilir. Seçilen panel ve istenilen ögelerin tasarım modundan etkilenmesi sağlanabilir.
        /// Tek tasarım modu vardır.
        /// 
        /// 
        /// Kullanımı : 
        /// 
        /// 
        /// >>>>Form yüklenince ilk olarak Desing mod kullanımı için yapılması gereken işlemlerdir. ilk form yükleme ve açılmasında yapılması gereklidir.
        /// >>>> Forumun Show veya Load fonsiyonuna yazılarak yükleme işlemleri yapılır.
        /// 
        /// this.DO_DesignModeLoad(this.panel2, 5);
        /// this.DO_ComponentEdition_MouseDown_Event(this.ForDesign_Edition_MouseDown);
        /// this.DO_EditionalComponents_Update(new List<string>() { "Button", "GroupBox", "TextBox", "RichTextBox", "TabControl", "Panel", "Label" });
        /// this.DO_DragDropComponents_Update(new List<string>() { "GroupBox", "Panel", "TabPage" });
        /// 
        /// 
        /// >>>>Bu komut ile formun içindeki bir paneli referans alarak ilgili bölümün componentleri tasarım moduna geçirilir.
        /// >>>> Forklı bir konumdan veya forum içinden tasarım moduna alınır veya tasarım modu kapatılır.
        /// 
        /// -- Tasarım moduna alır.
        /// this.(ilgiliForm).DO_DesignMode(true, this.FrmPanel.panel2);
        /// 
        /// /// -- Tasarım moduna alır.
        /// this.(ilgiliForm).DO_DesignMode(false, this.FrmPanel.panel2);
        /// 
        /// 
        /// </summary>



        private static System.Boolean DO_ModeLock = false;
        private static event System.Windows.Forms.MouseEventHandler DO_ComponentEditionalEvents = delegate { };
        private static System.Int32 LayerDept = 5;

        private static System.Windows.Forms.Control DO_DesignComponent = null;
        private static System.Windows.Forms.Panel DO_Container = new System.Windows.Forms.Panel();
        private static System.Windows.Forms.Panel DO_DesignObj = new System.Windows.Forms.Panel();
        private static System.Windows.Forms.Panel DO_DesignBasePanel = new System.Windows.Forms.Panel();
        private static System.Collections.Generic.List<System.String> DO_EditionalComponents = new System.Collections.Generic.List<System.String>() { "Button", "GroupBox", "TextBox", "RichTextBox", "TabControl", "Panel", "Label", "SplitContainer", "FlowLayoutPanel" };
        private static System.Collections.Generic.List<System.String> DO_DragDropComponents = new System.Collections.Generic.List<System.String>() { "GroupBox", "Panel", "TabPage" };

        private static System.Windows.Forms.Panel DO_panel44 = null;
        private static System.Windows.Forms.Panel DO_panel4 = null;
        private static System.Windows.Forms.Label DO_label1 = null;
        private static System.Windows.Forms.Label DO_label2 = null;
        private static System.Windows.Forms.Label DO_label3 = null;
        private static System.Windows.Forms.Label DO_label4 = null;
        private static System.Windows.Forms.Label DO_label5 = null;
        private static System.Windows.Forms.Label DO_label6 = null;
        private static System.Windows.Forms.Label DO_label7 = null;
        private static System.Windows.Forms.Label DO_label8 = null;
        private static System.Windows.Forms.Label DO_label9 = null;
        private static System.Windows.Forms.Label DO_label10 = null;

        private static void DO_ComponentEdition_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                DO_ComponentEditionalEvents.Invoke(DO_DesignComponent, e);
            }
        }

        private static void DO_DesignObJAdd(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && !DO_Container.Contains((System.Windows.Forms.Control)sender))
            {
                ((System.Windows.Forms.Control)sender).SuspendLayout();
                ((System.Windows.Forms.Control)sender).Parent.Controls.Add(DO_DesignObj);
                DO_DesignObj.Location = new System.Drawing.Point(((System.Windows.Forms.Control)sender).Location.X - DO_Container.Location.X, ((System.Windows.Forms.Control)sender).Location.Y - DO_Container.Location.Y);
                DO_DesignObj.Width = ((System.Windows.Forms.Control)sender).Width + (DO_Container.Location.X * 2) + 4;
                DO_DesignObj.Height = ((System.Windows.Forms.Control)sender).Height + (DO_Container.Location.Y * 2) + 4;
                DO_Container.Width = ((System.Windows.Forms.Control)sender).Width;
                DO_Container.Height = ((System.Windows.Forms.Control)sender).Height;
                DO_Container.Controls.Add(((System.Windows.Forms.Control)sender));
                ((System.Windows.Forms.Control)sender).Dock = System.Windows.Forms.DockStyle.Fill;
                DO_DesignObj.Visible = true;
                ((System.Windows.Forms.Control)sender).ResumeLayout();
                DO_DesignObj.ResumeLayout();
            }
        }

        private static void DO_DesignObJCloseOnly(System.Object sender, System.Windows.Forms.MouseEventArgs e=null)
        {
            if (DO_Container.Controls.Count > 0)
            {

                System.Int32 bufW = 0;
                System.Int32 bufH = 0;
                if (DO_Container.Controls.Count > 0)
                {

                    bufW = DO_Container.Controls[0].Width;
                    bufH = DO_Container.Controls[0].Height;
                    DO_DesignObj.SuspendLayout();


                    DO_Container.Controls[0].SuspendLayout();
                    DO_Container.Controls[0].Dock = System.Windows.Forms.DockStyle.None;
                    DO_Container.Controls[0].Location = new System.Drawing.Point(DO_DesignObj.Location.X + DO_Container.Location.X, DO_DesignObj.Location.Y + DO_Container.Location.Y);
                    DO_Container.Controls[0].Width = bufW;
                    DO_Container.Controls[0].Height = bufH;
                    DO_Container.Controls[0].ResumeLayout();
                    DO_DesignObj.Parent.Controls.Add(DO_Container.Controls[0]);
                }
                DO_DesignObj.Parent.Controls.Add(DO_DesignObj);
                DO_DesignObj.Location = new System.Drawing.Point(0, 0);
                DO_DesignObj.Width = 100 + 26;
                DO_DesignObj.Height = 100 + 30;
                DO_Container.Width = 100;
                DO_Container.Height = 100;
                DO_DesignObj.Visible = false;
                DO_DesignObj.ResumeLayout();
            }
            else
            {
                DO_DesignObj.SuspendLayout();
                ((System.Windows.Forms.Control)sender).Controls.Add(DO_DesignObj);
                DO_DesignObj.Location = new System.Drawing.Point(0, 0);
                DO_DesignObj.Width = 100 + 26;
                DO_DesignObj.Height = 100 + 30;
                DO_Container.Width = 100;
                DO_Container.Height = 100;
                DO_DesignObj.Visible = false;
                DO_DesignObj.ResumeLayout();
            }
        }

        private static void DO_DesignObJ(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (DO_EditionalComponents.Contains(((System.Windows.Forms.Control)sender).GetType().Name))
            {
                DO_DesignComponent = ((System.Windows.Forms.Control)sender);
                DO_DesignObj.Draggable(true);
                DO_DesignObJCloseOnly(DO_DesignBasePanel, e);
                System.Threading.Thread.SpinWait((int)100000);
                DO_DesignObJAdd(sender, e);
            }
            return;
        }

        private static void DO_Bottom_MouseMove(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && DO_Container.Controls.Count > 0)
            {
                DO_DesignObj.SuspendLayout();
                DO_Container.Controls[0].SuspendLayout();
                DO_DesignObj.Height += e.Y;
                DO_Container.Controls[0].ResumeLayout();
                DO_DesignObj.ResumeLayout();
            }
        }

        private static void DO_Left_MouseMove(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && DO_Container.Controls.Count > 0)
            {
                DO_DesignObj.SuspendLayout();
                DO_Container.Controls[0].SuspendLayout();
                DO_DesignObj.Width += e.X;
                DO_Container.Controls[0].ResumeLayout();
                DO_DesignObj.ResumeLayout();
            }
        }

        private static void DO_DragDrop_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DO_DesignObj.DoDragDrop(DO_DesignObj, System.Windows.Forms.DragDropEffects.Move);
        }

        private static void DO_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = System.Windows.Forms.DragDropEffects.Move;
        }

        private static void DO_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (((System.Windows.Forms.Control)sender).GetType().Name == "Panel")
            {
                e.Effect = System.Windows.Forms.DragDropEffects.Move;
                ((System.Windows.Forms.Panel)e.Data.GetData(typeof(System.Windows.Forms.Panel))).Parent = ((System.Windows.Forms.Panel)sender);
                ((System.Windows.Forms.Panel)e.Data.GetData(typeof(System.Windows.Forms.Panel))).Location = (((System.Windows.Forms.Panel)sender).PointToClient(new System.Drawing.Point(e.X - DO_label6.Location.X, e.Y - DO_label6.Location.Y)));
                return;
            }

            if (((System.Windows.Forms.Control)sender).GetType().Name == "GroupBox")
            {
                e.Effect = System.Windows.Forms.DragDropEffects.Move;
                ((System.Windows.Forms.Panel)e.Data.GetData(typeof(System.Windows.Forms.Panel))).Parent = ((System.Windows.Forms.GroupBox)sender);
                ((System.Windows.Forms.Panel)e.Data.GetData(typeof(System.Windows.Forms.Panel))).Location = (((System.Windows.Forms.GroupBox)sender).PointToClient(new System.Drawing.Point(e.X - DO_label6.Location.X, e.Y - DO_label6.Location.Y)));
                return;
            }

            if (((System.Windows.Forms.Control)sender).GetType().Name == "TabPage")
            {
                e.Effect = System.Windows.Forms.DragDropEffects.Move;
                ((System.Windows.Forms.Panel)e.Data.GetData(typeof(System.Windows.Forms.Panel))).Parent = ((System.Windows.Forms.TabPage)sender);
                ((System.Windows.Forms.Panel)e.Data.GetData(typeof(System.Windows.Forms.Panel))).Location = (((System.Windows.Forms.TabPage)sender).PointToClient(new System.Drawing.Point(e.X - DO_label6.Location.X, e.Y - DO_label6.Location.Y)));
                return;
            }

            e.Effect = System.Windows.Forms.DragDropEffects.Move;
            ((System.Windows.Forms.Control)e.Data.GetData(typeof(System.Windows.Forms.Control))).Parent = ((System.Windows.Forms.Control)sender);
            ((System.Windows.Forms.Control)e.Data.GetData(typeof(System.Windows.Forms.Control))).Location = (((System.Windows.Forms.Control)sender).PointToClient(new System.Drawing.Point(e.X - DO_label6.Location.X, e.Y - DO_label6.Location.Y)));

        }

        private static void ObjectManagedOpen(System.Windows.Forms.Control a, System.Int32 derinlik)
        {
            foreach (System.Windows.Forms.Control f in a.Controls)
            {
                if (f.Name == DO_DesignObj.Name) { continue; }
                if (derinlik > 0) { ObjectManagedOpen(f, (System.Int32)(derinlik - 1)); }
                f.MouseClick += new System.Windows.Forms.MouseEventHandler(DO_DesignObJ);
                if (DO_DragDropComponents.Contains(f.GetType().Name))
                {
                    f.AllowDrop = true;
                    f.DragDrop += new System.Windows.Forms.DragEventHandler(DO_DragDrop);
                    f.DragEnter += new System.Windows.Forms.DragEventHandler(DO_DragEnter);
                }
            }
        }

        private static void ObjectManagedClose(System.Windows.Forms.Control a, System.Int32 derinlik)
        {
            foreach (System.Windows.Forms.Control f in a.Controls)
            {
                if (f.Name == DO_DesignObj.Name) { continue; }
                if (derinlik > 0) { ObjectManagedClose(f, (System.Int32)(derinlik - 1)); }
                f.MouseClick -= new System.Windows.Forms.MouseEventHandler(DO_DesignObJ);
                if (DO_DragDropComponents.Contains(f.GetType().Name))
                {
                    f.AllowDrop = false;
                    f.DragDrop -= new System.Windows.Forms.DragEventHandler(DO_DragDrop);
                    f.DragEnter -= new System.Windows.Forms.DragEventHandler(DO_DragEnter);
                }
            }
        }





        public static System.Windows.Forms.Control DO_DesignComponentGet(this System.Windows.Forms.Form DO_Form)
        {
            if (DO_ModeLock) { return DO_DesignComponent; } else { return null; }
            return null;
        }

        public static bool DO_DesignModeStateGet(this System.Windows.Forms.Form DO_Form)
        {
            return DO_ModeLock;
        }

        public static void DO_DesignModeLoad(this System.Windows.Forms.Form DO_Form, System.Windows.Forms.Panel mainpanel, System.Int32 LayerDeptf=5)
        {

            DO_ModeLock = false;
            DO_ComponentEditionalEvents = delegate { };
            LayerDept = LayerDeptf;

            DO_DesignComponent = null;
            DO_Container = new System.Windows.Forms.Panel();
            DO_DesignObj = new System.Windows.Forms.Panel();
            DO_DesignBasePanel = new System.Windows.Forms.Panel();
            DO_EditionalComponents = new System.Collections.Generic.List<System.String>() { "Button", "GroupBox", "TextBox", "RichTextBox", "TabControl", "Panel", "Label", "SplitContainer", "FlowLayoutPanel" };
            DO_DragDropComponents = new System.Collections.Generic.List<System.String>() { "GroupBox", "Panel", "TabPage" };

            DO_panel44 = new System.Windows.Forms.Panel();
            DO_panel4 = new System.Windows.Forms.Panel();
            DO_label1 = new System.Windows.Forms.Label();
            DO_label2 = new System.Windows.Forms.Label();
            DO_label3 = new System.Windows.Forms.Label();
            DO_label4 = new System.Windows.Forms.Label();
            DO_label5 = new System.Windows.Forms.Label();
            DO_label6 = new System.Windows.Forms.Label();
            DO_label7 = new System.Windows.Forms.Label();
            DO_label8 = new System.Windows.Forms.Label();
            DO_label9 = new System.Windows.Forms.Label();
            DO_label10 = new System.Windows.Forms.Label();

            DO_panel44.SuspendLayout();
            DO_panel4.SuspendLayout();
            // 
            // DO_panel44
            // 
            DO_panel44.BackColor = System.Drawing.Color.LightYellow;
            DO_panel44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            DO_panel44.Size = new System.Drawing.Size(110, 101);
            DO_panel44.Location = new System.Drawing.Point(250, 250);
            DO_panel44.Margin = new System.Windows.Forms.Padding(0);
            DO_panel44.Name = "DO_panel44";
            DO_panel44.TabIndex = 11;
            DO_panel44.Controls.Add(DO_label8);
            DO_panel44.Controls.Add(DO_label10);
            DO_panel44.Controls.Add(DO_label4);
            DO_panel44.Controls.Add(DO_label7);
            DO_panel44.Controls.Add(DO_label9);
            DO_panel44.Controls.Add(DO_label6);
            DO_panel44.Controls.Add(DO_label1);
            DO_panel44.Controls.Add(DO_label2);
            DO_panel44.Controls.Add(DO_label3);
            DO_panel44.Controls.Add(DO_label5);
            DO_panel44.Controls.Add(DO_panel4);
            DO_panel44.Visible = false;

            // 
            // DO_label8
            // 
            DO_label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            DO_label8.BackColor = System.Drawing.Color.Black;
            DO_label8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DO_label8.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            DO_label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            DO_label8.Size = new System.Drawing.Size((System.Int32)10, (System.Int32)10);
            DO_label8.Location = new System.Drawing.Point((System.Int32)(DO_panel44.Width - (System.Int32)(DO_label8.Width * 1.4)), (System.Int32)0);
            DO_label8.Margin = new System.Windows.Forms.Padding((System.Int32)0);
            DO_label8.Name = "DO_label8";
            DO_label8.TabIndex = (System.Int32)26;
            DO_label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DO_label10
            // 
            DO_label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            DO_label10.BackColor = System.Drawing.Color.Black;
            DO_label10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DO_label10.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)((System.Int32)0)));
            DO_label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            DO_label10.Size = new System.Drawing.Size((System.Int32)10, (System.Int32)10);
            DO_label10.Location = new System.Drawing.Point((System.Int32)(DO_panel44.Width - (System.Int32)(DO_label10.Width * 1.4)), (System.Int32)((System.Int32)(DO_panel44.Height / 2) - DO_label10.Height));
            DO_label10.Margin = new System.Windows.Forms.Padding((System.Int32)0);
            DO_label10.Name = "DO_label10";
            DO_label10.TabIndex = (System.Int32)27;
            DO_label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            DO_label10.MouseMove += new System.Windows.Forms.MouseEventHandler(DO_Left_MouseMove);
            // 
            // DO_label4
            // 
            DO_label4.BackColor = System.Drawing.Color.Black;
            DO_label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DO_label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            DO_label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            DO_label4.Location = new System.Drawing.Point((System.Int32)0, (System.Int32)0);
            DO_label4.Margin = new System.Windows.Forms.Padding((System.Int32)0);
            DO_label4.Name = "DO_label4";
            DO_label4.Size = new System.Drawing.Size((System.Int32)10, (System.Int32)10);
            DO_label4.TabIndex = (System.Int32)24;
            DO_label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DO_label7
            // 
            DO_label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            DO_label7.BackColor = System.Drawing.Color.Black;
            DO_label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DO_label7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            DO_label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            DO_label7.Margin = new System.Windows.Forms.Padding(0);
            DO_label7.Name = "DO_label7";
            DO_label7.Size = new System.Drawing.Size(10, 10);
            DO_label7.Location = new System.Drawing.Point((System.Int32)((System.Int32)(DO_panel44.Width / 2) - DO_label7.Width), (System.Int32)0);
            DO_label7.TabIndex = (System.Int32)25;
            DO_label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DO_label9
            // 
            DO_label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            DO_label9.BackColor = System.Drawing.Color.Black;
            DO_label9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DO_label9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            DO_label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            DO_label9.Margin = new System.Windows.Forms.Padding((System.Int32)0);
            DO_label9.Name = "DO_label9";
            DO_label9.Size = new System.Drawing.Size((System.Int32)10, (System.Int32)10);
            DO_label9.Location = new System.Drawing.Point((System.Int32)((System.Int32)(DO_panel44.Width / 2) - DO_label9.Width), (System.Int32)(DO_panel44.Height - (System.Int32)(DO_label9.Height * 1.4)));
            DO_label9.TabIndex = (System.Int32)20;
            DO_label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            DO_label9.MouseMove += new System.Windows.Forms.MouseEventHandler(DO_Bottom_MouseMove);
            // 
            // DO_label6
            // 
            DO_label6.AutoSize = true;
            DO_label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DO_label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            DO_label6.ForeColor = System.Drawing.Color.DarkOrange;
            DO_label6.Size = new System.Drawing.Size((System.Int32)16, (System.Int32)15);
            DO_label6.Location = new System.Drawing.Point((System.Int32)20, (System.Int32)0);
            DO_label6.Name = "DO_label6";
            DO_label6.TabIndex = (System.Int32)17;
            DO_label6.Text = "▓";
            DO_label6.MouseDown += new System.Windows.Forms.MouseEventHandler(DO_DragDrop_MouseDown);
            // 
            // DO_label1
            // 
            DO_label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            DO_label1.BackColor = System.Drawing.Color.Black;
            DO_label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DO_label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            DO_label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            DO_label1.Margin = new System.Windows.Forms.Padding((System.Int32)0);
            DO_label1.Name = "DO_label1";
            DO_label1.Size = new System.Drawing.Size((System.Int32)10, (System.Int32)10);
            DO_label1.Location = new System.Drawing.Point((System.Int32)(DO_panel44.Width - (System.Int32)(DO_label1.Width * 1.4)), (System.Int32)(DO_panel44.Height - (System.Int32)(DO_label1.Height * 1.4)));
            DO_label1.TabIndex = (System.Int32)21;
            DO_label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DO_label2
            // 
            DO_label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            DO_label2.BackColor = System.Drawing.Color.Black;
            DO_label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DO_label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            DO_label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            DO_label2.Margin = new System.Windows.Forms.Padding((System.Int32)0);
            DO_label2.Name = "DO_label2";
            DO_label2.Size = new System.Drawing.Size((System.Int32)10, (System.Int32)10);
            DO_label2.Location = new System.Drawing.Point((System.Int32)0, (System.Int32)(DO_panel44.Height - (System.Int32)(DO_label2.Height * 1.4)));
            DO_label2.TabIndex = (System.Int32)22;
            DO_label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DO_label3
            // 
            DO_label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            DO_label3.BackColor = System.Drawing.Color.Black;
            DO_label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DO_label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            DO_label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            DO_label3.Margin = new System.Windows.Forms.Padding((System.Int32)0);
            DO_label3.Name = "DO_label3";
            DO_label3.Size = new System.Drawing.Size((System.Int32)10, (System.Int32)10);
            DO_label3.Location = new System.Drawing.Point((System.Int32)0, (System.Int32)((System.Int32)(DO_panel44.Height / 2) - DO_label3.Height));
            DO_label3.TabIndex = (System.Int32)23;
            DO_label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DO_label5
            // 
            DO_label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            DO_label5.AutoSize = true;
            DO_label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DO_label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            DO_label5.ForeColor = System.Drawing.Color.DarkOrange;
            DO_label5.Size = new System.Drawing.Size((System.Int32)15, (System.Int32)15);
            DO_label5.Location = new System.Drawing.Point((System.Int32)80, (System.Int32)0);
            DO_label5.Name = "DO_label5";
            DO_label5.TabIndex = (System.Int32)16;
            DO_label5.Text = "+";
            DO_label5.MouseDown += new System.Windows.Forms.MouseEventHandler(DO_ComponentEdition_MouseDown);
            // 
            // DO_panel4
            // 
            DO_panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            DO_panel4.BackColor = System.Drawing.Color.Transparent;
            DO_panel4.Location = new System.Drawing.Point((System.Int32)9, (System.Int32)9);
            DO_panel4.Margin = new System.Windows.Forms.Padding((System.Int32)0);
            DO_panel4.Name = "DO_panel4";
            DO_panel4.Size = new System.Drawing.Size((System.Int32)88, (System.Int32)78);
            DO_panel4.TabIndex = (System.Int32)12;

            DO_panel44.ResumeLayout(false);
            DO_panel44.PerformLayout();
            DO_panel4.ResumeLayout(false);
            DO_panel4.PerformLayout();
            DO_DesignObj = DO_panel44;
            DO_Container = DO_panel4;
            DO_DesignBasePanel = mainpanel;
            DO_DesignBasePanel.Controls.Add(DO_DesignObj);


        }

        public static void DO_DesignMode(this System.Windows.Forms.Form DO_Form, System.Boolean dd, System.Windows.Forms.Panel mainpanel )
        {

            DO_DesignBasePanel = mainpanel;
            if (!dd)
            {
                if (DO_ModeLock)
                {
                    DO_DesignComponent = null;
                    DO_ModeLock = false;
                    DO_DesignObj.Visible = false;
                    DO_DesignObJCloseOnly(DO_DesignBasePanel);
                    DO_DesignBasePanel.AllowDrop = false;
                    DO_DesignBasePanel.DragDrop -= new System.Windows.Forms.DragEventHandler(DO_DragDrop);
                    DO_DesignBasePanel.DragEnter -= new System.Windows.Forms.DragEventHandler(DO_DragEnter);
                    DO_DesignBasePanel.MouseClick -= new System.Windows.Forms.MouseEventHandler(DO_DesignObJCloseOnly);
                    ObjectManagedClose(DO_DesignBasePanel, LayerDept);
                }
            }
            else
            {
                if (!DO_ModeLock)
                {
                    DO_ModeLock = true;
                    DO_DesignBasePanel.AllowDrop = true;
                    DO_DesignBasePanel.DragDrop += new System.Windows.Forms.DragEventHandler(DO_DragDrop);
                    DO_DesignBasePanel.DragEnter += new System.Windows.Forms.DragEventHandler(DO_DragEnter);
                    DO_DesignBasePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(DO_DesignObJCloseOnly);
                    ObjectManagedOpen(DO_DesignBasePanel, LayerDept);
                }
            }
        }

        public static void DO_ComponentEdition_MouseDown_Event(this System.Windows.Forms.Form DO_Form, System.Windows.Forms.MouseEventHandler Event)
        {   DO_ComponentEditionalEvents = Event.Invoke;  }

        public static void DO_DragDropComponents_Update(this System.Windows.Forms.Form DO_Form, System.Collections.Generic.List<System.String> ComponentList)
        {   DO_DragDropComponents = ComponentList;  }

        public static void DO_EditionalComponents_Update(this System.Windows.Forms.Form DO_Form, System.Collections.Generic.List<System.String> ComponentList)
        {   DO_EditionalComponents = ComponentList; }


    }
}


