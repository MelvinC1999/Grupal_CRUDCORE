using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace CRUDCORE.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;

        public Conexion() {
            
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            // Cadena de conexión

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        
        }

        // Método que devuelve la cadena SQL

        public string getCadenaSQL()
        {
            return cadenaSQL;
        }

    }
}
