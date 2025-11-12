using Microsoft.Data.SqlClient;

namespace MisistemaAcemico.Clases
{
    public class ConexionDB
    {
        private static string cadena = @"Server=DESKTOP-GLJR0B3;Database=academico_db;Trusted_Connection=true;TrustServerCertificate=true;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}