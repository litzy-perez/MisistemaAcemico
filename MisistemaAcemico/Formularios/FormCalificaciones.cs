using MisistemaAcemico.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MisistemaAcemico
{
    public partial class FormCalificaciones : Form
    {
        private List<CalificacionCompleta> todasCalificaciones = new List<CalificacionCompleta>();
        private Dictionary<string, int> mapaInscripciones = new Dictionary<string, int>();

        public FormCalificaciones()
        {
            InitializeComponent();
            this.Text = "Gestión de Calificaciones";
        }

        private void FormCalificaciones_Load(object sender, EventArgs e)
        {
            CargarInscripcionesEnCombo();
            CargarTodasCalificaciones();
        }

        private void CargarInscripcionesEnCombo()
        {
            cboInscripcion.Items.Clear();
            mapaInscripciones.Clear();

            var inscripciones = Inscripcion.GetAllConDatos();
            if (inscripciones == null || inscripciones.Count == 0)
            {
                MessageBox.Show("No hay inscripciones registradas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var ins in inscripciones)
            {
                string display = $"{ins.EstudianteNombre} - {ins.AsignaturaNombre} ({ins.PeriodoTexto})";
                mapaInscripciones[display] = ins.Id_inscripcion;
                cboInscripcion.Items.Add(display);
            }
        }

        private void CargarTodasCalificaciones()
        {
            try
            {
                todasCalificaciones = Calificacion.GetCalificacionesConDatos();
                MostrarCalificaciones(todasCalificaciones);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar calificaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarCalificaciones(List<CalificacionCompleta> lista)
        {
            var mostrar = new List<object>();
            foreach (var cal in lista)
            {
                mostrar.Add(new
                {
                    Estudiante = cal.EstudianteNombre,
                    Asignatura = cal.AsignaturaNombre,
                    Periodo = cal.PeriodoTexto,
                    Nota1 = cal.Nota1?.ToString("F2") ?? "—",
                    Nota2 = cal.Nota2?.ToString("F2") ?? "—",
                    Nota3 = cal.Nota3?.ToString("F2") ?? "—",
                    Promedio = cal.PromedioFinal?.ToString("F2") ?? "—"
                });
            }

            dgvCalificaciones.DataSource = null;
            dgvCalificaciones.DataSource = mostrar;
            dgvCalificaciones.Refresh();
        }

        private void btnBuscarEst_Click_1(object sender, EventArgs e)
        {
            string nombre = txtBuscarEst.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MostrarCalificaciones(todasCalificaciones);
                return;
            }

            var filtradas = todasCalificaciones.FindAll(cal =>
                cal.EstudianteNombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)
            );

            MostrarCalificaciones(filtradas);
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            if (cboInscripcion.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una inscripción.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que al menos una nota esté ingresada
            if (string.IsNullOrEmpty(txtNota1.Text) && string.IsNullOrEmpty(txtNota2.Text) && string.IsNullOrEmpty(txtNota3.Text))
            {
                MessageBox.Show("Ingrese al menos una nota.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar y obtener las notas
            decimal? n1 = null, n2 = null, n3 = null;

            if (!string.IsNullOrEmpty(txtNota1.Text))
            {
                if (!decimal.TryParse(txtNota1.Text, out decimal nota1) || nota1 < 0 || nota1 > 10)
                {
                    MessageBox.Show("Nota 1 debe ser un número entre 0 y 10.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                n1 = nota1;
            }

            if (!string.IsNullOrEmpty(txtNota2.Text))
            {
                if (!decimal.TryParse(txtNota2.Text, out decimal nota2) || nota2 < 0 || nota2 > 10)
                {
                    MessageBox.Show("Nota 2 debe ser un número entre 0 y 10.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                n2 = nota2;
            }

            if (!string.IsNullOrEmpty(txtNota3.Text))
            {
                if (!decimal.TryParse(txtNota3.Text, out decimal nota3) || nota3 < 0 || nota3 > 10)
                {
                    MessageBox.Show("Nota 3 debe ser un número entre 0 y 10.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                n3 = nota3;
            }

            try
            {
                string display = cboInscripcion.SelectedItem.ToString();
                if (!mapaInscripciones.TryGetValue(display, out int idInscripcion))
                {
                    throw new Exception("No se pudo obtener el ID de la inscripción.");
                }

                if (Calificacion.ExistePorInscripcion(idInscripcion))
                {
                    MessageBox.Show("Ya existe una calificación para esta inscripción.\nUse 'Modificar' para actualizarla.", "Calificación duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nueva = new Calificacion
                {
                    Id_inscripcion = idInscripcion,
                    Nota1 = n1,
                    Nota2 = n2,
                    Nota3 = n3
                };
                nueva.CalcularPromedio();
                nueva.RegistrarNotas();

                MessageBox.Show("Calificación registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarTodasCalificaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (dgvCalificaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una calificación de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar y obtener las notas
            if (string.IsNullOrEmpty(txtNota1.Text) && string.IsNullOrEmpty(txtNota2.Text) && string.IsNullOrEmpty(txtNota3.Text))
            {
                MessageBox.Show("Ingrese al menos una nota.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal? n1 = null, n2 = null, n3 = null;

            if (!string.IsNullOrEmpty(txtNota1.Text))
            {
                if (!decimal.TryParse(txtNota1.Text, out decimal nota1) || nota1 < 0 || nota1 > 10)
                {
                    MessageBox.Show("Nota 1 debe ser un número entre 0 y 10.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                n1 = nota1;
            }

            if (!string.IsNullOrEmpty(txtNota2.Text))
            {
                if (!decimal.TryParse(txtNota2.Text, out decimal nota2) || nota2 < 0 || nota2 > 10)
                {
                    MessageBox.Show("Nota 2 debe ser un número entre 0 y 10.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                n2 = nota2;
            }

            if (!string.IsNullOrEmpty(txtNota3.Text))
            {
                if (!decimal.TryParse(txtNota3.Text, out decimal nota3) || nota3 < 0 || nota3 > 10)
                {
                    MessageBox.Show("Nota 3 debe ser un número entre 0 y 10.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                n3 = nota3;
            }

            try
            {
                var rowIndex = dgvCalificaciones.SelectedRows[0].Index;
                var calificacionCompleta = todasCalificaciones[rowIndex];

                var calificacion = new Calificacion
                {
                    Id_inscripcion = calificacionCompleta.Id_inscripcion,
                    Nota1 = n1,
                    Nota2 = n2,
                    Nota3 = n3
                };
                calificacion.CalcularPromedio();
                calificacion.RegistrarNotas();

                MessageBox.Show("Calificación actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarTodasCalificaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvCalificaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una calificación de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "¿Desea eliminar esta calificación?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var rowIndex = dgvCalificaciones.SelectedRows[0].Index;
                    var calificacion = todasCalificaciones[rowIndex];
                    Calificacion.Eliminar(calificacion.Id_calificacion);
                    MessageBox.Show("Calificación eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTodasCalificaciones();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCalificaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var rowIndex = e.RowIndex;
                var cal = todasCalificaciones[rowIndex];
                txtNota1.Text = cal.Nota1?.ToString("F2");
                txtNota2.Text = cal.Nota2?.ToString("F2");
                txtNota3.Text = cal.Nota3?.ToString("F2");

                string inscripcionTexto = $"{cal.EstudianteNombre} - {cal.AsignaturaNombre} ({cal.PeriodoTexto})";
                cboInscripcion.SelectedItem = inscripcionTexto;
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            cboInscripcion.SelectedIndex = -1;
            txtNota1.Clear();
            txtNota2.Clear();
            txtNota3.Clear();
        }

        private void txtNota_TextChanged(object sender, EventArgs e) { }
        private void lblNota3_Click(object sender, EventArgs e) { }
        private void lblNota1_Click(object sender, EventArgs e) { }
        private void lblNota2_Click(object sender, EventArgs e) { }
        private void txtNota2_TextChanged(object sender, EventArgs e) { }
        private void txtNota3_TextChanged(object sender, EventArgs e) { }
    }
}