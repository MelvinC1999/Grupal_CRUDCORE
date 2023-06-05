using CRUDCORE.Models;
using System.Data.SqlClient; // Ayuda a usar los objetos y clases de SQL
using System.Data;

namespace CRUDCORE.Datos
{
    public class ContactoDatos
    {
        // Método para obtener la lista de todos los contactos
         public List<ContactoModelo> Listar()
         {
            var oLista = new List<ContactoModelo>(); // Referencia a la lista en el objeto oLista

            var cn = new Conexion(); // Instancia de la clase de conexión

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) // Establecer la cadena de conexión
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Leer el resultado del procedimiento
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read()) // Lee uno a uno
                    {
                        oLista.Add(new ContactoModelo() // Llama a cada una de la propiedades que vamos a utilizar
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["NOMBRE"].ToString(),
                            Telefono = dr["TELEFONO"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }

            return oLista;
         }

        public ContactoModelo Obtener(int IdContacto)
        {
            var oContacto = new ContactoModelo(); // Hace referencia a la lista en el objeto oLIsta

            var cn = new Conexion(); // Instancia de la clase de conexión

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) // Establecer la cadena de conexión
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["NOMBRE"].ToString();
                        oContacto.Telefono = dr["TELEFONO"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                    }
                }
            }

            return oContacto;
        }

        public bool Guardar(ContactoModelo oContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("NOMBRE", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("TELEFONO", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("CORREO", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true; // Si no tiene error es Verdadero
            }

            catch (Exception ex)
            {
                string error = ex.Message; // Guarda el mensaje
                rpta = false; // Si tiene error Faslo
            }

            return rpta;
        }

        public bool Editar(ContactoModelo oContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", oContacto.IdContacto);
                    cmd.Parameters.AddWithValue("NOMBRE", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("TELEFONO", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("CORREO", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }

            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar(int IdContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }

            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}
