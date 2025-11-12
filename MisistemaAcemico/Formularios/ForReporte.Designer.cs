namespace MisistemaAcemico.Formularios
{
    partial class ForReporte
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
            lblTitulo = new Label();
            lblBuscarEst = new Label();
            txtBuscarEst = new TextBox();
            btnBuscarEst = new Button();
            btnCargarDatos = new Button();
            dgvReportes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Image = Properties.Resources.Fondo__1_;
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(239, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reporte de Estudiantes";
            // 
            // lblBuscarEst
            // 
            lblBuscarEst.AutoSize = true;
            lblBuscarEst.Location = new Point(379, 58);
            lblBuscarEst.Name = "lblBuscarEst";
            lblBuscarEst.Size = new Size(103, 15);
            lblBuscarEst.TabIndex = 1;
            lblBuscarEst.Text = "Buscar Estudiante:";
            // 
            // txtBuscarEst
            // 
            txtBuscarEst.Location = new Point(496, 55);
            txtBuscarEst.Name = "txtBuscarEst";
            txtBuscarEst.Size = new Size(150, 23);
            txtBuscarEst.TabIndex = 2;
            // 
            // btnBuscarEst
            // 
            btnBuscarEst.Location = new Point(652, 54);
            btnBuscarEst.Name = "btnBuscarEst";
            btnBuscarEst.Size = new Size(75, 23);
            btnBuscarEst.TabIndex = 3;
            btnBuscarEst.Text = "🔍 Buscar";
            btnBuscarEst.UseVisualStyleBackColor = true;
            btnBuscarEst.Click += btnBuscarEst_Click;
            // 
            // btnCargarDatos
            // 
            btnCargarDatos.Location = new Point(12, 54);
            btnCargarDatos.Name = "btnCargarDatos";
            btnCargarDatos.Size = new Size(100, 25);
            btnCargarDatos.TabIndex = 10;
            btnCargarDatos.Text = "Cargar Datos";
            btnCargarDatos.UseVisualStyleBackColor = true;
            btnCargarDatos.Click += btnCargarDatos_Click;
            // 
            // dgvReportes
            // 
            dgvReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportes.Location = new Point(12, 95);
            dgvReportes.Name = "dgvReportes";
            dgvReportes.Size = new Size(715, 235);
            dgvReportes.TabIndex = 11;
            // 
            // ForReporte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo__1_;
            ClientSize = new Size(748, 362);
            Controls.Add(dgvReportes);
            Controls.Add(btnCargarDatos);
            Controls.Add(btnBuscarEst);
            Controls.Add(txtBuscarEst);
            Controls.Add(lblBuscarEst);
            Controls.Add(lblTitulo);
            Name = "ForReporte";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte de Estudiantes";
            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscarEst;
        private System.Windows.Forms.TextBox txtBuscarEst;
        private System.Windows.Forms.Button btnBuscarEst;
        private System.Windows.Forms.Label lblAsignatura;
        private System.Windows.Forms.ComboBox cboAsignatura;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.ComboBox cboGenero;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Button btnCargarDatos;
        private System.Windows.Forms.DataGridView dgvReportes;
    }
}