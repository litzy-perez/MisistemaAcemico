namespace MisistemaAcemico
{
    partial class FormInscripciones
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
            lblEstudiante = new Label();
            lblPeriodo = new Label();
            cboEstudiante = new ComboBox();
            cboPeriodo = new ComboBox();
            btnInscribir = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            dgvInscripciones = new DataGridView();
            label2 = new Label();
            cboCarrera = new ComboBox();
            lblAsignatura = new Label();
            cboAsignatura = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gabriola", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Image = Properties.Resources.Fondo__1_;
            label1.ImageAlign = ContentAlignment.TopLeft;
            label1.Location = new Point(1, -2);
            label1.Name = "label1";
            label1.Size = new Size(248, 50);
            label1.TabIndex = 4;
            label1.Text = "Gestión de Inscripciones";
            // 
            // lblEstudiante
            // 
            lblEstudiante.AutoSize = true;
            lblEstudiante.Location = new Point(19, 194);
            lblEstudiante.Name = "lblEstudiante";
            lblEstudiante.Size = new Size(70, 15);
            lblEstudiante.TabIndex = 5;
            lblEstudiante.Text = "Estudiantes:";
            // 
            // lblPeriodo
            // 
            lblPeriodo.AutoSize = true;
            lblPeriodo.Location = new Point(21, 233);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(51, 15);
            lblPeriodo.TabIndex = 7;
            lblPeriodo.Text = "Periodo:";
            // 
            // cboEstudiante
            // 
            cboEstudiante.FormattingEnabled = true;
            cboEstudiante.Location = new Point(95, 191);
            cboEstudiante.Name = "cboEstudiante";
            cboEstudiante.Size = new Size(207, 23);
            cboEstudiante.TabIndex = 8;
            // 
            // cboPeriodo
            // 
            cboPeriodo.FormattingEnabled = true;
            cboPeriodo.Location = new Point(78, 233);
            cboPeriodo.Name = "cboPeriodo";
            cboPeriodo.Size = new Size(207, 23);
            cboPeriodo.TabIndex = 10;
            // 
            // btnInscribir
            // 
            btnInscribir.BackColor = Color.FromArgb(255, 192, 192);
            btnInscribir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInscribir.Location = new Point(174, 308);
            btnInscribir.Name = "btnInscribir";
            btnInscribir.Size = new Size(75, 23);
            btnInscribir.TabIndex = 11;
            btnInscribir.Text = "Inscribir";
            btnInscribir.UseVisualStyleBackColor = false;
            btnInscribir.Click += btnInscribir_Click_1;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(255, 255, 192);
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(279, 308);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click_1;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(192, 255, 192);
            btnSalir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.Location = new Point(382, 308);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click_1;
            // 
            // dgvInscripciones
            // 
            dgvInscripciones.AllowUserToOrderColumns = true;
            dgvInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInscripciones.Location = new Point(90, 41);
            dgvInscripciones.Name = "dgvInscripciones";
            dgvInscripciones.Size = new Size(413, 134);
            dgvInscripciones.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(308, 194);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 16;
            label2.Text = "Carrera:";
            // 
            // cboCarrera
            // 
            cboCarrera.FormattingEnabled = true;
            cboCarrera.Location = new Point(365, 192);
            cboCarrera.Name = "cboCarrera";
            cboCarrera.Size = new Size(207, 23);
            cboCarrera.TabIndex = 17;
            // 
            // lblAsignatura
            // 
            lblAsignatura.AutoSize = true;
            lblAsignatura.Location = new Point(291, 233);
            lblAsignatura.Name = "lblAsignatura";
            lblAsignatura.Size = new Size(72, 15);
            lblAsignatura.TabIndex = 25;
            lblAsignatura.Text = "Asignaturas:";
            // 
            // cboAsignatura
            // 
            cboAsignatura.FormattingEnabled = true;
            cboAsignatura.Location = new Point(365, 230);
            cboAsignatura.Name = "cboAsignatura";
            cboAsignatura.Size = new Size(207, 23);
            cboAsignatura.TabIndex = 26;
            // 
            // FormInscripciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo__1_;
            ClientSize = new Size(584, 361);
            Controls.Add(cboAsignatura);
            Controls.Add(lblAsignatura);
            Controls.Add(cboCarrera);
            Controls.Add(label2);
            Controls.Add(dgvInscripciones);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnInscribir);
            Controls.Add(cboPeriodo);
            Controls.Add(cboEstudiante);
            Controls.Add(lblPeriodo);
            Controls.Add(lblEstudiante);
            Controls.Add(label1);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FormInscripciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormInscripciones";
            Load += FormInscripciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblEstudiante;
        private Label lblPeriodo;
        private ComboBox cboEstudiante;
        private ComboBox cboPeriodo;
        private Button btnInscribir;
        private Button btnEliminar;
        private Button btnSalir;
        private DataGridView dgvInscripciones;
        private Label label2;
        private ComboBox cboCarrera;
        private Label lblAsignatura;
        private ComboBox cboAsignatura;
    }
}