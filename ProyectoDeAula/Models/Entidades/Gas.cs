using ProyectoDeAula.Models.Entidades;

namespace ProyectoDeAula_JulianaAlvarezVioletaAgudelo.Models.Entidades
{
    public class Gas
    {
        public static int ClienteConConsumoMayorGas(List<Cliente> clientes)
        {
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
        public static List<int> ClienteConConsumoMayorGasPeriodo(List<Cliente> clientes)
        {

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
    }
}