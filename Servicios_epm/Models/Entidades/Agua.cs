using ProyectoDeAula.Models.Entidades;
using System;
using System.Collections.Generic;

namespace ProyectoDeAula_JulianaAlvarezVioletaAgudelo.Models.Entidades
{
    public class Agua
    {
        public int Promedio_consumo_agua;

        public Agua(int promedio_consumo_agua)
        {
            this.Promedio_consumo_agua = promedio_consumo_agua;
        }

        public static int CalcularPromedioConsumoAgua(List<Cliente> clientes)
        {
            try
            {
                int suma_consumo_agua = 0;
                foreach (Cliente cliente in clientes)
                {
                    suma_consumo_agua += cliente.consumo_agua;
                }
                double promedio_consumo_agua_double = suma_consumo_agua / (double)clientes.Count;

                return (int)promedio_consumo_agua_double;
            }
            catch (DivideByZeroException)
            {
                throw new ArgumentException("La lista de clientes está vacía.");
            }
        }

        public static int CalcularConsumoExcesivoAgua(List<Cliente> clientes)
        {
            try
            {
                int promedio_consumo_agua = CalcularPromedioConsumoAgua(clientes);
                int consumo_excesivo_agua = 0;
                foreach (Cliente cliente in clientes)
                {
                    if (cliente.consumo_agua > promedio_consumo_agua)
                    {
                        consumo_excesivo_agua += cliente.consumo_agua - promedio_consumo_agua;
                    }
                }
                return consumo_excesivo_agua;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public static void MostrarPorcentajesConsumoExcesivoAguaPorEstrato(List<Cliente> clientes)
        {
            try
            {
                int promedio_consumo_agua = CalcularPromedioConsumoAgua(clientes);
                Dictionary<int, int> ClientesExcesoAguaPorEstrato = new Dictionary<int, int>();

                foreach (Cliente cliente in clientes)
                {
                    if (!ClientesExcesoAguaPorEstrato.ContainsKey(cliente.estrato))
                    {
                        ClientesExcesoAguaPorEstrato[cliente.estrato] = 0;
                    }

                    if (cliente.consumo_agua > promedio_consumo_agua)
                    {
                        ClientesExcesoAguaPorEstrato[cliente.estrato]++;
                    }
                }

                foreach (var kvp in ClientesExcesoAguaPorEstrato)
                {
                    int estrato = kvp.Key;
                    int ClientesExcesoAgua = kvp.Value;

                    double porcentaje = (double)ClientesExcesoAgua / clientes.Count * 100;

                    Console.WriteLine($"El porcentaje de consumo excesivo de agua en el estrato {estrato} es: {porcentaje}%");
                }
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public static List<int> EstratosConConsumoAguaMayorAlPromedio(List<Cliente> clientes)
        {
            try
            {
                int promedio_consumo_agua = CalcularPromedioConsumoAgua(clientes);
                List<int> estratosClientesMayor = new List<int>();

                foreach (Cliente cliente in clientes)
                {
                    if (cliente.consumo_agua > promedio_consumo_agua)
                    {
                        if (!estratosClientesMayor.Contains(cliente.estrato))
                        {
                            estratosClientesMayor.Add(cliente.estrato);
                        }
                    }
                }
                return estratosClientesMayor;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public static int EstratoConMayorAhorroDeAgua(List<Cliente> clientes)
        {
            try
            {
                Dictionary<int, int> gastoPorEstrato = new Dictionary<int, int>();

                foreach (Cliente cliente in clientes)
                {
                    if (!gastoPorEstrato.ContainsKey(cliente.estrato))
                    {
                        gastoPorEstrato[cliente.estrato] = 0;
                    }

                    gastoPorEstrato[cliente.estrato] += cliente.consumo_agua;
                }

                int estratoMenorGastoAgua = -1;
                int minGastoAgua = int.MaxValue;

                foreach (var kvp in gastoPorEstrato)
                {
                    if (kvp.Value < minGastoAgua)
                    {
                        minGastoAgua = kvp.Value;
                        estratoMenorGastoAgua = kvp.Key;
                    }
                }

                return estratoMenorGastoAgua;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}