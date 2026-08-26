namespace sgidam
{
    partial class InputDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputDialog));
            lblPrompt = new Label();
            btnOk = new Button();
            btnCancel = new Button();
            cmbOptions = new ComboBox();
            SuspendLayout();
            // 
            // lblPrompt
            // 
            lblPrompt.AutoSize = true;
            lblPrompt.Location = new Point(75, 32);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(38, 15);
            lblPrompt.TabIndex = 0;
            lblPrompt.Text = "label1";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(75, 95);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 33);
            btnOk.TabIndex = 2;
            btnOk.Text = "Aceptar";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(182, 95);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 33);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cmbOptions
            // 
            cmbOptions.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOptions.FormattingEnabled = true;
            cmbOptions.Location = new Point(76, 60);
            cmbOptions.Name = "cmbOptions";
            cmbOptions.Size = new Size(132, 23);
            cmbOptions.TabIndex = 4;
            // 
            // InputDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 251, 252);
            ClientSize = new Size(333, 180);
            Controls.Add(cmbOptions);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(lblPrompt);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InputDialog";
            Text = "InputDialog";
            Load += InputDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPrompt;
        private Button btnOk;
        private Button btnCancel;
        private ComboBox cmbOptions;
    }
}