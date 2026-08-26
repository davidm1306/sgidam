namespace sgidam
{
    partial class MostrarProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MostrarProveedores));
            dgvProveedores = new DataGridView();
            chkOcultarInactivos = new CheckBox();
            txtBuscar = new TextBox();
            lstProductos = new ListBox();
            label1 = new Label();
            btnBuscar = new Button();
            btnEditar = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            SuspendLayout();
            // 
            // dgvProveedores
            // 
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Location = new Point(31, 115);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.Size = new Size(927, 150);
            dgvProveedores.TabIndex = 0;
            // 
            // chkOcultarInactivos
            // 
            chkOcultarInactivos.AutoSize = true;
            chkOcultarInactivos.Checked = true;
            chkOcultarInactivos.CheckState = CheckState.Checked;
            chkOcultarInactivos.Location = new Point(495, 43);
            chkOcultarInactivos.Name = "chkOcultarInactivos";
            chkOcultarInactivos.Size = new Size(115, 19);
            chkOcultarInactivos.TabIndex = 1;
            chkOcultarInactivos.Text = "Ocultar Inactivos";
            chkOcultarInactivos.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(174, 40);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(163, 23);
            txtBuscar.TabIndex = 2;
            // 
            // lstProductos
            // 
            lstProductos.FormattingEnabled = true;
            lstProductos.ItemHeight = 15;
            lstProductos.Location = new Point(31, 284);
            lstProductos.Name = "lstProductos";
            lstProductos.Size = new Size(306, 154);
            lstProductos.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 43);
            label1.Name = "label1";
            label1.Size = new Size(137, 15);
            label1.TabIndex = 4;
            label1.Text = "Buscar por nombre o RIF";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(386, 33);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 35);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(568, 346);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 34);
            btnEditar.TabIndex = 6;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(690, 346);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 34);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // MostrarProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(988, 450);
            Controls.Add(btnCerrar);
            Controls.Add(btnEditar);
            Controls.Add(btnBuscar);
            Controls.Add(label1);
            Controls.Add(lstProductos);
            Controls.Add(txtBuscar);
            Controls.Add(chkOcultarInactivos);
            Controls.Add(dgvProveedores);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MostrarProveedores";
            Text = "MostrarProveedores";
            Load += MostrarProveedores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProveedores;
        private CheckBox chkOcultarInactivos;
        private TextBox txtBuscar;
        private ListBox lstProductos;
        private Label label1;
        private Button btnBuscar;
        private Button btnEditar;
        private Button btnCerrar;
    }
}