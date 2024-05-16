using Servicios_epm.datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoDeAula_JulianaAlvarezVioletaAgudelo.Datos
{
    public class EnergiaBD
    {
        static Conexion connection = new Conexion();

        public static int ObtenerPromedioConsumoEnergia()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();

                    string query = "SELECT AVG(consumo_energia) FROM Cliente;";

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    int promedio = Convert.ToInt32(command.ExecuteScalar());

                    return promedio;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el promedio de consumo de energía: " + ex.Message);
                return 0;
            }
        }

        public static int ObtenerConsumoExcesivoEnergia()
        {
            try
            {
                int promedio = ObtenerPromedioConsumoEnergia();

                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();

                    string query = "SELECT SUM(consumo_energia - @promedio) FROM Cliente WHERE consumo_energia > @promedio;";

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("@promedio", promedio);

                    int consumoExcesivo = Convert.ToInt32(command.ExecuteScalar());

                    return consumoExcesivo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el consumo excesivo de energía: " + ex.Message);
                return 0;
            }
        }

    }
}
