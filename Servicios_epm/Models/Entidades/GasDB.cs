using Servicios_epm.datos;
using System;
using System.Data.SqlClient;

namespace ProyectoDeAula_JulianaAlvarezVioletaAgudelo.Datos
{
    public class GasBD
    {
        static Conexion connection = new Conexion();

        // Método para obtener el cliente con mayor consumo de gas
        public static int ObtenerClienteConMayorConsumoGas()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();
                    string query = "SELECT TOP 1 cedula FROM Cliente ORDER BY consumo_gas DESC;";
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el cliente con mayor consumo de gas: " + ex.Message);
                return 0;
            }
        }
    }
}
