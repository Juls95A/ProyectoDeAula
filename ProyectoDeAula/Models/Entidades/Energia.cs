using ProyectoDeAula.Models.Entidades;
using System;
using System.Collections.Generic;

namespace ProyectoDeAula_JulianaAlvarezVioletaAgudelo.Models.Entidades
{
    public class Energia
    {
        public int Promedio_consumo_energia;

        public Energia(int promedio_consumo_energia)
        {
            this.Promedio_consumo_energia = promedio_consumo_energia;
        }

        public static int CalcularPromedioConsumoEnergia(List<Cliente> clientes)
        {
            if (clientes == null || clientes.Count == 0)
            {
                throw new ArgumentException("La lista de clientes está vacía o es nula.");
            }

            int suma_consumo_energia = 0;
            foreach (Cliente cliente in clientes)
            {
                suma_consumo_energia += cliente.consumo_energia;
            }
            double promedio_consumo_energia_double = suma_consumo_energia / (double)clientes.Count;

            return (int)promedio_consumo_energia_double;
        }

        public static int CalcularConsumoExcesivoEnergia(List<Cliente> clientes)
        {
            if (clientes == null || clientes.Count == 0)
            {
                throw new ArgumentException("La lista de clientes está vacía o es nula.");
            }

            int promedio_consumo_energia = CalcularPromedioConsumoEnergia(clientes);
            int consumo_excesivo_energia = 0;
            foreach (Cliente cliente in clientes)
            {
                if (cliente.consumo_energia > promedio_consumo_energia)
                {
                    consumo_excesivo_energia += cliente.consumo_energia - promedio_consumo_energia;
                }
            }
            return consumo_excesivo_energia;
        }

        public static void MostrarPorcentajesConsumoExcesivoEnergiaPorEstrato(List<Cliente> clientes)
        {
            try
            {
                if (clientes == null || clientes.Count == 0)
                {
                    throw new ArgumentException("La lista de clientes está vacía o es nula.");
                }

                int promedio_consumo_energia = CalcularPromedioConsumoEnergia(clientes);
                Dictionary<int, int> ClientesExcesoEnergiaPorEstrato = new Dictionary<int, int>();

                foreach (Cliente cliente in clientes)
                {
                    if (!ClientesExcesoEnergiaPorEstrato.ContainsKey(cliente.estrato))
                    {
                        ClientesExcesoEnergiaPorEstrato[cliente.estrato] = 0;
                    }

                    if (cliente.consumo_energia > promedio_consumo_energia)
                    {
                        ClientesExcesoEnergiaPorEstrato[cliente.estrato]++;
                    }
                }

                foreach (var kvp in ClientesExcesoEnergiaPorEstrato)
                {
                    int estrato = kvp.Key;
                    int ClientesExcesoEnergia = kvp.Value;

                    double porcentaje = (double)ClientesExcesoEnergia / clientes.Count * 100;

                    Console.WriteLine($"El porcentaje de consumo excesivo de energia en el estrato {estrato} es: {porcentaje}%");
                }
            }
            catch (ArgumentException)
            {
                throw ;
            }
        }

        public static List<int> MostrarClientesConConsumoEnergiaMayorAlPromedio(List<Cliente> clientes)
        {
            try
            {
                if (clientes == null || clientes.Count == 0)
                {
                    throw new ArgumentException("La lista de clientes está vacía o es nula.");
                }

                int promedio_consumo_energia = CalcularPromedioConsumoEnergia(clientes);
                List<int> estratosClientesMayor = new List<int>();

                foreach (Cliente cliente in clientes)
                {
                    if (cliente.consumo_energia > promedio_consumo_energia)
                    {
                        if (!estratosClientesMayor.Contains(cliente.estrato))
                        {
                            estratosClientesMayor.Add(cliente.estrato);
                        }
                    }
                }
                return estratosClientesMayor;
            }
            catch (ArgumentException )
            {
                throw ;
            }
        }

        public static int EstratoConMayorAhorroDeEnergia(List<Cliente> clientes)
        {
            try
            {
                if (clientes == null || clientes.Count == 0)
                {
                    throw new ArgumentException("La lista de clientes está vacía o es nula.");
                }

                Dictionary<int, int> gastoPorEstrato = new Dictionary<int, int>();

                foreach (Cliente cliente in clientes)
                {
                    if (!gastoPorEstrato.ContainsKey(cliente.estrato))
                    {
                        gastoPorEstrato[cliente.estrato] = 0;
                    }

                    gastoPorEstrato[cliente.estrato] += cliente.consumo_energia;
                }

                int estratoMenorGastoEnergia = -1;
                int minGastoEnergia = int.MaxValue;

                foreach (var kvp in gastoPorEstrato)
                {
                    if (kvp.Value < minGastoEnergia)
                    {
                        minGastoEnergia = kvp.Value;
                        estratoMenorGastoEnergia = kvp.Key;
                    }
                }

                return estratoMenorGastoEnergia;
            }
            catch (ArgumentException )
            {
                throw ;
            }
        }

        public static List<int> EstratosConConsumoEnergiaMayorAlPromedio(List<Cliente> clientes)
        {
            throw new NotImplementedException();
        }
    }
}