using MisistemaAcemico.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MisistemaAcemico
{
    public partial class FormEstudiantes : Form
    {
        private List<Estudiante> listaEstudiantes = new List<Estudiante>();

        public FormEstudiantes()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FormEstudiantes_Load);
            this.Text = "Gestión de Estudiantes";
        }

        private void FormEstudiantes_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            try
            {
                listaEstudiantes = Estudiante.GetAll();

                dgvEstudiantes.AutoGenerateColumns = false;
                dgvEstudiantes.Columns.Clear();

                var colCarnet = new DataGridViewTextBoxColumn();
                colCarnet.HeaderText = "Carnet";
                colCarnet.DataPropertyName = "Carnet";
                dgvEstudiantes.Columns.Add(colCarnet);

                var colNombres = new DataGridViewTextBoxColumn();
                colNombres.HeaderText = "Nombres";
                colNombres.DataPropertyName = "Nombres";
                dgvEstudiantes.Columns.Add(colNombres);

                var colApellidos = new DataGridViewTextBoxColumn();
                colApellidos.HeaderText = "Apellidos";
                colApellidos.DataPropertyName = "Apellidos";
                dgvEstudiantes.Columns.Add(colApellidos);

                var colGenero = new DataGridViewTextBoxColumn();
                colGenero.HeaderText = "Género";
                colGenero.DataPropertyName = "Genero";
                dgvEstudiantes.Columns.Add(colGenero);

                var colEstado = new DataGridViewTextBoxColumn();
                colEstado.HeaderText = "Estado";
                colEstado.DataPropertyName = "Estado";
                dgvEstudiantes.Columns.Add(colEstado);

                var colTelefono = new DataGridViewTextBoxColumn();
                colTelefono.HeaderText = "Teléfono";
                colTelefono.DataPropertyName = "Telefono";
                dgvEstudiantes.Columns.Add(colTelefono);

                dgvEstudiantes.DataSource = listaEstudiantes;
                dgvEstudiantes.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estudiantes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string busqueda = txtCarnetBuscar.Text.Trim().ToLower();
            List<Estudiante> filtrados = new List<Estudiante>();

            if (string.IsNullOrEmpty(busqueda))
            {
                filtrados = listaEstudiantes;
            }
            else if (busqueda == "activo")
            {
                filtrados = listaEstudiantes.FindAll(est => est.Estado == "Activo");
            }
            else if (busqueda == "inactivo")
            {
                filtrados = listaEstudiantes.FindAll(est => est.Estado == "Inactivo");
            }
            else if (busqueda == "mujer")
            {
                filtrados = listaEstudiantes.FindAll(est => est.Genero == "Mujer");
            }
            else if (busqueda == "hombre")
            {
                filtrados = listaEstudiantes.FindAll(est => est.Genero == "Hombre");
            }
            else
            {
                filtrados = listaEstudiantes.FindAll(est =>
                    est.Nombres.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                    est.Apellidos.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                    est.Carnet.Contains(busqueda, StringComparison.OrdinalIgnoreCase)
                );
            }

            dgvEstudiantes.AutoGenerateColumns = false;
            dgvEstudiantes.Columns.Clear();

            var colCarnet = new DataGridViewTextBoxColumn();
            colCarnet.HeaderText = "Carnet";
            colCarnet.DataPropertyName = "Carnet";
            dgvEstudiantes.Columns.Add(colCarnet);

            var colNombres = new DataGridViewTextBoxColumn();
            colNombres.HeaderText = "Nombres";
            colNombres.DataPropertyName = "Nombres";
            dgvEstudiantes.Columns.Add(colNombres);

            var colApellidos = new DataGridViewTextBoxColumn();
            colApellidos.HeaderText = "Apellidos";
            colApellidos.DataPropertyName = "Apellidos";
            dgvEstudiantes.Columns.Add(colApellidos);

            var colGenero = new DataGridViewTextBoxColumn();
            colGenero.HeaderText = "Género";
            colGenero.DataPropertyName = "Genero";
            dgvEstudiantes.Columns.Add(colGenero);

            var colEstado = new DataGridViewTextBoxColumn();
            colEstado.HeaderText = "Estado";
            colEstado.DataPropertyName = "Estado";
            dgvEstudiantes.Columns.Add(colEstado);

            var colTelefono = new DataGridViewTextBoxColumn();
            colTelefono.HeaderText = "Teléfono";
            colTelefono.DataPropertyName = "Telefono";
            dgvEstudiantes.Columns.Add(colTelefono);

            dgvEstudiantes.DataSource = filtrados;
            dgvEstudiantes.Refresh();

            if (filtrados.Count == 0)
            {
                MessageBox.Show("No se encontraron estudiantes con ese criterio.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            var frm = new Form
            {
                Text = "Nuevo Estudiante",
                Size = new System.Drawing.Size(350, 300),
                StartPosition = FormStartPosition.CenterParent
            };

            var txtCarnet = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 180 };
            var txtNombres = new TextBox { Location = new System.Drawing.Point(120, 50), Width = 180 };
            var txtApellidos = new TextBox { Location = new System.Drawing.Point(120, 80), Width = 180 };
            var txtTelefono = new TextBox { Location = new System.Drawing.Point(120, 110), Width = 180 };

            var chkHombre = new CheckBox { Text = "Hombre", Location = new System.Drawing.Point(120, 140) };
            var chkMujer = new CheckBox { Text = "Mujer", Location = new System.Drawing.Point(120, 160) };
            chkHombre.CheckedChanged += (s, ev) => { if (chkHombre.Checked) chkMujer.Checked = false; };
            chkMujer.CheckedChanged += (s, ev) => { if (chkMujer.Checked) chkHombre.Checked = false; };
            chkHombre.Checked = true;

            frm.Controls.AddRange(new Control[]
            {
                new Label { Text = "Carnet:", Location = new System.Drawing.Point(20, 23), AutoSize = true },
                txtCarnet,
                new Label { Text = "Nombres:", Location = new System.Drawing.Point(20, 53), AutoSize = true },
                txtNombres,
                new Label { Text = "Apellidos:", Location = new System.Drawing.Point(20, 83), AutoSize = true },
                txtApellidos,
                new Label { Text = "Teléfono:", Location = new System.Drawing.Point(20, 113), AutoSize = true },
                txtTelefono,
                new Label { Text = "Género:", Location = new System.Drawing.Point(20, 143), AutoSize = true },
                chkHombre,
                chkMujer
            });

            var btnGuardar = new Button
            {
                Text = "Guardar",
                Location = new System.Drawing.Point(120, 190),
                Width = 100
            };

            btnGuardar.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtCarnet.Text) ||
                    string.IsNullOrWhiteSpace(txtNombres.Text) ||
                    string.IsNullOrWhiteSpace(txtApellidos.Text))
                {
                    MessageBox.Show("Carnet, nombres y apellidos son obligatorios.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string genero = chkMujer.Checked ? "Mujer" : "Hombre";

                try
                {
                    var nuevo = new Estudiante(txtNombres.Text.Trim(), txtApellidos.Text.Trim())
                    {
                        Carnet = txtCarnet.Text.Trim(),
                        Telefono = txtTelefono.Text.Trim(),
                        Estado = "Activo",
                        Genero = genero
                    };
                    nuevo.Guardar();
                    MessageBox.Show("Estudiante registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                    frm.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            frm.Controls.Add(btnGuardar);
            frm.ShowDialog(this);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvEstudiantes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un estudiante de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var carnet = dgvEstudiantes.SelectedRows[0].Cells[0].Value?.ToString();
            var est = Estudiante.BuscarPorCarnet(carnet);
            if (est == null)
            {
                MessageBox.Show("No se pudo cargar el estudiante.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var frm = new Form
            {
                Text = "Modificar Estudiante",
                Size = new System.Drawing.Size(350, 250),
                StartPosition = FormStartPosition.CenterParent
            };

            var txtCarnet = new TextBox { Text = est.Carnet, Location = new System.Drawing.Point(120, 20), Width = 180, Enabled = false };
            var txtNombres = new TextBox { Text = est.Nombres, Location = new System.Drawing.Point(120, 50), Width = 180 };
            var txtApellidos = new TextBox { Text = est.Apellidos, Location = new System.Drawing.Point(120, 80), Width = 180 };
            var txtTelefono = new TextBox { Text = est.Telefono, Location = new System.Drawing.Point(120, 110), Width = 180 };

            frm.Controls.AddRange(new Control[]
            {
                new Label { Text = "Carnet:", Location = new System.Drawing.Point(20, 23), AutoSize = true },
                txtCarnet,
                new Label { Text = "Nombres:", Location = new System.Drawing.Point(20, 53), AutoSize = true },
                txtNombres,
                new Label { Text = "Apellidos:", Location = new System.Drawing.Point(20, 83), AutoSize = true },
                txtApellidos,
                new Label { Text = "Teléfono:", Location = new System.Drawing.Point(20, 113), AutoSize = true },
                txtTelefono
            });

            var btnActualizar = new Button
            {
                Text = "Actualizar",
                Location = new System.Drawing.Point(120, 150),
                Width = 100
            };
            btnActualizar.Click += (s, ev) =>
            {
                try
                {
                    est.Nombres = txtNombres.Text.Trim();
                    est.Apellidos = txtApellidos.Text.Trim();
                    est.Telefono = txtTelefono.Text.Trim();
                    est.Actualizar();
                    MessageBox.Show("Estudiante actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                    frm.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            frm.Controls.Add(btnActualizar);
            frm.ShowDialog(this);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEstudiantes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un estudiante de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var carnet = dgvEstudiantes.SelectedRows[0].Cells[0].Value?.ToString();
            if (!string.IsNullOrEmpty(carnet))
            {
                var est = Estudiante.BuscarPorCarnet(carnet);
                if (est != null)
                {
                    var confirm = MessageBox.Show(
                        "¿Desea desactivar a este estudiante?\n(Se marcará como 'Inactivo', no se elimina)",
                        "Confirmar desactivación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (confirm == DialogResult.Yes)
                    {
                        est.Desactivar();
                        MessageBox.Show("Estudiante desactivado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarLista();
                    }
                }
            }
        }

        private void btnMostrarInfo_Click_1(object sender, EventArgs e)
        {
            if (dgvEstudiantes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un estudiante.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var carnet = dgvEstudiantes.SelectedRows[0].Cells["Carnet"].Value?.ToString();
            var est = Estudiante.BuscarPorCarnet(carnet);
            est?.MostrarInfo();
        }

        private void dgvEstudiantes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var carnet = dgvEstudiantes.Rows[e.RowIndex].Cells["Carnet"].Value?.ToString();
                var est = Estudiante.BuscarPorCarnet(carnet);
                est?.MostrarInfo();
            }
        }
    }
}