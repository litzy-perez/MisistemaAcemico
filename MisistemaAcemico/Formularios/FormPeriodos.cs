using MisistemaAcemico.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MisistemaAcemico
{
    public partial class FormPeriodos : Form
    {
        private List<Periodo> listaPeriodos = new List<Periodo>();

        public FormPeriodos()
        {
            InitializeComponent();
            this.Text = "Gestión de Períodos Académicos";
        }

        private void FormPeriodos_Load(object sender, EventArgs e)
        {
            for (int year = 2020; year <= 2030; year++)
            {
                cboAnio.Items.Add(year);
            }
            cboAnio.SelectedItem = DateTime.Now.Year;

            cboCiclo.Items.AddRange(new object[] { "I", "II", "Verano" });
            cboCiclo.SelectedIndex = 0;

            // Cargar lista de períodos
            CargarLista();
        }

        private void CargarLista()
        {
            try
            {
                listaPeriodos = Periodo.GetAll();
                dgvPeriodos.DataSource = null;
                dgvPeriodos.DataSource = listaPeriodos;
                dgvPeriodos.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar períodos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (cboAnio.SelectedItem == null || cboCiclo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione Año y Ciclo.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var nuevo = new Periodo
                {
                    Anio = (int)cboAnio.SelectedItem,
                    Ciclo = cboCiclo.SelectedItem.ToString()
                };
                nuevo.Guardar();
                MessageBox.Show("Período registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarSeleccion();
                CargarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (dgvPeriodos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un período de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboAnio.SelectedItem == null || cboCiclo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione Año y Ciclo.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var id = (int)dgvPeriodos.SelectedRows[0].Cells["Id_periodo"].Value;
                var periodo = listaPeriodos.Find(p => p.Id_periodo == id);
                if (periodo != null)
                {
                    periodo.Anio = (int)cboAnio.SelectedItem;
                    periodo.Ciclo = cboCiclo.SelectedItem.ToString();
                    periodo.Actualizar();
                    MessageBox.Show("Período actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarSeleccion();
                    CargarLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvPeriodos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un período de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "¿Desea eliminar este período?\n(Se eliminará permanentemente)",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var id = (int)dgvPeriodos.SelectedRows[0].Cells["Id_periodo"].Value;
                    Periodo.Eliminar(id);
                    MessageBox.Show("Período eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                    LimpiarSeleccion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPeriodos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPeriodos.Rows[e.RowIndex];
                var anio = row.Cells["Anio"].Value?.ToString();
                var ciclo = row.Cells["Ciclo"].Value?.ToString();

                if (int.TryParse(anio, out int a))
                    cboAnio.SelectedItem = a;
                else
                    cboAnio.SelectedIndex = -1;

                cboCiclo.SelectedItem = ciclo;
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarSeleccion()
        {
            cboAnio.SelectedItem = DateTime.Now.Year;
            cboCiclo.SelectedIndex = 0;
        }

    }
}