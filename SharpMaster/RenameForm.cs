using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharpMaster
{
    public partial class RenameForm : Form
    {
        public RenameForm()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAccept.PerformClick();
            }
        }

        private void RenameForm_Load(object sender, EventArgs e)
        {
            textBox.AutoSize = false;
            textBox.Focus();
        }
    }
}
