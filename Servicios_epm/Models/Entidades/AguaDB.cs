using Servicios_epm.datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoDeAula_JulianaAlvarezVioletaAgudelo.Datos
{
    public class AguaBD
    {
        static Conexion connection = new Conexion();

        // Método para obtener el promedio de consumo de agua de todos los clientes
        public static int ObtenerPromedioConsumoAgua()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();
                    string query = "SELECT AVG(consumo_agua) FROM Cliente;";
                    SqlCommand command = new SqlCommand(query, sqlConnection);

                    // Convertir el resultado a entero y devolverlo
                    int promedio = Convert.ToInt32(command.ExecuteScalar());
                    return promedio;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el promedio de consumo de agua: " + ex.Message);
                return 0;
            }
        }

        // Método para calcular el consumo excesivo de agua
        public static int ObtenerConsumoExcesivoAgua()
        {
            try
            {
                int promedio = ObtenerPromedioConsumoAgua();

                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();
                    string query = "SELECT SUM(consumo_agua - @promedio) FROM Cliente WHERE consumo_agua > @promedio;";
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("@promedio", promedio);

                    int consumoExcesivo = Convert.ToInt32(command.ExecuteScalar());
                    return consumoExcesivo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el consumo excesivo de agua: " + ex.Message);
                return 0;
            }
        }

        // Método para obtener los porcentajes de consumo excesivo de agua por estrato
        public static Dictionary<int, double> ObtenerPorcentajesConsumoExcesivoAguaPorEstrato()
        {
            try
            {
                int promedio = ObtenerPromedioConsumoAgua();

                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();
                    string query = @"
                        SELECT estrato, 
                               COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Cliente) AS porcentaje
                        FROM Cliente
                        WHERE consumo_agua > @promedio
                        GROUP BY estrato;";

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("@promedio", promedio);

                    SqlDataReader reader = command.ExecuteReader();
                    Dictionary<int, double> porcentajesPorEstrato = new Dictionary<int, double>();

                    while (reader.Read())
                    {
                        int estrato = reader.GetInt32(0);
                        double porcentaje = reader.GetDouble(1);
                        porcentajesPorEstrato[estrato] = porcentaje;
                    }

                    return porcentajesPorEstrato;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los porcentajes de consumo excesivo de agua por estrato: " + ex.Message);
                return null;
            }
        }

        // Método para obtener los estratos con consumo de agua mayor al promedio
        public static List<int> ObtenerEstratosConConsumoAguaMayorAlPromedio()
        {
            try
            {
                int promedio = ObtenerPromedioConsumoAgua();

                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();
                    string query = @"
                        SELECT DISTINCT estrato
                        FROM Cliente
                        WHERE consumo_agua > @promedio;";

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("@promedio", promedio);

                    SqlDataReader reader = command.ExecuteReader();
                    List<int> estratosClientesMayor = new List<int>();

                    while (reader.Read())
                    {
                        estratosClientesMayor.Add(reader.GetInt32(0));
                    }

                    return estratosClientesMayor;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los estratos con consumo de agua mayor al promedio: " + ex.Message);
                return null;
            }
        }

        // Método para obtener el estrato con mayor ahorro de agua
        public static int ObtenerEstratoConMayorAhorroDeAgua()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();
                    string query = @"
                        SELECT TOP 1 estrato
                        FROM Cliente
                        GROUP BY estrato
                        ORDER BY SUM(consumo_agua) ASC;";

                    SqlCommand command = new SqlCommand(query, sqlConnection);

                    int estratoMenorGastoAgua = Convert.ToInt32(command.ExecuteScalar());
                    return estratoMenorGastoAgua;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el estrato con mayor ahorro de agua: " + ex.Message);
                return 0;
            }
        }
    }
}

