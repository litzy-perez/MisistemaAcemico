namespace MisistemaAcemico
{
    partial class FormPeriodos
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
            label1 = new Label();
            dgvPeriodos = new DataGridView();
            lblAnio = new Label();
            cboAnio = new ComboBox();
            lblCiclo = new Label();
            cboCiclo = new ComboBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPeriodos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Gabriola", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Image = Properties.Resources.Fondo__1_;
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(125, 9);
            label1.Name = "label1";
            label1.Size = new Size(320, 52);
            label1.TabIndex = 3;
            label1.Text = "Gestión de Periodos Academicos";
            label1.UseMnemonic = false;
            label1.UseWaitCursor = true;
            // 
            // dgvPeriodos
            // 
            dgvPeriodos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeriodos.Location = new Point(25, 93);
            dgvPeriodos.Name = "dgvPeriodos";
            dgvPeriodos.Size = new Size(304, 123);
            dgvPeriodos.TabIndex = 4;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(363, 118);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(32, 15);
            lblAnio.TabIndex = 5;
            lblAnio.Text = "Año:";
            // 
            // cboAnio
            // 
            cboAnio.FormattingEnabled = true;
            cboAnio.Location = new Point(418, 110);
            cboAnio.Name = "cboAnio";
            cboAnio.Size = new Size(121, 23);
            cboAnio.TabIndex = 6;
            // 
            // lblCiclo
            // 
            lblCiclo.AutoSize = true;
            lblCiclo.Location = new Point(363, 145);
            lblCiclo.Name = "lblCiclo";
            lblCiclo.Size = new Size(37, 15);
            lblCiclo.TabIndex = 7;
            lblCiclo.Text = "Ciclo:";
            // 
            // cboCiclo
            // 
            cboCiclo.FormattingEnabled = true;
            cboCiclo.Location = new Point(418, 139);
            cboCiclo.Name = "cboCiclo";
            cboCiclo.Size = new Size(121, 23);
            cboCiclo.TabIndex = 8;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(418, 204);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(85, 29);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click_1;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(83, 222);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(93, 29);
            btnModificar.TabIndex = 10;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click_1;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(183, 222);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(89, 29);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click_1;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(255, 192, 192);
            btnSalir.Font = new Font("Century", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.Location = new Point(541, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(40, 26);
            btnSalir.TabIndex = 12;
            btnSalir.Text = "X";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click_1;
            // 
            // FormPeriodos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo__1_;
            ClientSize = new Size(584, 361);
            ControlBox = false;
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(cboCiclo);
            Controls.Add(lblCiclo);
            Controls.Add(cboAnio);
            Controls.Add(lblAnio);
            Controls.Add(dgvPeriodos);
            Controls.Add(label1);
            Name = "FormPeriodos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPeriodos";
            Load += FormPeriodos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPeriodos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvPeriodos;
        private Label lblAnio;
        private ComboBox cboAnio;
        private Label lblCiclo;
        private ComboBox cboCiclo;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnSalir;
    }
}