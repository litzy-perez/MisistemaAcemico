using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;

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
                    // Calcular estado
                    string estado = c.PromedioFinal >= 6 ? "Aprobado" : "Reprobado";

                    // Filtrar según lo que escribió el usuario
                    if (busqueda.Equals("Aprobados", StringComparison.OrdinalIgnoreCase))
                    {
                        if (estado != "Aprobado") continue;
                    }
                    else if (busqueda.Equals("Reprobados", StringComparison.OrdinalIgnoreCase))
                    {
                        if (estado != "Reprobado") continue;
                    }
                    else if (c.AsignaturaNombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase))
                    {
                        // Filtrar por asignatura
                    }
                    else if (inscripcion.CarreraNombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase))
                    {
                        // Filtrar por carrera
                    }
                    else if (!c.EstudianteNombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase))
                    {
                        continue; // No coincide con nombre
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
                        Estado = estado
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

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReportes.Rows.Count == 0 || (dgvReportes.Rows.Count == 1 && dgvReportes.Rows[0].IsNewRow))
                {
                    MessageBox.Show("No hay datos visibles en la tabla para exportar.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ruta del archivo PDF
                string fileName = $"Reporte_Calificaciones_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

                using (PdfWriter writer = new PdfWriter(path))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        using (Document document = new Document(pdf))
                        {
                            // Título del documento (sin negrita, para evitar problemas con versiones obsoletas)
                            document.Add(new Paragraph("Reporte de Calificaciones")
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetFontSize(16)
                                .SetMarginBottom(20));

                            // Crear tabla con 8 columnas
                            Table table = new Table(8);
                            table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);

                            // Encabezados de la tabla
                            string[] headers = { "Estudiante", "Asignatura", "Carrera", "Nota1", "Nota2", "Nota3", "Promedio", "Estado" };
                            foreach (string header in headers)
                            {
                                table.AddHeaderCell(new Cell().Add(new Paragraph(header).SetFontColor(ColorConstants.WHITE))
                                    .SetBackgroundColor(ColorConstants.BLUE));
                            }

                            // Agregar filas visibles del DataGridView
                            foreach (DataGridViewRow row in dgvReportes.Rows)
                            {
                                if (row.IsNewRow) continue; // Omitir fila vacía si está al final

                                for (int i = 0; i < dgvReportes.Columns.Count; i++)
                                {
                                    var cellValue = row.Cells[i].Value?.ToString() ?? "";
                                    table.AddCell(new Cell().Add(new Paragraph(cellValue)));
                                }
                            }

                            document.Add(table);
                        }
                    }
                }

                MessageBox.Show($"PDF generado exitosamente en:\n{path}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el archivo generado
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}