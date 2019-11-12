namespace ngg
{
    partial class NGG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NGG));
            this.groupBox_sgsn = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_nri_hex = new System.Windows.Forms.TextBox();
            this.label_sgsn_dec = new System.Windows.Forms.Label();
            this.label_nl = new System.Windows.Forms.Label();
            this.textBox_nl = new System.Windows.Forms.TextBox();
            this.textBox_nri = new System.Windows.Forms.TextBox();
            this.label_nri = new System.Windows.Forms.Label();
            this.groupBox_mme = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_mme_dec = new System.Windows.Forms.Label();
            this.textBox_mc_hex = new System.Windows.Forms.TextBox();
            this.textBox_mgi_hex = new System.Windows.Forms.TextBox();
            this.label_mc = new System.Windows.Forms.Label();
            this.textBox_mc = new System.Windows.Forms.TextBox();
            this.textBox_mgi = new System.Windows.Forms.TextBox();
            this.label_mgi = new System.Windows.Forms.Label();
            this.groupBox_amf = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ap_hex = new System.Windows.Forms.TextBox();
            this.textBox_asi_hex = new System.Windows.Forms.TextBox();
            this.textBox_ari_hex = new System.Windows.Forms.TextBox();
            this.label_amf_dec = new System.Windows.Forms.Label();
            this.label_ap = new System.Windows.Forms.Label();
            this.textBox_ap = new System.Windows.Forms.TextBox();
            this.label_asi = new System.Windows.Forms.Label();
            this.textBox_asi = new System.Windows.Forms.TextBox();
            this.textBox_ari = new System.Windows.Forms.TextBox();
            this.label_ari = new System.Windows.Forms.Label();
            this.label_alarm = new System.Windows.Forms.Label();
            this.textBox_alarm = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_sgsn.SuspendLayout();
            this.groupBox_mme.SuspendLayout();
            this.groupBox_amf.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_sgsn
            // 
            this.groupBox_sgsn.Controls.Add(this.label1);
            this.groupBox_sgsn.Controls.Add(this.textBox_nri_hex);
            this.groupBox_sgsn.Controls.Add(this.label_sgsn_dec);
            this.groupBox_sgsn.Controls.Add(this.label_nl);
            this.groupBox_sgsn.Controls.Add(this.textBox_nl);
            this.groupBox_sgsn.Controls.Add(this.textBox_nri);
            this.groupBox_sgsn.Controls.Add(this.label_nri);
            this.groupBox_sgsn.Location = new System.Drawing.Point(12, 10);
            this.groupBox_sgsn.Name = "groupBox_sgsn";
            this.groupBox_sgsn.Size = new System.Drawing.Size(335, 131);
            this.groupBox_sgsn.TabIndex = 100;
            this.groupBox_sgsn.TabStop = false;
            this.groupBox_sgsn.Text = "SGSN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 100;
            this.label1.Text = "Hex：";
            // 
            // textBox_nri_hex
            // 
            this.textBox_nri_hex.Location = new System.Drawing.Point(65, 90);
            this.textBox_nri_hex.Name = "textBox_nri_hex";
            this.textBox_nri_hex.ReadOnly = true;
            this.textBox_nri_hex.Size = new System.Drawing.Size(100, 26);
            this.textBox_nri_hex.TabIndex = 2;
            // 
            // label_sgsn_dec
            // 
            this.label_sgsn_dec.AutoSize = true;
            this.label_sgsn_dec.Location = new System.Drawing.Point(8, 58);
            this.label_sgsn_dec.Name = "label_sgsn_dec";
            this.label_sgsn_dec.Size = new System.Drawing.Size(46, 20);
            this.label_sgsn_dec.TabIndex = 100;
            this.label_sgsn_dec.Text = "Dec：";
            // 
            // label_nl
            // 
            this.label_nl.AutoSize = true;
            this.label_nl.Location = new System.Drawing.Point(203, 31);
            this.label_nl.Name = "label_nl";
            this.label_nl.Size = new System.Drawing.Size(91, 20);
            this.label_nl.TabIndex = 100;
            this.label_nl.Text = "NRI Length";
            // 
            // textBox_nl
            // 
            this.textBox_nl.Location = new System.Drawing.Point(207, 55);
            this.textBox_nl.Name = "textBox_nl";
            this.textBox_nl.Size = new System.Drawing.Size(100, 26);
            this.textBox_nl.TabIndex = 1;
            this.textBox_nl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_nl_KeyUp);
            // 
            // textBox_nri
            // 
            this.textBox_nri.Location = new System.Drawing.Point(65, 55);
            this.textBox_nri.Name = "textBox_nri";
            this.textBox_nri.Size = new System.Drawing.Size(100, 26);
            this.textBox_nri.TabIndex = 0;
            this.textBox_nri.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_nri_KeyUp);
            // 
            // label_nri
            // 
            this.label_nri.AutoSize = true;
            this.label_nri.Location = new System.Drawing.Point(61, 31);
            this.label_nri.Name = "label_nri";
            this.label_nri.Size = new System.Drawing.Size(37, 20);
            this.label_nri.TabIndex = 100;
            this.label_nri.Text = "NRI";
            // 
            // groupBox_mme
            // 
            this.groupBox_mme.Controls.Add(this.label4);
            this.groupBox_mme.Controls.Add(this.label_mme_dec);
            this.groupBox_mme.Controls.Add(this.textBox_mc_hex);
            this.groupBox_mme.Controls.Add(this.textBox_mgi_hex);
            this.groupBox_mme.Controls.Add(this.label_mc);
            this.groupBox_mme.Controls.Add(this.textBox_mc);
            this.groupBox_mme.Controls.Add(this.textBox_mgi);
            this.groupBox_mme.Controls.Add(this.label_mgi);
            this.groupBox_mme.Location = new System.Drawing.Point(12, 147);
            this.groupBox_mme.Name = "groupBox_mme";
            this.groupBox_mme.Size = new System.Drawing.Size(335, 126);
            this.groupBox_mme.TabIndex = 4;
            this.groupBox_mme.TabStop = false;
            this.groupBox_mme.Text = "MME";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hex：";
            // 
            // label_mme_dec
            // 
            this.label_mme_dec.AutoSize = true;
            this.label_mme_dec.Location = new System.Drawing.Point(8, 55);
            this.label_mme_dec.Name = "label_mme_dec";
            this.label_mme_dec.Size = new System.Drawing.Size(46, 20);
            this.label_mme_dec.TabIndex = 5;
            this.label_mme_dec.Text = "Dec：";
            // 
            // textBox_mc_hex
            // 
            this.textBox_mc_hex.Location = new System.Drawing.Point(207, 85);
            this.textBox_mc_hex.Name = "textBox_mc_hex";
            this.textBox_mc_hex.ReadOnly = true;
            this.textBox_mc_hex.Size = new System.Drawing.Size(100, 26);
            this.textBox_mc_hex.TabIndex = 6;
            // 
            // textBox_mgi_hex
            // 
            this.textBox_mgi_hex.Location = new System.Drawing.Point(65, 85);
            this.textBox_mgi_hex.Name = "textBox_mgi_hex";
            this.textBox_mgi_hex.ReadOnly = true;
            this.textBox_mgi_hex.Size = new System.Drawing.Size(112, 26);
            this.textBox_mgi_hex.TabIndex = 5;
            // 
            // label_mc
            // 
            this.label_mc.AutoSize = true;
            this.label_mc.Location = new System.Drawing.Point(203, 28);
            this.label_mc.Name = "label_mc";
            this.label_mc.Size = new System.Drawing.Size(88, 20);
            this.label_mc.TabIndex = 3;
            this.label_mc.Text = "MME Code";
            // 
            // textBox_mc
            // 
            this.textBox_mc.Location = new System.Drawing.Point(207, 52);
            this.textBox_mc.Name = "textBox_mc";
            this.textBox_mc.Size = new System.Drawing.Size(100, 26);
            this.textBox_mc.TabIndex = 4;
            this.textBox_mc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_mc_KeyUp);
            // 
            // textBox_mgi
            // 
            this.textBox_mgi.Location = new System.Drawing.Point(65, 52);
            this.textBox_mgi.Name = "textBox_mgi";
            this.textBox_mgi.Size = new System.Drawing.Size(112, 26);
            this.textBox_mgi.TabIndex = 3;
            this.textBox_mgi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_mgi_KeyUp);
            // 
            // label_mgi
            // 
            this.label_mgi.AutoSize = true;
            this.label_mgi.Location = new System.Drawing.Point(61, 28);
            this.label_mgi.Name = "label_mgi";
            this.label_mgi.Size = new System.Drawing.Size(116, 20);
            this.label_mgi.TabIndex = 0;
            this.label_mgi.Text = "MME Group ID";
            // 
            // groupBox_amf
            // 
            this.groupBox_amf.Controls.Add(this.label2);
            this.groupBox_amf.Controls.Add(this.textBox_ap_hex);
            this.groupBox_amf.Controls.Add(this.textBox_asi_hex);
            this.groupBox_amf.Controls.Add(this.textBox_ari_hex);
            this.groupBox_amf.Controls.Add(this.label_amf_dec);
            this.groupBox_amf.Controls.Add(this.label_ap);
            this.groupBox_amf.Controls.Add(this.textBox_ap);
            this.groupBox_amf.Controls.Add(this.label_asi);
            this.groupBox_amf.Controls.Add(this.textBox_asi);
            this.groupBox_amf.Controls.Add(this.textBox_ari);
            this.groupBox_amf.Controls.Add(this.label_ari);
            this.groupBox_amf.Location = new System.Drawing.Point(12, 279);
            this.groupBox_amf.Name = "groupBox_amf";
            this.groupBox_amf.Size = new System.Drawing.Size(458, 132);
            this.groupBox_amf.TabIndex = 5;
            this.groupBox_amf.TabStop = false;
            this.groupBox_amf.Text = "AMF";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Hex:";
            // 
            // textBox_ap_hex
            // 
            this.textBox_ap_hex.Location = new System.Drawing.Point(334, 92);
            this.textBox_ap_hex.Name = "textBox_ap_hex";
            this.textBox_ap_hex.ReadOnly = true;
            this.textBox_ap_hex.Size = new System.Drawing.Size(100, 26);
            this.textBox_ap_hex.TabIndex = 12;
            // 
            // textBox_asi_hex
            // 
            this.textBox_asi_hex.Location = new System.Drawing.Point(207, 92);
            this.textBox_asi_hex.Name = "textBox_asi_hex";
            this.textBox_asi_hex.ReadOnly = true;
            this.textBox_asi_hex.Size = new System.Drawing.Size(100, 26);
            this.textBox_asi_hex.TabIndex = 11;
            // 
            // textBox_ari_hex
            // 
            this.textBox_ari_hex.Location = new System.Drawing.Point(65, 92);
            this.textBox_ari_hex.Name = "textBox_ari_hex";
            this.textBox_ari_hex.ReadOnly = true;
            this.textBox_ari_hex.Size = new System.Drawing.Size(112, 26);
            this.textBox_ari_hex.TabIndex = 10;
            // 
            // label_amf_dec
            // 
            this.label_amf_dec.AutoSize = true;
            this.label_amf_dec.Location = new System.Drawing.Point(8, 59);
            this.label_amf_dec.Name = "label_amf_dec";
            this.label_amf_dec.Size = new System.Drawing.Size(46, 20);
            this.label_amf_dec.TabIndex = 6;
            this.label_amf_dec.Text = "Dec：";
            // 
            // label_ap
            // 
            this.label_ap.AutoSize = true;
            this.label_ap.Location = new System.Drawing.Point(330, 32);
            this.label_ap.Name = "label_ap";
            this.label_ap.Size = new System.Drawing.Size(92, 20);
            this.label_ap.TabIndex = 5;
            this.label_ap.Text = "Amf Pointer";
            // 
            // textBox_ap
            // 
            this.textBox_ap.Location = new System.Drawing.Point(334, 56);
            this.textBox_ap.Name = "textBox_ap";
            this.textBox_ap.Size = new System.Drawing.Size(100, 26);
            this.textBox_ap.TabIndex = 9;
            this.textBox_ap.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_ap_KeyUp);
            // 
            // label_asi
            // 
            this.label_asi.AutoSize = true;
            this.label_asi.Location = new System.Drawing.Point(203, 32);
            this.label_asi.Name = "label_asi";
            this.label_asi.Size = new System.Drawing.Size(85, 20);
            this.label_asi.TabIndex = 3;
            this.label_asi.Text = "Amf Set Id";
            // 
            // textBox_asi
            // 
            this.textBox_asi.Location = new System.Drawing.Point(207, 56);
            this.textBox_asi.Name = "textBox_asi";
            this.textBox_asi.Size = new System.Drawing.Size(100, 26);
            this.textBox_asi.TabIndex = 8;
            this.textBox_asi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_asi_KeyUp);
            // 
            // textBox_ari
            // 
            this.textBox_ari.Location = new System.Drawing.Point(65, 56);
            this.textBox_ari.Name = "textBox_ari";
            this.textBox_ari.Size = new System.Drawing.Size(112, 26);
            this.textBox_ari.TabIndex = 7;
            this.textBox_ari.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_ari_KeyUp);
            // 
            // label_ari
            // 
            this.label_ari.AutoSize = true;
            this.label_ari.Location = new System.Drawing.Point(61, 32);
            this.label_ari.Name = "label_ari";
            this.label_ari.Size = new System.Drawing.Size(111, 20);
            this.label_ari.TabIndex = 0;
            this.label_ari.Text = "Amf Region Id";
            // 
            // label_alarm
            // 
            this.label_alarm.AutoSize = true;
            this.label_alarm.ForeColor = System.Drawing.Color.Red;
            this.label_alarm.Location = new System.Drawing.Point(417, 40);
            this.label_alarm.Name = "label_alarm";
            this.label_alarm.Size = new System.Drawing.Size(0, 20);
            this.label_alarm.TabIndex = 6;
            // 
            // textBox_alarm
            // 
            this.textBox_alarm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_alarm.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_alarm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_alarm.ForeColor = System.Drawing.Color.Red;
            this.textBox_alarm.Location = new System.Drawing.Point(356, 50);
            this.textBox_alarm.Multiline = true;
            this.textBox_alarm.Name = "textBox_alarm";
            this.textBox_alarm.ReadOnly = true;
            this.textBox_alarm.Size = new System.Drawing.Size(205, 215);
            this.textBox_alarm.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(413, 4);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(151, 33);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // NGG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(573, 435);
            this.Controls.Add(this.textBox_alarm);
            this.Controls.Add(this.label_alarm);
            this.Controls.Add(this.groupBox_amf);
            this.Controls.Add(this.groupBox_mme);
            this.Controls.Add(this.groupBox_sgsn);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NGG";
            this.Text = "NGG";
            this.groupBox_sgsn.ResumeLayout(false);
            this.groupBox_sgsn.PerformLayout();
            this.groupBox_mme.ResumeLayout(false);
            this.groupBox_mme.PerformLayout();
            this.groupBox_amf.ResumeLayout(false);
            this.groupBox_amf.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_sgsn;
        private System.Windows.Forms.TextBox textBox_nri;
        private System.Windows.Forms.Label label_nri;
        private System.Windows.Forms.Label label_nl;
        private System.Windows.Forms.TextBox textBox_nl;
        private System.Windows.Forms.GroupBox groupBox_mme;
        private System.Windows.Forms.Label label_mc;
        private System.Windows.Forms.TextBox textBox_mc;
        private System.Windows.Forms.TextBox textBox_mgi;
        private System.Windows.Forms.Label label_mgi;
        private System.Windows.Forms.GroupBox groupBox_amf;
        private System.Windows.Forms.Label label_asi;
        private System.Windows.Forms.TextBox textBox_asi;
        private System.Windows.Forms.TextBox textBox_ari;
        private System.Windows.Forms.Label label_ari;
        private System.Windows.Forms.Label label_ap;
        private System.Windows.Forms.TextBox textBox_ap;
        private System.Windows.Forms.Label label_alarm;
        private System.Windows.Forms.TextBox textBox_alarm;
        private System.Windows.Forms.Label label_sgsn_dec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_mme_dec;
        private System.Windows.Forms.Label label_amf_dec;
        private System.Windows.Forms.TextBox textBox_mc_hex;
        private System.Windows.Forms.TextBox textBox_mgi_hex;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_nri_hex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ap_hex;
        private System.Windows.Forms.TextBox textBox_asi_hex;
        private System.Windows.Forms.TextBox textBox_ari_hex;
    }
}

