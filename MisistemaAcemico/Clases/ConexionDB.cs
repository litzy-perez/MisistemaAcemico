using Microsoft.Data.SqlClient;

namespace MisistemaAcemico.Clases
{
    public class ConexionDB
    {
        private static string cadena = @"Server=(localdb)\MSSQLLocalDB;Database=academico_db;Trusted_Connection=true;TrustServerCertificate=true;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}