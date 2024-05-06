using ProyectoDeAula_JulianaAlvarezVioletaAgudelo.Models.Entidades;

namespace ProyectoDeAula.Models.Entidades
{
    public class CalculoPagoCliente
    {


        public static int CalcularValorAPagar(Cliente cliente, List<Cliente> clientes)
        {
            int valor_parcial = cliente.Consumo_energia * 850;
            int valor_incentivo = (cliente.Meta_ahorro - cliente.Consumo_energia) * 850;
            int valor_total_energia = valor_parcial - valor_incentivo;

            int valor_gas = cliente.Consumo_gas * 2543;
            int valor_agua = 0;
            int valor_exceso = 0;
            int valor_total_agua = 0;
            int valor_pagar = 0;
            int promedio_consumo_agua = Agua.CalcularPromedioConsumoAgua(clientes);

            if (cliente.Consumo_agua > promedio_consumo_agua)
            {
                valor_agua = 25 * 4600;
                valor_exceso = (cliente.Consumo_agua - promedio_consumo_agua) * (9200);
                valor_total_agua = valor_agua + valor_exceso;
            }
            else
            {
                valor_total_agua = cliente.Consumo_agua * 4600;
            }
            valor_pagar = valor_total_energia + valor_total_agua + valor_gas;
            return valor_pagar;
        }

    } 

}
