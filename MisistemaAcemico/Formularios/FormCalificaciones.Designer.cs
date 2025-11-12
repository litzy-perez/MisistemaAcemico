namespace MisistemaAcemico
{
    partial class FormCalificaciones
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
            lblInscripcion = new Label();
            lblNota1 = new Label();
            btnRegistrar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            cboInscripcion = new ComboBox();
            txtNota1 = new TextBox();
            btnSalir = new Button();
            label2 = new Label();
            dgvCalificaciones = new DataGridView();
            txtBuscarEst = new TextBox();
            btnBuscarEst = new Button();
            txtNota2 = new TextBox();
            lblNota2 = new Label();
            txtNota3 = new TextBox();
            lblNota3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCalificaciones).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new Font("Gabriola", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Image = Properties.Resources.Fondo__1_;
            label1.Location = new Point(180, 9);
            label1.Name = "label1";
            label1.Size = new Size(252, 50);
            label1.TabIndex = 5;
            label1.Text = "Gestión de Calificaciones";
            // 
            // lblInscripcion
            // 
            lblInscripcion.AutoSize = true;
            lblInscripcion.Location = new Point(12, 80);
            lblInscripcion.Name = "lblInscripcion";
            lblInscripcion.Size = new Size(68, 15);
            lblInscripcion.TabIndex = 6;
            lblInscripcion.Text = "Inscripcion:";
            // 
            // lblNota1
            // 
            lblNota1.AutoSize = true;
            lblNota1.Location = new Point(325, 75);
            lblNota1.Name = "lblNota1";
            lblNota1.Size = new Size(39, 15);
            lblNota1.TabIndex = 7;
            lblNota1.Text = "Nota I";
            lblNota1.Click += lblNota1_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(162, 113);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(75, 23);
            btnRegistrar.TabIndex = 8;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click_1;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(243, 113);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 9;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click_1;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(324, 113);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click_1;
            // 
            // cboInscripcion
            // 
            cboInscripcion.FormattingEnabled = true;
            cboInscripcion.Location = new Point(92, 72);
            cboInscripcion.Name = "cboInscripcion";
            cboInscripcion.Size = new Size(227, 23);
            cboInscripcion.TabIndex = 11;
            // 
            // txtNota1
            // 
            txtNota1.Location = new Point(373, 69);
            txtNota1.Name = "txtNota1";
            txtNota1.Size = new Size(34, 23);
            txtNota1.TabIndex = 12;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(405, 113);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Gabriola", 14.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.Image = Properties.Resources.Fondo__1_;
            label2.Location = new Point(162, 169);
            label2.Name = "label2";
            label2.Size = new Size(147, 35);
            label2.TabIndex = 15;
            label2.Text = "Lista de Calificaciones";
            // 
            // dgvCalificaciones
            // 
            dgvCalificaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCalificaciones.Location = new Point(12, 207);
            dgvCalificaciones.Name = "dgvCalificaciones";
            dgvCalificaciones.Size = new Size(560, 143);
            dgvCalificaciones.TabIndex = 16;
            // 
            // txtBuscarEst
            // 
            txtBuscarEst.Location = new Point(446, 177);
            txtBuscarEst.Name = "txtBuscarEst";
            txtBuscarEst.Size = new Size(127, 23);
            txtBuscarEst.TabIndex = 19;
            // 
            // btnBuscarEst
            // 
            btnBuscarEst.Location = new Point(379, 178);
            btnBuscarEst.Name = "btnBuscarEst";
            btnBuscarEst.Size = new Size(67, 23);
            btnBuscarEst.TabIndex = 20;
            btnBuscarEst.Text = "🔍 Buscar";
            btnBuscarEst.UseVisualStyleBackColor = true;
            btnBuscarEst.Click += btnBuscarEst_Click_1;
            // 
            // txtNota2
            // 
            txtNota2.Location = new Point(461, 69);
            txtNota2.Name = "txtNota2";
            txtNota2.Size = new Size(34, 23);
            txtNota2.TabIndex = 22;
            txtNota2.TextChanged += txtNota2_TextChanged;
            // 
            // lblNota2
            // 
            lblNota2.AutoSize = true;
            lblNota2.Location = new Point(413, 75);
            lblNota2.Name = "lblNota2";
            lblNota2.Size = new Size(42, 15);
            lblNota2.TabIndex = 21;
            lblNota2.Text = "Nota 2";
            lblNota2.Click += lblNota2_Click;
            // 
            // txtNota3
            // 
            txtNota3.Location = new Point(548, 69);
            txtNota3.Name = "txtNota3";
            txtNota3.Size = new Size(34, 23);
            txtNota3.TabIndex = 24;
            txtNota3.TextChanged += txtNota3_TextChanged;
            // 
            // lblNota3
            // 
            lblNota3.AutoSize = true;
            lblNota3.Location = new Point(500, 75);
            lblNota3.Name = "lblNota3";
            lblNota3.Size = new Size(42, 15);
            lblNota3.TabIndex = 23;
            lblNota3.Text = "Nota 3";
            lblNota3.Click += lblNota3_Click;
            // 
            // FormCalificaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo__1_;
            ClientSize = new Size(584, 361);
            Controls.Add(txtNota3);
            Controls.Add(lblNota3);
            Controls.Add(txtNota2);
            Controls.Add(lblNota2);
            Controls.Add(btnBuscarEst);
            Controls.Add(txtBuscarEst);
            Controls.Add(dgvCalificaciones);
            Controls.Add(label2);
            Controls.Add(btnSalir);
            Controls.Add(txtNota1);
            Controls.Add(cboInscripcion);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnRegistrar);
            Controls.Add(lblNota1);
            Controls.Add(lblInscripcion);
            Controls.Add(label1);
            Name = "FormCalificaciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCalificaciones";
            Load += FormCalificaciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCalificaciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblInscripcion;
        private Label lblNota1;
        private Button btnRegistrar;
        private Button btnModificar;
        private Button btnEliminar;
        private ComboBox cboInscripcion;
        private TextBox txtNota1;
        private Button btnSalir;
        private Label label2;
        private DataGridView dgvCalificaciones;
        private TextBox txtBuscarEst;
        private Button btnBuscarEst;
        private TextBox txtNota2;
        private Label lblNota2;
        private TextBox txtNota3;
        private Label lblNota3;
    }
}