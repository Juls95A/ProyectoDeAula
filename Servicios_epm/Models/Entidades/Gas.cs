using ProyectoDeAula.Models.Entidades;

namespace ProyectoDeAula_JulianaAlvarezVioletaAgudelo.Models.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Gas
    {
        public static int ClienteConConsumoMayorGas(List<Cliente> clientes)
        {
            try
            {
                if (clientes == null || clientes.Count == 0)
                {
                    throw new ArgumentException("La lista de clientes está vacía o es nula.");
                }

                Cliente ClienteMayorConsumo = clientes[0];

                foreach (Cliente cliente in clientes)
                {
                    if (cliente.consumo_gas > ClienteMayorConsumo.consumo_gas)
                    {
                        ClienteMayorConsumo = cliente;
                    }
                }
                return ClienteMayorConsumo.cedula;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public static List<int> ClienteConConsumoMayorGasPeriodo(List<Cliente> clientes)
        {
            try
            {
                if (clientes == null || clientes.Count == 0)
                {
                    throw new ArgumentException("La lista de clientes está vacía o es nula.");
                }

                List<int> PeriodosClienteMayor = new List<int>();
                Cliente ClienteMayorConsumo = clientes[0];

                foreach (Cliente cliente in clientes)
                {
                    if (cliente.consumo_gas > ClienteMayorConsumo.consumo_gas)
                    {
                        if (!PeriodosClienteMayor.Contains(cliente.periodo))
                        {
                            PeriodosClienteMayor.Add(cliente.periodo);
                        }
                    }
                }
                return PeriodosClienteMayor;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}