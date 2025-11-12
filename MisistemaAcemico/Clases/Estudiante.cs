using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace MisistemaAcemico.Clases
{
    public class Estudiante : Persona
    {
        private int id_estudiante;
        private string carnet;
        private string telefono;
        private string estado;
        private string genero;

        private string carrera;
     
     
        public int Id_estudiante
        {
            get => id_estudiante;
            set => id_estudiante = value;
        }

        public string Carnet
        {
            get => carnet;
            set => carnet = string.IsNullOrEmpty(value) ? "" : value;
        }

        public string Genero
        {
            get => genero;
            set => genero = string.IsNullOrEmpty(value) ? "Hombre" : value;
        }

        public string Telefono
        {
            get => telefono;
            set => telefono = string.IsNullOrEmpty(value) ? "" : value;
        }

        public string Estado
        {
            get => estado;
            set => estado = string.IsNullOrEmpty(value) ? "Activo" : value;
        }

        public Estudiante(string noms = "", string apels = "") : base(noms, apels) { }

        public override void MostrarInfo()
        {
            MessageBox.Show(
                $"Estudiante: {Nombres} {Apellidos}\nCarnet: {Carnet}\nEstado: {Estado}");
        }

        public static List<Estudiante> GetAll()
        {
            var lista = new List<Estudiante>();
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM estudiante", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Estudiante
                        {
                            Id_estudiante = reader.GetInt32("Id_estudiante"),
                            Carnet = reader["Carnet"].ToString(),
                            Nombres = reader["Nombres"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Estado = reader["Estado"].ToString(),
                            Genero = reader["Genero"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public void Actualizar()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"UPDATE estudiante 
                      SET Nombres = @nombres, Apellidos = @apellidos, Telefono = @telefono, Estado = @estado, Genero = @genero 
                      WHERE Id_estudiante = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Id_estudiante);
                    cmd.Parameters.AddWithValue("@nombres", Nombres);
                    cmd.Parameters.AddWithValue("@apellidos", Apellidos);
                    cmd.Parameters.AddWithValue("@telefono", Telefono);
                    cmd.Parameters.AddWithValue("@estado", Estado);
                    cmd.Parameters.AddWithValue("@genero", Genero);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Guardar()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"INSERT INTO estudiante (Carnet, Nombres, Apellidos, Telefono, Estado, Genero) 
                      VALUES (@carnet, @nombres, @apellidos, @telefono, @estado, @genero)", conn))
                {
                    cmd.Parameters.AddWithValue("@carnet", Carnet);
                    cmd.Parameters.AddWithValue("@nombres", Nombres);
                    cmd.Parameters.AddWithValue("@apellidos", Apellidos);
                    cmd.Parameters.AddWithValue("@telefono", Telefono);
                    cmd.Parameters.AddWithValue("@estado", Estado);
                    cmd.Parameters.AddWithValue("@genero", Genero);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Desactivar()
        {
            Estado = "Inactivo";
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "UPDATE estudiante SET Estado = 'Inactivo' WHERE Id_estudiante = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Id_estudiante);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Estudiante BuscarPorCarnet(string carnet)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM estudiante WHERE Carnet = @carnet", conn))
                {
                    cmd.Parameters.AddWithValue("@carnet", carnet);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Estudiante
                            {
                                Id_estudiante = reader.GetInt32("Id_estudiante"),
                                Carnet = reader["Carnet"].ToString(),
                                Nombres = reader["Nombres"].ToString(),
                                Apellidos = reader["Apellidos"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Estado = reader["Estado"].ToString(),
                                Genero = reader["Genero"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        internal static object BuscarPorNombre(string estudianteNombre)
        {
            throw new NotImplementedException();
        }
    }
}