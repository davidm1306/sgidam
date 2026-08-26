namespace sgidam
{
    partial class RegistrarCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarCategoria));
            btnCancelar = new Button();
            btnGuardar = new Button();
            txtNombreCategoria = new TextBox();
            lblNombreCategoria = new Label();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(172, 94);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(79, 40);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(86, 94);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(80, 40);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtNombreCategoria
            // 
            txtNombreCategoria.Location = new Point(172, 38);
            txtNombreCategoria.MaxLength = 45;
            txtNombreCategoria.Name = "txtNombreCategoria";
            txtNombreCategoria.Size = new Size(100, 23);
            txtNombreCategoria.TabIndex = 1;
            // 
            // lblNombreCategoria
            // 
            lblNombreCategoria.AutoSize = true;
            lblNombreCategoria.Location = new Point(35, 41);
            lblNombreCategoria.Name = "lblNombreCategoria";
            lblNombreCategoria.Size = new Size(131, 15);
            lblNombreCategoria.TabIndex = 4;
            lblNombreCategoria.Text = "Nombre de la categoría";
            // 
            // RegistrarCategoria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(322, 163);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtNombreCategoria);
            Controls.Add(lblNombreCategoria);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RegistrarCategoria";
            Text = "RegistrarCategoria";
            Load += RegistrarCategoria_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnGuardar;
        private TextBox txtNombreCategoria;
        private Label lblNombreCategoria;
    }
}