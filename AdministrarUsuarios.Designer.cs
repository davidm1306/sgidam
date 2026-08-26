namespace sgidam
{
    partial class AdministrarUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministrarUsuarios));
            dgvUsuarios = new DataGridView();
            btnCambiarEstatus = new Button();
            btnCambiarRol = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(47, 22);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(730, 165);
            dgvUsuarios.TabIndex = 0;
            // 
            // btnCambiarEstatus
            // 
            btnCambiarEstatus.Location = new Point(268, 229);
            btnCambiarEstatus.Name = "btnCambiarEstatus";
            btnCambiarEstatus.Size = new Size(129, 32);
            btnCambiarEstatus.TabIndex = 1;
            btnCambiarEstatus.Text = "Cambiar Estatus";
            btnCambiarEstatus.UseVisualStyleBackColor = true;
            btnCambiarEstatus.Click += btnCambiarEstatus_Click;
            // 
            // btnCambiarRol
            // 
            btnCambiarRol.Location = new Point(444, 229);
            btnCambiarRol.Name = "btnCambiarRol";
            btnCambiarRol.Size = new Size(101, 32);
            btnCambiarRol.TabIndex = 2;
            btnCambiarRol.Text = "Cambiar Rol";
            btnCambiarRol.UseVisualStyleBackColor = true;
            btnCambiarRol.Click += btnCambiarRol_Click;
            // 
            // AdministrarUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(821, 302);
            Controls.Add(btnCambiarRol);
            Controls.Add(btnCambiarEstatus);
            Controls.Add(dgvUsuarios);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdministrarUsuarios";
            Text = "AdministrarUsuarios";
            Load += AdministrarUsuarios_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsuarios;
        private Button btnCambiarEstatus;
        private Button btnCambiarRol;
    }
}