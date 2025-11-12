namespace MisistemaAcemico
{
    partial class FormAsignaturas
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
            dgvAsignaturas = new DataGridView();
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            lblNombre = new Label();
            lblUnidades = new Label();
            txtNombre = new TextBox();
            txtUnidades = new TextBox();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAsignaturas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Gabriola", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Image = Properties.Resources.Fondo__1_;
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(47, 9);
            label1.Name = "label1";
            label1.Size = new Size(240, 52);
            label1.TabIndex = 2;
            label1.Text = "Gestión de Asignaturas";
            // 
            // dgvAsignaturas
            // 
            dgvAsignaturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAsignaturas.Location = new Point(250, 104);
            dgvAsignaturas.Name = "dgvAsignaturas";
            dgvAsignaturas.Size = new Size(329, 136);
            dgvAsignaturas.TabIndex = 3;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.BorderStyle = BorderStyle.Fixed3D;
            lblCodigo.Location = new Point(5, 159);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(51, 17);
            lblCodigo.TabIndex = 5;
            lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(69, 156);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(175, 23);
            txtCodigo.TabIndex = 6;
            txtCodigo.TextChanged += txtCodigo_TextChanged;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = SystemColors.Control;
            lblNombre.BorderStyle = BorderStyle.Fixed3D;
            lblNombre.Location = new Point(5, 132);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(56, 17);
            lblNombre.TabIndex = 7;
            lblNombre.Text = "Nombre:";
            // 
            // lblUnidades
            // 
            lblUnidades.AutoSize = true;
            lblUnidades.BorderStyle = BorderStyle.Fixed3D;
            lblUnidades.Location = new Point(5, 191);
            lblUnidades.Name = "lblUnidades";
            lblUnidades.Size = new Size(117, 17);
            lblUnidades.TabIndex = 8;
            lblUnidades.Text = " Unidades Valoratvas";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(69, 129);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(175, 23);
            txtNombre.TabIndex = 9;
            // 
            // txtUnidades
            // 
            txtUnidades.Location = new Point(128, 185);
            txtUnidades.Name = "txtUnidades";
            txtUnidades.Size = new Size(116, 23);
            txtUnidades.TabIndex = 10;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(144, 268);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(100, 29);
            btnNuevo.TabIndex = 11;
            btnNuevo.Text = "Registrar 📁";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click_1;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(250, 268);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(100, 29);
            btnModificar.TabIndex = 12;
            btnModificar.Text = "Modificar ✏️";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click_1;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(356, 268);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 29);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar 🗑️";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click_1;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(250, 76);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(257, 23);
            txtBuscar.TabIndex = 15;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(513, 76);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(66, 23);
            btnBuscar.TabIndex = 16;
            btnBuscar.Text = "Buscar 🔍";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // FormAsignaturas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo__1_;
            ClientSize = new Size(584, 361);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblCodigo);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(txtUnidades);
            Controls.Add(txtNombre);
            Controls.Add(lblUnidades);
            Controls.Add(txtCodigo);
            Controls.Add(dgvAsignaturas);
            Controls.Add(label1);
            Controls.Add(lblNombre);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAsignaturas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAsignaturas";
            ((System.ComponentModel.ISupportInitialize)dgvAsignaturas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvAsignaturas;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblNombre;
        private Label lblUnidades;
        private TextBox txtNombre;
        private TextBox txtUnidades;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnEliminar;
        private TextBox txtBuscar;
        private Button btnBuscar;
    }
}