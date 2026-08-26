using sgidam.Data;
using sgidam.Models;
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
    public partial class RegistrarCategoria : Form
    {
        public RegistrarCategoria()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) btnCancelar.PerformClick(); };
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCategoria.Text))
            {
                MessageBox.Show("El nombre de la categoría es obligatorio.", "Campo requerido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCategoria.Focus();
                return;
            }

            try
            {
                Categoria nuevaCategoria = new Categoria
                {
                    NombreCategoria = txtNombreCategoria.Text.Trim()
                };

                bool exito = Categoria.Registrar(nuevaCategoria);

                if (exito)
                {
                    MessageBox.Show("Categoría registrada con éxito.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al registrar la categoría.", "Error",
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

        private void RegistrarCategoria_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnCancelar, "#bc4749", 2, "#bc4749");
            BotonesPersonalizados.EstiloBotonPildora(btnGuardar, "#98c1d9", 2, "#98c1d9");
        }
    }
}
