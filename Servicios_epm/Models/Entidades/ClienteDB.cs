using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Servicios_epm.datos;

namespace ProyectoDeAula_JulianaAlvarezVioletaAgudelo.Models.Entidades
{
    public class ClienteData
    {
        static Conexion connection = new Conexion();

        public DataSet BuscarTodos() // Buscar todos los clientes
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    string query = "SELECT C.IdCliente, C.nombre, C.apellido, C.cedula, C.periodo, C.meta_ahorro, C.consumo_energia, C.consumo_agua, C.consumo_gas FROM Cliente AS C";

                    sqlConnection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                    adapter.Fill(dataSet, "Clientes");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar todos los clientes: " + ex.Message);
            }

            return dataSet;
        }

        public static DataTable Buscar(string datoBusqueda, string criterio) // Buscar un cliente
        {
            DataTable dtClientes = new DataTable();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();

                    StringBuilder sbSql = new StringBuilder();
                    sbSql.Append("SELECT C.IdCliente, C.nombre, C.apellido, C.cedula, C.periodo, C.meta_ahorro, C.consumo_energia, C.consumo_agua, C.consumo_gas FROM Cliente AS C WHERE ");
                    sbSql.Append(criterio == "Id" ? "C.id_cliente = @datoBusqueda" : "C.cedula = @datoBusqueda");
                    sbSql.Append(";");
                    string sql = sbSql.ToString();

                    SqlDataAdapter adaptador = new SqlDataAdapter(sql, sqlConnection);
                    adaptador.SelectCommand.Parameters.AddWithValue("@datoBusqueda", datoBusqueda);

                    adaptador.Fill(dtClientes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar cliente por " + criterio + ": " + ex.Message);
            }

            return dtClientes;
        }

        public static bool Insertar(int cedula, string nombre, string apellidos, int estrato, int periodo, int meta_ahorro, int consumo_energia, int consumo_agua, int consumo_gas) // Agregar cliente
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();

                    string query = @"INSERT INTO tbClientes (Cedula, Nombre, Apellidos, Estrato, Periodo, Meta_ahorro, Consumo_energia, Consumo_agua, Consumo_gas) 
                                     VALUES (@cedula, @nombre, @apellidos, @estrato, @periodo, @meta_ahorro, @consumo_energia, @consumo_agua, @consumo_gas);";

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("@cedula", cedula);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellidos", apellidos);
                    command.Parameters.AddWithValue("@estrato", estrato);
                    command.Parameters.AddWithValue("@periodo", periodo);
                    command.Parameters.AddWithValue("@meta_ahorro", meta_ahorro);
                    command.Parameters.AddWithValue("@consumo_energia", consumo_energia);
                    command.Parameters.AddWithValue("@consumo_agua", consumo_agua);
                    command.Parameters.AddWithValue("@consumo_gas", consumo_gas);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar cliente: " + ex.Message);
                return false;
            }
        }

        public static bool Eliminar(string cedula) // Eliminar cliente
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();

                    string query = @"DELETE FROM tbClientes WHERE Cedula = @cedula;";

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("@cedula", cedula);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar cliente: " + ex.Message);
                return false;
            }
        }

        public static bool Actualizar(int cedula, int estrato, int periodo, int meta_ahorro, int consumo_energia, int consumo_agua, int consumo_gas) // Actualizar cliente
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();

                    string query = @"UPDATE tbClientes SET Estrato = @estrato, Periodo = @periodo, Meta_ahorro = @meta_ahorro, Consumo_energia = @consumo_energia, Consumo_agua = @consumo_agua, Consumo_gas = @consumo_gas
                                     WHERE Cedula = @cedula;";

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("@estrato", estrato);
                    command.Parameters.AddWithValue("@periodo", periodo);
                    command.Parameters.AddWithValue("@meta_ahorro", meta_ahorro);
                    command.Parameters.AddWithValue("@consumo_energia", consumo_energia);
                    command.Parameters.AddWithValue("@consumo_agua", consumo_agua);
                    command.Parameters.AddWithValue("@consumo_gas", consumo_gas);
                    command.Parameters.AddWithValue("@cedula", cedula);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar cliente: " + ex.Message);
                return false;
            }
        }
    }
}
