using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace MisistemaAcemico.Clases
{
    public class Inscripcion
    {
        private int id_inscripcion;
        private int id_estudiante;
        private int id_asignatura;
        private int id_periodo;
        private int id_carrera;

        public int Id_inscripcion { get => id_inscripcion; set => id_inscripcion = value; }
        public int Id_estudiante { get => id_estudiante; set => id_estudiante = value; }
        public int Id_asignatura { get => id_asignatura; set => id_asignatura = value; }
        public int Id_periodo { get => id_periodo; set => id_periodo = value; }
        public int Id_carrera { get => id_carrera; set => id_carrera = value; }

        public string EstudianteNombre { get; set; }
        public string AsignaturaNombre { get; set; }
        public string PeriodoTexto { get; set; }
        public string CarreraNombre { get; set; }

        public Inscripcion() { }

        public void Registrar()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"INSERT INTO inscripcion (Id_estudiante, Id_asignatura, Id_periodo, id_carrera) 
                      VALUES (@est, @asig, @per, @carrera)", conn))
                {
                    cmd.Parameters.AddWithValue("@est", Id_estudiante);
                    cmd.Parameters.AddWithValue("@asig", Id_asignatura);
                    cmd.Parameters.AddWithValue("@per", Id_periodo);
                    cmd.Parameters.AddWithValue("@carrera", Id_carrera);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool Existe(int idEst, int idAsig, int idPer, int idCarrera)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"SELECT COUNT(1) FROM inscripcion 
                      WHERE Id_estudiante = @est AND Id_asignatura = @asig AND Id_periodo = @per AND id_carrera = @carrera", conn))
                {
                    cmd.Parameters.AddWithValue("@est", idEst);
                    cmd.Parameters.AddWithValue("@asig", idAsig);
                    cmd.Parameters.AddWithValue("@per", idPer);
                    cmd.Parameters.AddWithValue("@carrera", idCarrera);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static void EliminarPorIds(int idEst, int idAsig, int idPer)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"DELETE FROM inscripcion 
                      WHERE Id_estudiante = @est AND Id_asignatura = @asig AND Id_periodo = @per", conn))
                {
                    cmd.Parameters.AddWithValue("@est", idEst);
                    cmd.Parameters.AddWithValue("@asig", idAsig);
                    cmd.Parameters.AddWithValue("@per", idPer);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Inscripcion> GetAllConDatos()
        {
            var lista = new List<Inscripcion>();
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"SELECT 
                        i.Id_inscripcion,
                        i.Id_estudiante,
                        i.Id_asignatura,
                        i.Id_periodo,
                        i.id_carrera,
                        e.Nombres + ' ' + e.Apellidos AS EstudianteNombre,
                        a.Nombre AS AsignaturaNombre,
                        p.Anio,
                        p.Ciclo,
                        c.carrera AS CarreraNombre
                      FROM inscripcion i
                      INNER JOIN estudiante e ON i.Id_estudiante = e.Id_estudiante
                      INNER JOIN asignatura a ON i.Id_asignatura = a.Id_asignatura
                      INNER JOIN periodo p ON i.Id_periodo = p.Id_periodo
                      INNER JOIN carrera c ON i.id_carrera = c.id_carrera", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Inscripcion
                            {
                                Id_inscripcion = reader.GetInt32("Id_inscripcion"),
                                Id_estudiante = reader.GetInt32("Id_estudiante"),
                                Id_asignatura = reader.GetInt32("Id_asignatura"),
                                Id_periodo = reader.GetInt32("Id_periodo"),
                                Id_carrera = reader.GetInt32("id_carrera"),
                                EstudianteNombre = reader["EstudianteNombre"].ToString(),
                                AsignaturaNombre = reader["AsignaturaNombre"].ToString(),
                                PeriodoTexto = $"{reader.GetInt32("Anio")} - {reader["Ciclo"].ToString()}",
                                CarreraNombre = reader["CarreraNombre"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}