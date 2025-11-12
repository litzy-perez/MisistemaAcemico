using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisistemaAcemico.Clases
{
    public class Carrera
    {
        private int id_carrera;
        private string nombre;

        public int Id_carrera { get => id_carrera; set => id_carrera = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Carrera() { }

        public static List<Carrera> GetAll()
        {
            var lista = new List<Carrera>();
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT id_carrera, carrera FROM carrera ORDER BY carrera", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Carrera
                            {
                                Id_carrera = reader.GetInt32("id_carrera"),
                                Nombre = reader["carrera"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}