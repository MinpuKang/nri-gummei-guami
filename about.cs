using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ngg
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void linkLabel_mail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MinpuKang/nri-gummei-guami");
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
