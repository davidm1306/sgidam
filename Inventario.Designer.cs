namespace sgidam
{
    partial class Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            label1 = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvInventario = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 45);
            label1.Name = "label1";
            label1.Size = new Size(275, 15);
            label1.TabIndex = 0;
            label1.Text = "Introduzca nombre del producto o codigo de barra";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(365, 44);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(129, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.KeyPress += txtBuscar_KeyPress;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(533, 37);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 31);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvInventario
            // 
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Location = new Point(39, 112);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.Size = new Size(943, 505);
            dgvInventario.TabIndex = 3;
            // 
            // Inventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(1018, 644);
            Controls.Add(dgvInventario);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Inventario";
            Text = "Inventario";
            Load += Inventario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvInventario;
    }
}