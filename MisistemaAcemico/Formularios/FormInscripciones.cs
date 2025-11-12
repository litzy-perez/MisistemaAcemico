using MisistemaAcemico.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MisistemaAcemico
{
    public partial class FormInscripciones : Form
    {
        private Dictionary<string, int> mapaCarreras = new Dictionary<string, int>();
        private Dictionary<string, int> mapaEstudiantes = new Dictionary<string, int>();
        private Dictionary<string, int> mapaAsignaturas = new Dictionary<string, int>();
        private Dictionary<string, int> mapaPeriodos = new Dictionary<string, int>();
        private List<Inscripcion> listaInscripciones = new List<Inscripcion>();

        public FormInscripciones()
        {
            InitializeComponent();
            this.Text = "Gestión de Inscripciones";
        }

        private void FormInscripciones_Load(object sender, EventArgs e)
        {
            ConfigurarComboBoxes();
            CargarInscripciones();
        }

        private void ConfigurarComboBoxes()
        {
            var combos = new[] { cboEstudiante, cboAsignatura, cboPeriodo, cboCarrera };
            foreach (var combo in combos)
            {
                combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combo.AutoCompleteSource = AutoCompleteSource.ListItems;
            }

            mapaEstudiantes.Clear();
            cboEstudiante.Items.Clear();
            var estudiantes = Estudiante.GetAll();
            foreach (var est in estudiantes)
            {
                string display = $"{est.Nombres} {est.Apellidos} ({est.Carnet})";
                mapaEstudiantes[display] = est.Id_estudiante;
                cboEstudiante.Items.Add(display);
            }

            mapaAsignaturas.Clear();
            cboAsignatura.Items.Clear();
            var asignaturas = Asignatura.GetAll();
            foreach (var asig in asignaturas)
            {
                string display = $"{asig.Nombre} ({asig.Codigo})";
                mapaAsignaturas[display] = asig.Id_asignatura;
                cboAsignatura.Items.Add(display);
            }

            mapaPeriodos.Clear();
            cboPeriodo.Items.Clear();
            var periodos = Periodo.GetAll();
            foreach (var per in periodos)
            {
                string display = $"{per.Anio} - {per.Ciclo}";
                mapaPeriodos[display] = per.Id_periodo;
                cboPeriodo.Items.Add(display);
            }

            // Cargar carreras
            mapaCarreras.Clear();
            cboCarrera.Items.Clear();
            var carreras = Carrera.GetAll();
            foreach (var car in carreras)
            {
                string display = car.Nombre;
                mapaCarreras[display] = car.Id_carrera;
                cboCarrera.Items.Add(display);
            }
        }

        private void CargarInscripciones()
        {
            try
            {
                listaInscripciones = Inscripcion.GetAllConDatos();
                var listaMostrar = new List<object>();

                foreach (var ins in listaInscripciones)
                {
                    listaMostrar.Add(new
                    {
                        Estudiante = ins.EstudianteNombre,
                        Asignatura = ins.AsignaturaNombre,
                        Periodo = ins.PeriodoTexto,
                        Carrera = ins.CarreraNombre
                    });
                }

                dgvInscripciones.DataSource = null;
                dgvInscripciones.DataSource = listaMostrar;
                dgvInscripciones.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar inscripciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInscribir_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboEstudiante.Text) ||
                string.IsNullOrEmpty(cboAsignatura.Text) ||
                string.IsNullOrEmpty(cboPeriodo.Text) ||
                string.IsNullOrEmpty(cboCarrera.Text))
            {
                MessageBox.Show("Seleccione estudiante, asignatura, período y carrera.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener IDs, incluyendo idCar
            if (!mapaEstudiantes.TryGetValue(cboEstudiante.Text, out int idEst) ||
                !mapaAsignaturas.TryGetValue(cboAsignatura.Text, out int idAsig) ||
                !mapaPeriodos.TryGetValue(cboPeriodo.Text, out int idPer) ||
                !mapaCarreras.TryGetValue(cboCarrera.Text, out int idCar))
            {
                MessageBox.Show("Error al obtener los datos seleccionados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar duplicado (incluye carrera)
            if (Inscripcion.Existe(idEst, idAsig, idPer, idCar))
            {
                MessageBox.Show("Esta inscripción ya existe.\nNo se permiten duplicados.", "Inscripción duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var nueva = new Inscripcion
                {
                    Id_estudiante = idEst,
                    Id_asignatura = idAsig,
                    Id_periodo = idPer,
                    Id_carrera = idCar // <-- IMPORTANTE: asignar la carrera
                };
                nueva.Registrar();
                MessageBox.Show("Inscripción registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarInscripciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inscribir: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvInscripciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una inscripción de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "¿Desea eliminar esta inscripción?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var rowIndex = dgvInscripciones.SelectedRows[0].Index;
                    var inscripcion = listaInscripciones[rowIndex];
                    Inscripcion.EliminarPorIds(inscripcion.Id_estudiante, inscripcion.Id_asignatura, inscripcion.Id_periodo);
                    MessageBox.Show("Inscripción eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarInscripciones();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            cboEstudiante.SelectedIndex = -1;
            cboAsignatura.SelectedIndex = -1;
            cboPeriodo.SelectedIndex = -1;
            cboCarrera.SelectedIndex = -1; // <-- Limpiar también la carrera
        }
    }
}