using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace MisistemaAcemico.Clases
{
    public class Periodo
    {
        private int id_periodo;
        private int anio;
        private string ciclo;

        // Propiedades públicas (encapsulamiento)
        public int Id_periodo
        {
            get { return id_periodo; }
            set { id_periodo = value; }
        }

        public int Anio
        {
            get { return anio; }
            set { anio = value; }
        }

        public string Ciclo
        {
            get { return ciclo; }
            set { ciclo = value ?? ""; }
        }

        
        public Periodo() { }

        // Obtener todos los períodos
        public static List<Periodo> GetAll()
        {
            var lista = new List<Periodo>();
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM periodo", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var periodo = new Periodo();
                            periodo.Id_periodo = reader.GetInt32("Id_periodo");
                            periodo.Anio = reader.GetInt32("Anio");
                            periodo.Ciclo = reader["Ciclo"].ToString();
                            lista.Add(periodo);
                        }
                    }
                }
            }
            return lista;
        }

        // Guardar un nuevo período
        public void Guardar()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"INSERT INTO periodo (Anio, Ciclo) 
                      VALUES (@anio, @ciclo)", conn))
                {
                    cmd.Parameters.AddWithValue("@anio", Anio);
                    cmd.Parameters.AddWithValue("@ciclo", Ciclo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Actualizar un período existente
        public void Actualizar()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"UPDATE periodo 
                      SET Anio = @anio, Ciclo = @ciclo 
                      WHERE Id_periodo = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Id_periodo);
                    cmd.Parameters.AddWithValue("@anio", Anio);
                    cmd.Parameters.AddWithValue("@ciclo", Ciclo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Eliminar un período
        public static void Eliminar(int id)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand("DELETE FROM periodo WHERE Id_periodo = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}