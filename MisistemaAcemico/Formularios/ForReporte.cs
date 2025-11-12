using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MisistemaAcemico.Formularios
{
    public partial class ForReporte : Form
    {
        public ForReporte()
        {
            InitializeComponent();
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            CargarTodosLosDatos();
        }

        private void CargarTodosLosDatos()
        {
            var calificaciones = Clases.Calificacion.GetCalificacionesConDatos();
            var inscripciones = Clases.Inscripcion.GetAllConDatos();

            var lista = new List<object>();

            foreach (var c in calificaciones)
            {
                var inscripcion = inscripciones.Find(i => i.Id_inscripcion == c.Id_inscripcion);

                if (inscripcion != null)
                {
                    lista.Add(new
                    {
                        Estudiante = c.EstudianteNombre,
                        Asignatura = c.AsignaturaNombre,
                        Carrera = inscripcion.CarreraNombre,
                        Nota1 = c.Nota1?.ToString("F2") ?? "—",
                        Nota2 = c.Nota2?.ToString("F2") ?? "—",
                        Nota3 = c.Nota3?.ToString("F2") ?? "—",
                        Promedio = c.PromedioFinal?.ToString("F2") ?? "—",
                        Estado = c.PromedioFinal >= 6 ? "Aprobado" : "Reprobado"
                    });
                }
            }

            dgvReportes.DataSource = null;
            dgvReportes.DataSource = lista;
        }

        private void btnBuscarEst_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscarEst.Text.Trim();
            if (string.IsNullOrEmpty(busqueda)) return;

            var calificaciones = Clases.Calificacion.GetCalificacionesConDatos();
            var inscripciones = Clases.Inscripcion.GetAllConDatos();

            var lista = new List<object>();

            foreach (var c in calificaciones)
            {
                var inscripcion = inscripciones.Find(i => i.Id_inscripcion == c.Id_inscripcion);

                if (inscripcion != null)
                {
                    // Filtrar según lo que escribió el usuario
                    if (busqueda.Equals("Aprobados", StringComparison.OrdinalIgnoreCase))
                    {
                        if (c.PromedioFinal < 6) continue;
                    }
                    else if (busqueda.Equals("Reprobados", StringComparison.OrdinalIgnoreCase))
                    {
                        if (c.PromedioFinal >= 6) continue;
                    }
                    else if (c.AsignaturaNombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase))
                    {
                        // Filtrar por asignatura
                    }
                    else if (!c.EstudianteNombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase))
                    {
                        continue; // No coincide con nombre, no lo agrega
                    }

                    lista.Add(new
                    {
                        Estudiante = c.EstudianteNombre,
                        Asignatura = c.AsignaturaNombre,
                        Carrera = inscripcion.CarreraNombre,
                        Nota1 = c.Nota1?.ToString("F2") ?? "—",
                        Nota2 = c.Nota2?.ToString("F2") ?? "—",
                        Nota3 = c.Nota3?.ToString("F2") ?? "—",
                        Promedio = c.PromedioFinal?.ToString("F2") ?? "—",
                        Estado = c.PromedioFinal >= 6 ? "Aprobado" : "Reprobado"
                    });
                }
            }

            dgvReportes.DataSource = null;
            dgvReportes.DataSource = lista;

            if (lista.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}