using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using utility_handler.Utility;

namespace Encryptor
{
    public partial class frmEncryptor : Form
    {
        public frmEncryptor()
        {
            InitializeComponent();
            txtOutput.ReadOnly = true;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text.Trim())) return;
            lblOutput.Text = "Decrypted Text";
            txtOutput.Text = Misc.deCrypt(txtInput.Text.Trim());
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text.Trim())) return;
            lblOutput.Text = "Encrypted Text";
            txtOutput.Text = Misc.enCrypt(txtInput.Text.Trim());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
