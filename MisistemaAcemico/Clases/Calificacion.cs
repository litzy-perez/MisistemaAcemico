using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace MisistemaAcemico.Clases
{
    public class Calificacion
    {
        private int id_calificacion;
        private int id_inscripcion;
        private double nota;

        // Campos para el sistema antiguo (una sola nota)
        public int Id_calificacion { get => id_calificacion; set => id_calificacion = value; }
        public int Id_inscripcion { get => id_inscripcion; set => id_inscripcion = value; }
        public double Nota
        {
            get => nota;
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentException("La nota debe estar entre 0 y 10.");
                nota = value;
            }
        }

        // Campos para el sistema nuevo (3 notas + promedio)
        public decimal? Nota1 { get; set; }
        public decimal? Nota2 { get; set; }
        public decimal? Nota3 { get; set; }
        public decimal? PromedioFinal { get; set; }

        public Calificacion() { }

        // Métodos para el sistema antiguo (una sola nota)
        public void Guardar()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "INSERT INTO calificacion (Id_inscripcion, Nota) VALUES (@insc, @nota)", conn))
                {
                    cmd.Parameters.AddWithValue("@insc", Id_inscripcion);
                    cmd.Parameters.AddWithValue("@nota", Nota);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Actualizar()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "UPDATE calificacion SET Nota = @nota WHERE Id_calificacion = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Id_calificacion);
                    cmd.Parameters.AddWithValue("@nota", Nota);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Eliminar(int id)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "DELETE FROM calificacion WHERE Id_calificacion = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool ExistePorInscripcion(int idInscripcion)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "SELECT COUNT(1) FROM calificacion WHERE Id_inscripcion = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", idInscripcion);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Método para el sistema nuevo (3 notas + promedio)
        public void RegistrarNotas()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"IF EXISTS (SELECT 1 FROM calificacion WHERE Id_inscripcion = @ins)
                        UPDATE calificacion 
                        SET Nota1 = @n1, Nota2 = @n2, Nota3 = @n3, PromedioFinal = @prom 
                        WHERE Id_inscripcion = @ins
                      ELSE
                        INSERT INTO calificacion (Id_inscripcion, Nota1, Nota2, Nota3, PromedioFinal)
                        VALUES (@ins, @n1, @n2, @n3, @prom)", conn))
                {
                    cmd.Parameters.AddWithValue("@ins", Id_inscripcion);
                    cmd.Parameters.AddWithValue("@n1", (object)Nota1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@n2", (object)Nota2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@n3", (object)Nota3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@prom", (object)PromedioFinal ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para cargar las 3 notas y promedio
        public static Calificacion GetPorInscripcion(int idInscripcion)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"SELECT Id_calificacion, Id_inscripcion, Nota1, Nota2, Nota3, PromedioFinal 
                      FROM calificacion WHERE Id_inscripcion = @ins", conn))
                {
                    cmd.Parameters.AddWithValue("@ins", idInscripcion);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Calificacion
                            {
                                Id_calificacion = reader.GetInt32("Id_calificacion"),
                                Id_inscripcion = reader.GetInt32("Id_inscripcion"),
                                Nota1 = reader.IsDBNull("Nota1") ? null : reader.GetDecimal("Nota1"),
                                Nota2 = reader.IsDBNull("Nota2") ? null : reader.GetDecimal("Nota2"),
                                Nota3 = reader.IsDBNull("Nota3") ? null : reader.GetDecimal("Nota3"),
                                PromedioFinal = reader.IsDBNull("PromedioFinal") ? null : reader.GetDecimal("PromedioFinal")
                            };
                        }
                        return null;
                    }
                }
            }
        }

        // Método para calcular el promedio
        public void CalcularPromedio()
        {
            if (Nota1.HasValue && Nota2.HasValue && Nota3.HasValue)
            {
                PromedioFinal = Math.Round((Nota1.Value + Nota2.Value + Nota3.Value) / 3, 2);
            }
            else
            {
                PromedioFinal = null;
            }
        }

        // Método para el sistema antiguo (promedio general)
        public static double CalcularPromedioGeneral()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT AVG(Nota) FROM calificacion", conn))
                {
                    var result = cmd.ExecuteScalar();
                    return result == DBNull.Value ? 0 : Convert.ToDouble(result);
                }
            }
        }

        // Método para el sistema nuevo (cargar con datos)
        public static List<CalificacionCompleta> GetCalificacionesConDatos()
        {
            var lista = new List<CalificacionCompleta>();
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"SELECT 
                c.Id_calificacion,
                c.Id_inscripcion,
                c.Nota1,
                c.Nota2,
                c.Nota3,
                c.PromedioFinal,
                i.Id_estudiante,
                i.Id_asignatura,
                i.Id_periodo,
                e.Nombres + ' ' + e.Apellidos AS EstudianteNombre,
                a.Nombre AS AsignaturaNombre,
                p.Anio, p.Ciclo
              FROM calificacion c
              INNER JOIN inscripcion i ON c.Id_inscripcion = i.Id_inscripcion
              INNER JOIN estudiante e ON i.Id_estudiante = e.Id_estudiante
              INNER JOIN asignatura a ON i.Id_asignatura = a.Id_asignatura
              INNER JOIN periodo p ON i.Id_periodo = p.Id_periodo", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CalificacionCompleta
                            {
                                Id_calificacion = reader.GetInt32("Id_calificacion"),
                                Id_inscripcion = reader.GetInt32("Id_inscripcion"),
                                Id_estudiante = reader.GetInt32("Id_estudiante"),
                                Id_asignatura = reader.GetInt32("Id_asignatura"),
                                Id_periodo = reader.GetInt32("Id_periodo"),
                                Nota1 = reader.IsDBNull("Nota1") ? null : reader.GetDecimal("Nota1"),
                                Nota2 = reader.IsDBNull("Nota2") ? null : reader.GetDecimal("Nota2"),
                                Nota3 = reader.IsDBNull("Nota3") ? null : reader.GetDecimal("Nota3"),
                                PromedioFinal = reader.IsDBNull("PromedioFinal") ? null : reader.GetDecimal("PromedioFinal"),
                                EstudianteNombre = reader["EstudianteNombre"].ToString(),
                                AsignaturaNombre = reader["AsignaturaNombre"].ToString(),
                                PeriodoTexto = $"{reader.GetInt32("Anio")} - {reader["Ciclo"]}"
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }

    public class CalificacionCompleta
    {
        public int Id_calificacion { get; set; }
        public int Id_inscripcion { get; set; }
        public int Id_estudiante { get; set; }
        public int Id_asignatura { get; set; }
        public int Id_periodo { get; set; }
        public decimal? Nota1 { get; set; }
        public decimal? Nota2 { get; set; }
        public decimal? Nota3 { get; set; }
        public decimal? PromedioFinal { get; set; }
        public string EstudianteNombre { get; set; }
        public string AsignaturaNombre { get; set; }
        public string PeriodoTexto { get; set; }
    }
}