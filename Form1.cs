using MySql.Data.MySqlClient;
using sgidam.Data;
using sgidam.Models;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;

namespace sgidam
{
    public partial class FormInicioDeSesion : Form
    {
        private bool mostrarPasswword = false;
        public FormInicioDeSesion()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            BotonesPersonalizados.EstiloBotonPildora(btnIngresar, "#98c1d9", 2, "#98c1d9");
            BotonesPersonalizados.EstiloBotonPildora(btnLimpiar, "#f4a261", 2, "#f4a261");


        }

        private int _intentosFallidos = 0;


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor, ingresa tu usuario y contraseña.", "Campos vacíos",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoginResult resultado = Usuario.ValidarLogin(txtUsuario.Text.Trim(), txtPassword.Text);

            if (resultado.Success)
            {
                _intentosFallidos = 0;
                Global.UsuarioSesion = resultado.Usuario;

                MessageBox.Show($"¡Bienvenido {Global.UsuarioSesion.nombre_empleado}!",
                                "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                btnLimpiar.PerformClick();

                this.Hide();

                MenuPrincipal frmPrincipal = new MenuPrincipal();
                frmPrincipal.ShowDialog();

                if (Global.UsuarioSesion == null)
                {
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                _intentosFallidos++;

                MessageBox.Show(resultado.Message, "Error de autenticación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (resultado.Message == "Usuario inactivo. Contacte al administrador.")
                {
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                if (_intentosFallidos >= 3)
                {
                    MessageBox.Show("Has superado el número máximo de intentos (3). La aplicación se cerrará.",
                                    "Demasiados intentos fallidos",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
                else
                {
                    int intentosRestantes = 3 - _intentosFallidos;
                    MessageBox.Show($"Te quedan {intentosRestantes} intento(s).",
                                    "Intento fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtPassword.Clear();
            txtUsuario_Leave(sender, e);
            txtPassword_Leave(sender, e);
            // txtUsuario.Focus();
        }

        private void FormInicioDeSesion_Paint(object sender, PaintEventArgs e)
        {

            DibujarLinea.LineaRectaInferior(txtUsuario, "#3d5a80", e);
            DibujarLinea.LineaRectaInferior(txtPassword, "#3d5a80", e);
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "CONTRASEÑA")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "CONTRASEÑA";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void pbShow_Click(object sender, EventArgs e)
        {
            mostrarPasswword = !mostrarPasswword;

            if (txtPassword.Text != "CONTRASEÑA" && mostrarPasswword)
            {
                txtPassword.UseSystemPasswordChar = false;
                pbShow.Image = sgidam.Properties.Resources.ocultar_password;
            }
            else if (txtPassword.Text != "CONTRASEÑA")
            {
                txtPassword.UseSystemPasswordChar = true;
                pbShow.Image = sgidam.Properties.Resources.ver_password;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIngresar.PerformClick();
            }
        }
    }
}
