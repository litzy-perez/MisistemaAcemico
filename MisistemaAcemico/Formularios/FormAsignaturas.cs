using MisistemaAcemico.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
namespace MisistemaAcemico
{
    public partial class FormAsignaturas : Form
    {
        private List<Asignatura> listaAsignaturas = new List<Asignatura>();

        public FormAsignaturas()
        {
            InitializeComponent();
            this.Text = "Gestión de Asignaturas";
            CargarLista(); // Carga automática al abrir

        }

        private void CargarLista()
        {
            try
            {
                listaAsignaturas = Asignatura.GetAll();
                dgvAsignaturas.DataSource = null;
                dgvAsignaturas.DataSource = listaAsignaturas;

                // Oculte el id de asignaturs
                dgvAsignaturas.Columns["Id_asignatura"].Visible = false;

                dgvAsignaturas.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar asignaturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtUnidades.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtUnidades.Text, out int unidades) || unidades <= 0)
            {
                MessageBox.Show("Unidades debe ser un número entero mayor a 0.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var nueva = new Asignatura
                {
                    Codigo = txtCodigo.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Unidades = unidades
                };
                nueva.Guardar();
                MessageBox.Show("Asignatura registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (dgvAsignaturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una asignatura de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var id = (int)dgvAsignaturas.SelectedRows[0].Cells["Id_asignatura"].Value;
                var asignatura = listaAsignaturas.Find(a => a.Id_asignatura == id);

                if (asignatura == null) return;

                // Crear una ventana de edición dinámica
                var form = new Form
                {
                    Text = "Editar Asignatura",
                    Size = new System.Drawing.Size(300, 180),
                    StartPosition = FormStartPosition.CenterParent,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    FormBorderStyle = FormBorderStyle.FixedDialog
                };

                var lblCodigo = new Label { Text = "Código:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
                var txtCodigo = new TextBox { Text = asignatura.Codigo, Location = new System.Drawing.Point(80, 17), Width = 150 };

                var lblNombre = new Label { Text = "Nombre:", Location = new System.Drawing.Point(20, 50), AutoSize = true };
                var txtNombre = new TextBox { Text = asignatura.Nombre, Location = new System.Drawing.Point(80, 47), Width = 180 };

                var lblUnidades = new Label { Text = "Unidades:", Location = new System.Drawing.Point(20, 80), AutoSize = true };
                var txtUnidades = new TextBox { Text = asignatura.Unidades.ToString(), Location = new System.Drawing.Point(80, 77), Width = 60 };

                var btnAceptar = new Button { Text = "Aceptar", Location = new System.Drawing.Point(80, 110), Width = 75 };
                var btnCancelar = new Button { Text = "Cancelar", Location = new System.Drawing.Point(165, 110), Width = 75 };

                btnAceptar.Click += (s, ev) =>
                {
                    // Validaciones
                    if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                        string.IsNullOrWhiteSpace(txtNombre.Text) ||
                        string.IsNullOrWhiteSpace(txtUnidades.Text))
                    {
                        MessageBox.Show("Todos los campos son obligatorios.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!int.TryParse(txtUnidades.Text, out int unidades) || unidades <= 0)
                    {
                        MessageBox.Show("Unidades debe ser un número entero mayor a 0.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Aplicar cambios
                    asignatura.Codigo = txtCodigo.Text.Trim();
                    asignatura.Nombre = txtNombre.Text.Trim();
                    asignatura.Unidades = unidades;

                    asignatura.Actualizar();
                    MessageBox.Show("Asignatura actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                    LimpiarCampos();
                    form.Close();
                };

                btnCancelar.Click += (s, ev) => form.Close();

                form.Controls.AddRange(new Control[] { lblCodigo, txtCodigo, lblNombre, txtNombre, lblUnidades, txtUnidades, btnAceptar, btnCancelar });
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la ventana de edición: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvAsignaturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una asignatura de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "¿Desea eliminar esta asignatura?\n(Se eliminará permanentemente)",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var id = (int)dgvAsignaturas.SelectedRows[0].Cells["Id_asignatura"].Value;
                    Asignatura.Eliminar(id);
                    MessageBox.Show("Asignatura eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvAsignaturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvAsignaturas.Rows[e.RowIndex];
                txtCodigo.Text = row.Cells["Codigo"].Value?.ToString() ?? "";
                txtNombre.Text = row.Cells["Nombre"].Value?.ToString() ?? "";
                txtUnidades.Text = row.Cells["Unidades"].Value?.ToString() ?? "";
            }
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtUnidades.Clear();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        { }
        private void MostrarEnGrid(List<Asignatura> lista)
        {
            dgvAsignaturas.DataSource = null;
            dgvAsignaturas.DataSource = lista;
            if (dgvAsignaturas.Columns.Contains("Id_asignatura"))
                dgvAsignaturas.Columns["Id_asignatura"].Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscar.Text.Trim();

            List<Asignatura> resultados;

            if (string.IsNullOrEmpty(nombre))
            {
                resultados = listaAsignaturas;
            }
            else
            {
                resultados = listaAsignaturas
                    .Where(a => a.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            MostrarEnGrid(resultados);
        }
    }
    
}