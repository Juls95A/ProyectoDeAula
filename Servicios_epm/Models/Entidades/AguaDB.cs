using Servicios_epm.datos;
using System.Data.SqlClient;
using System.Data;

namespace Servicios_epm.modelos
{
    public class aguaDB
    {
        static Conexion connection = new Conexion();

        public static DataTable BuscarTodos()
        {
            DataTable dtAgua = new DataTable();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();

                    string query = "SELECT A.IdAgua, A.Promedio_consumo_agua, A.IdCliente FROM Agua AS A";

                    SqlDataAdapter adaptador = new SqlDataAdapter(query, sqlConnection);
                    adaptador.Fill(dtAgua);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar todos los registros de agua: " + ex.Message);
            }

            return dtAgua;
        }

        public static DataTable Buscar(int idAgua)
        {
            DataTable dtAgua = new DataTable();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();

                    string query = "SELECT A.IdAgua, A.Promedio_consumo_agua, A.IdCliente FROM Agua AS A WHERE A.IdAgua = @idAgua";

                    SqlDataAdapter adaptador = new SqlDataAdapter(query, sqlConnection);
                    adaptador.SelectCommand.Parameters.AddWithValue("@idAgua", idAgua);

                    adaptador.Fill(dtAgua);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar el registro de agua: " + ex.Message);
            }

            return dtAgua;
        }

        public static bool Insertar(int promedioConsumoAgua, int idCliente)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();

                    string query = @"INSERT INTO Agua (Promedio_consumo_agua, IdCliente) 
                                     VALUES (@promedioConsumoAgua, @idCliente);";

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("@promedioConsumoAgua", promedioConsumoAgua);
                    command.Parameters.AddWithValue("@idCliente", idCliente);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar el registro de agua: " + ex.Message);
                return false;
            }
        }

        public static bool Eliminar(int idAgua)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();

                    string query = @"DELETE FROM Agua WHERE IdAgua = @idAgua;";

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("@idAgua", idAgua);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el registro de agua: " + ex.Message);
                return false;
            }
        }

        public static bool Actualizar(int idAgua, int promedioConsumoAgua, int idCliente)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                {
                    sqlConnection.Open();

                    string query = @"UPDATE Agua SET Promedio_consumo_agua = @promedioConsumoAgua, IdCliente = @idCliente
                                     WHERE IdAgua = @idAgua;";

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("@promedioConsumoAgua", promedioConsumoAgua);
                    command.Parameters.AddWithValue("@idCliente", idCliente);
                    command.Parameters.AddWithValue("@idAgua", idAgua);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el registro de agua: " + ex.Message);
                return false;
            }
        }
    }


namespace Servicios_epm.modelos
    {
        public class aguaDB
        {
            static Conexion connection = new Conexion();

            public static DataTable BuscarTodos()
            {
                DataTable dtAgua = new DataTable();

                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                    {
                        sqlConnection.Open();

                        string query = "SELECT A.IdAgua, A.Promedio_consumo_agua, A.IdCliente FROM Agua AS A";

                        SqlDataAdapter adaptador = new SqlDataAdapter(query, sqlConnection);
                        adaptador.Fill(dtAgua);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al buscar todos los registros de agua: " + ex.Message);
                }

                return dtAgua;
            }

            public static DataTable Buscar(int idAgua)
            {
                DataTable dtAgua = new DataTable();

                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                    {
                        sqlConnection.Open();

                        string query = "SELECT A.IdAgua, A.Promedio_consumo_agua, A.IdCliente FROM Agua AS A WHERE A.IdAgua = @idAgua";

                        SqlDataAdapter adaptador = new SqlDataAdapter(query, sqlConnection);
                        adaptador.SelectCommand.Parameters.AddWithValue("@idAgua", idAgua);

                        adaptador.Fill(dtAgua);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al buscar el registro de agua: " + ex.Message);
                }

                return dtAgua;
            }

            public static bool Insertar(int promedioConsumoAgua, int idCliente)
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                    {
                        sqlConnection.Open();

                        string query = @"INSERT INTO Agua (Promedio_consumo_agua, IdCliente) 
                                     VALUES (@promedioConsumoAgua, @idCliente);";

                        SqlCommand command = new SqlCommand(query, sqlConnection);
                        command.Parameters.AddWithValue("@promedioConsumoAgua", promedioConsumoAgua);
                        command.Parameters.AddWithValue("@idCliente", idCliente);
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar el registro de agua: " + ex.Message);
                    return false;
                }
            }

            public static bool Eliminar(int idAgua)
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                    {
                        sqlConnection.Open();

                        string query = @"DELETE FROM Agua WHERE IdAgua = @idAgua;";

                        SqlCommand command = new SqlCommand(query, sqlConnection);
                        command.Parameters.AddWithValue("@idAgua", idAgua);
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar el registro de agua: " + ex.Message);
                    return false;
                }
            }

            public static bool Actualizar(int idAgua, int promedioConsumoAgua, int idCliente)
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connection.conexion))
                    {
                        sqlConnection.Open();

                        string query = @"UPDATE Agua SET Promedio_consumo_agua = @promedioConsumoAgua, IdCliente = @idCliente
                                     WHERE IdAgua = @idAgua;";

                        SqlCommand command = new SqlCommand(query, sqlConnection);
                        command.Parameters.AddWithValue("@promedioConsumoAgua", promedioConsumoAgua);
                        command.Parameters.AddWithValue("@idCliente", idCliente);
                        command.Parameters.AddWithValue("@idAgua", idAgua);
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar el registro de agua: " + ex.Message);
                    return false;
                }
            }
        }
    }
}