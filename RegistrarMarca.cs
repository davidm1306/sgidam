using sgidam.Data;
using sgidam.Models;
using System;
using System.Windows.Forms;

namespace sgidam
{
    public partial class RegistrarMarca : Form
    {
        public RegistrarMarca()
        {
            InitializeComponent();

            ConfigurarEventos();

            this.KeyPreview = true;
            this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) btnCancelar.PerformClick(); };
        }

        private void ConfigurarEventos()
        {
            txtNombreMarca.Leave += TxtNombreMarca_Leave;
        }

        private void TxtNombreMarca_Leave(object sender, EventArgs e)
        {
            Validaciones.ConvertirAMayusculas(sender, e);

            Validaciones.LimpiarYSanitizar(sender, e);

            string valor = txtNombreMarca.Text.Trim();
            if (valor.Length > 0 && valor.Length < 3)
            {
                MessageBox.Show("El nombre de la marca debe tener al menos 3 caracteres.",
                                "Longitud mínima",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtNombreMarca.Focus();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreMarca.Text))
            {
                MessageBox.Show("El nombre de la marca es obligatorio.", "Campo requerido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreMarca.Focus();
                return;
            }

            Validaciones.ConvertirAMayusculas(txtNombreMarca, EventArgs.Empty);
            Validaciones.LimpiarYSanitizar(txtNombreMarca, EventArgs.Empty);

            if (txtNombreMarca.Text.Trim().Length < 3)
            {
                MessageBox.Show("El nombre de la marca debe tener al menos 3 caracteres.",
                                "Longitud mínima",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtNombreMarca.Focus();
                return;
            }

            try
            {
                Marca nuevaMarca = new Marca
                {
                    NombreMarca = txtNombreMarca.Text.Trim()
                };

                bool exito = Marca.Registrar(nuevaMarca);

                if (exito)
                {
                    MessageBox.Show("Marca registrada con éxito.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al registrar la marca.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void RegistrarMarca_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnCancelar, "#bc4749", 2, "#bc4749");
            BotonesPersonalizados.EstiloBotonPildora(btnGuardar, "#98c1d9", 2, "#98c1d9");
        }
    }
}