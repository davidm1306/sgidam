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
            txtBuscar = new TextBox();
            lstProductos = new ListBox();
            label1 = new Label();
            btnEditar = new Button();
            btnCerrar = new Button();
            lblFiltro = new Label();
            lblTotal = new Label();
            cmbFiltroEstatus = new ComboBox();
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
            // txtBuscar
            // 
            txtBuscar.BackColor = Color.FromArgb(224, 251, 252);
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Location = new Point(174, 40);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(199, 16);
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
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Location = new Point(391, 44);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(98, 15);
            lblFiltro.TabIndex = 8;
            lblFiltro.Text = "Filtrar por Estatus";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(641, 43);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(32, 15);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "Total";
            // 
            // cmbFiltroEstatus
            // 
            cmbFiltroEstatus.FormattingEnabled = true;
            cmbFiltroEstatus.Location = new Point(495, 40);
            cmbFiltroEstatus.Name = "cmbFiltroEstatus";
            cmbFiltroEstatus.Size = new Size(121, 23);
            cmbFiltroEstatus.TabIndex = 10;
            // 
            // MostrarProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(988, 450);
            Controls.Add(cmbFiltroEstatus);
            Controls.Add(lblTotal);
            Controls.Add(lblFiltro);
            Controls.Add(btnCerrar);
            Controls.Add(btnEditar);
            Controls.Add(label1);
            Controls.Add(lstProductos);
            Controls.Add(txtBuscar);
            Controls.Add(dgvProveedores);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MostrarProveedores";
            Text = "MostrarProveedores";
            Load += MostrarProveedores_Load;
            Paint += MostrarProveedores_Paint;
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
        private Label lblFiltro;
        private Label lblTotal;
        private ComboBox cmbFiltroEstatus;
    }
}