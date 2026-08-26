using sgidam.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sgidam
{


    public partial class InputDialog : Form
    {
        public string Answer { get; private set; }

        public InputDialog(string title, string prompt, List<string> options, string defaultSelected = null)
        {
            InitializeComponent();

            this.Text = title;

            lblPrompt.Text = prompt;
            
            cmbOptions.DataSource = options;
            
            if (!string.IsNullOrEmpty(defaultSelected) && options.Contains(defaultSelected))
                cmbOptions.SelectedItem = defaultSelected;
            else if (options.Count > 0)
                cmbOptions.SelectedIndex = 0;

            cmbOptions.Focus();
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnOk, "#98c1d9", 2, "#98c1d9");
            BotonesPersonalizados.EstiloBotonPildora(btnCancel, "#bc4749", 2, "#bc4749");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Answer = cmbOptions.SelectedItem?.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void InputDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel_Click(sender, e);
        }
    }
}
