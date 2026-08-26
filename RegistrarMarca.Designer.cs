namespace sgidam
{
    partial class RegistrarMarca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarMarca));
            lblNombreMarca = new Label();
            txtNombreMarca = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblNombreMarca
            // 
            lblNombreMarca.AutoSize = true;
            lblNombreMarca.Location = new Point(21, 28);
            lblNombreMarca.Name = "lblNombreMarca";
            lblNombreMarca.Size = new Size(115, 15);
            lblNombreMarca.TabIndex = 0;
            lblNombreMarca.Text = "Nombre de la marca";
            // 
            // txtNombreMarca
            // 
            txtNombreMarca.Location = new Point(142, 25);
            txtNombreMarca.MaxLength = 45;
            txtNombreMarca.Name = "txtNombreMarca";
            txtNombreMarca.Size = new Size(100, 23);
            txtNombreMarca.TabIndex = 1;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(56, 81);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(80, 36);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(142, 81);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(79, 36);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // RegistrarMarca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(262, 146);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtNombreMarca);
            Controls.Add(lblNombreMarca);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RegistrarMarca";
            Text = "RegistrarMarca";
            Load += RegistrarMarca_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreMarca;
        private TextBox txtNombreMarca;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}