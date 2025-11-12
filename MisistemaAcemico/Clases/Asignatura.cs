using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace MisistemaAcemico.Clases
{
    public class Asignatura
    {
        private int id_asignatura;
        private string codigo;
        private string nombre;
        private int unidades;

        public int Id_asignatura
        {
            get { return id_asignatura; }
            set { id_asignatura = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value ?? ""; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value ?? ""; }
        }

        public int Unidades
        {
            get { return unidades; }
            set { unidades = value; }
        }

        public Asignatura() { }

        // Guardar una nueva asignatura
        public void Guardar()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"INSERT INTO asignatura (Codigo, Nombre, Unidades) 
                      VALUES (@codigo, @nombre, @unidades)", conn))
                {
                    cmd.Parameters.AddWithValue("@codigo", Codigo);
                    cmd.Parameters.AddWithValue("@nombre", Nombre);
                    cmd.Parameters.AddWithValue("@unidades", Unidades);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Actualizar una asignatura existente
        public void Actualizar()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"UPDATE asignatura 
                      SET Codigo = @codigo, Nombre = @nombre, Unidades = @unidades 
                      WHERE Id_asignatura = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Id_asignatura);
                    cmd.Parameters.AddWithValue("@codigo", Codigo);
                    cmd.Parameters.AddWithValue("@nombre", Nombre);
                    cmd.Parameters.AddWithValue("@unidades", Unidades);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Eliminar una asignatura (solo si no tiene inscripciones)
        public static void Eliminar(int id)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand("DELETE FROM asignatura WHERE Id_asignatura = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Obtener todas las asignaturas
        public static List<Asignatura> GetAll()
        {
            var lista = new List<Asignatura>();
            using (var conn = ConexionDB.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM asignatura", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) // ciclo while simple
                        {
                            var asignatura = new Asignatura();
                            asignatura.Id_asignatura = reader.GetInt32("Id_asignatura");
                            asignatura.Codigo = reader["Codigo"].ToString();
                            asignatura.Nombre = reader["Nombre"].ToString();
                            asignatura.Unidades = reader.GetInt32("Unidades");
                            lista.Add(asignatura);
                        }
                    }
                }
            }
            return lista;
        }
    }
}