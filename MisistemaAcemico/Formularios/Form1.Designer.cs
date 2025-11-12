namespace MisistemaAcemico
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnEstudiantes = new Button();
            btnAsignaturas = new Button();
            btnPeriodos = new Button();
            btnInscripciones = new Button();
            btnCalificaciones = new Button();
            btnReportes = new Button();
            btnProbarConexion = new Button();
            button1 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gabriola", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(217, 56);
            label1.Name = "label1";
            label1.Size = new Size(0, 50);
            label1.TabIndex = 0;
            // 
            // btnEstudiantes
            // 
            btnEstudiantes.BackColor = SystemColors.InactiveCaption;
            btnEstudiantes.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnEstudiantes.Location = new Point(156, 141);
            btnEstudiantes.Name = "btnEstudiantes";
            btnEstudiantes.Size = new Size(91, 38);
            btnEstudiantes.TabIndex = 1;
            btnEstudiantes.Text = "Estudiantes";
            btnEstudiantes.UseVisualStyleBackColor = false;
            btnEstudiantes.Click += btnEstudiantes_Click;
            // 
            // btnAsignaturas
            // 
            btnAsignaturas.BackColor = SystemColors.InactiveCaption;
            btnAsignaturas.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAsignaturas.Location = new Point(263, 141);
            btnAsignaturas.Name = "btnAsignaturas";
            btnAsignaturas.Size = new Size(91, 38);
            btnAsignaturas.TabIndex = 2;
            btnAsignaturas.Text = "Asignaturas";
            btnAsignaturas.UseVisualStyleBackColor = false;
            btnAsignaturas.Click += btnAsignaturas_Click_1;
            // 
            // btnPeriodos
            // 
            btnPeriodos.BackColor = SystemColors.InactiveCaption;
            btnPeriodos.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnPeriodos.Location = new Point(368, 141);
            btnPeriodos.Name = "btnPeriodos";
            btnPeriodos.Size = new Size(91, 38);
            btnPeriodos.TabIndex = 3;
            btnPeriodos.Text = "Periodos";
            btnPeriodos.UseVisualStyleBackColor = false;
            btnPeriodos.Click += btnPeriodos_Click;
            // 
            // btnInscripciones
            // 
            btnInscripciones.BackColor = SystemColors.InactiveCaption;
            btnInscripciones.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnInscripciones.Location = new Point(156, 185);
            btnInscripciones.Name = "btnInscripciones";
            btnInscripciones.Size = new Size(91, 38);
            btnInscripciones.TabIndex = 4;
            btnInscripciones.Text = "Inscripciones";
            btnInscripciones.UseVisualStyleBackColor = false;
            btnInscripciones.Click += btnInscripciones_Click;
            // 
            // btnCalificaciones
            // 
            btnCalificaciones.BackColor = SystemColors.InactiveCaption;
            btnCalificaciones.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnCalificaciones.Location = new Point(263, 185);
            btnCalificaciones.Name = "btnCalificaciones";
            btnCalificaciones.Size = new Size(91, 38);
            btnCalificaciones.TabIndex = 5;
            btnCalificaciones.Text = "Calificaciones";
            btnCalificaciones.UseVisualStyleBackColor = false;
            btnCalificaciones.Click += btnCalificaciones_Click_1;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = SystemColors.InactiveCaption;
            btnReportes.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnReportes.Location = new Point(368, 185);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(91, 38);
            btnReportes.TabIndex = 6;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnProbarConexion
            // 
            btnProbarConexion.Location = new Point(591, 391);
            btnProbarConexion.Name = "btnProbarConexion";
            btnProbarConexion.Size = new Size(25, 14);
            btnProbarConexion.TabIndex = 7;
            btnProbarConexion.Text = "---";
            btnProbarConexion.UseVisualStyleBackColor = true;
            btnProbarConexion.Click += btnProbarConexion_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 192, 192);
            button1.Location = new Point(553, 12);
            button1.Name = "button1";
            button1.Size = new Size(35, 24);
            button1.TabIndex = 8;
            button1.Text = "❌";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlLightLight;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Gabriola", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(202, 65);
            label2.Name = "label2";
            label2.Size = new Size(199, 50);
            label2.TabIndex = 9;
            label2.Text = "Sistema Académico";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = Properties.Resources.Fondo__1_;
            ClientSize = new Size(600, 341);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(btnProbarConexion);
            Controls.Add(btnReportes);
            Controls.Add(btnCalificaciones);
            Controls.Add(btnInscripciones);
            Controls.Add(btnPeriodos);
            Controls.Add(btnAsignaturas);
            Controls.Add(btnEstudiantes);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú Principal";
            Load += FormPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnEstudiantes;
        private Button btnAsignaturas;
        private Button btnPeriodos;
        private Button btnInscripciones;
        private Button btnCalificaciones;
        private Button btnReportes;
        private Button btnProbarConexion;
        private Button button1;
        private Label label2;
    }
}
