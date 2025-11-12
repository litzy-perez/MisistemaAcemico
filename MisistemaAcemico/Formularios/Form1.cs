using MisistemaAcemico.Clases;
using MisistemaAcemico.Formularios;
using System;
using System.Windows.Forms;

namespace MisistemaAcemico
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            this.Text = "Sistema Académico - Menú Principal";
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            new FormEstudiantes().ShowDialog();
        }

        
        private void btnAsignaturas_Click_1(object sender, EventArgs e)
        {
            new FormAsignaturas().ShowDialog();
        }

        private void btnPeriodos_Click(object sender, EventArgs e)
        {
            new FormPeriodos().ShowDialog();
        }

        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            new FormInscripciones().ShowDialog();
        }

        private void btnCalificaciones_Click_1(object sender, EventArgs e)
        {
            new FormCalificaciones().ShowDialog();
        }


        private void btnProbarConexion_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var conn = ConexionDB.ObtenerConexion())
                {
                    conn.Open();
                    MessageBox.Show(
                        " Conexión exitosa a la base de datos 'academico_db'.\n" +
                        $"Servidor: {conn.DataSource}\nBase de datos: {conn.Database}",
                        "Conexión OK",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    " Error al conectar con la base de datos:\n" + ex.Message,
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            new Formularios.ForReporte().ShowDialog();
        }
    }

}