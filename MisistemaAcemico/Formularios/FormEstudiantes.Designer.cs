namespace MisistemaAcemico
{
    partial class FormEstudiantes
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
            dgvEstudiantes = new DataGridView();
            label1 = new Label();
            btnBuscar = new Button();
            btnNuevo = new Button();
            txtCarnetBuscar = new TextBox();
            btnModificar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).BeginInit();
            SuspendLayout();
            // 
            // dgvEstudiantes
            // 
            dgvEstudiantes.BackgroundColor = SystemColors.ControlLightLight;
            dgvEstudiantes.BorderStyle = BorderStyle.Fixed3D;
            dgvEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstudiantes.Location = new Point(5, 92);
            dgvEstudiantes.Name = "dgvEstudiantes";
            dgvEstudiantes.Size = new Size(574, 181);
            dgvEstudiantes.TabIndex = 0;
            dgvEstudiantes.SizeChanged += FormEstudiantes_Load;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gabriola", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Image = Properties.Resources.Fondo__1_;
            label1.Location = new Point(23, 40);
            label1.Name = "label1";
            label1.Size = new Size(235, 50);
            label1.TabIndex = 1;
            label1.Text = "Gestión de Estudiantes";
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = SystemColors.InactiveCaption;
            btnBuscar.Location = new Point(498, 51);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(60, 23);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseCompatibleTextRendering = true;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click_1;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = SystemColors.InactiveCaption;
            btnNuevo.Location = new Point(35, 302);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(171, 31);
            btnNuevo.TabIndex = 4;
            btnNuevo.Text = "Añadir Estudiante ➕";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click_1;
            // 
            // txtCarnetBuscar
            // 
            txtCarnetBuscar.Location = new Point(344, 51);
            txtCarnetBuscar.Name = "txtCarnetBuscar";
            txtCarnetBuscar.Size = new Size(148, 23);
            txtCarnetBuscar.TabIndex = 8;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = SystemColors.InactiveCaption;
            btnModificar.Location = new Point(219, 302);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(171, 31);
            btnModificar.TabIndex = 9;
            btnModificar.Text = "Modificar ✏️";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = SystemColors.InactiveCaption;
            btnEliminar.Location = new Point(399, 302);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(171, 31);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar 🗑️";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FormEstudiantes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = Properties.Resources.Fondo__1_;
            ClientSize = new Size(584, 361);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(txtCarnetBuscar);
            Controls.Add(btnNuevo);
            Controls.Add(btnBuscar);
            Controls.Add(label1);
            Controls.Add(dgvEstudiantes);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEstudiantes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormEstudiantes";
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEstudiantes;
        private Label label1;
        private Button btnBuscar;
        private Button btnNuevo;
        private TextBox txtCarnetBuscar;
        private Button btnModificar;
        private Button btnEliminar;
    }
}