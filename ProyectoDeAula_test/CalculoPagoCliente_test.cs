using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDeAula.Models.Entidades;
using ProyectoDeAula_JulianaAlvarezVioletaAgudelo.Models.Entidades;

namespace ProyectoDeAula_test
{
    [TestClass]
    public class CalculoPagoCliente_test
    {
        [TestMethod]
        public void CalcularValorAPagar()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente("Juan", "Perez", 123, 3, 150, 100, 20),
                new Cliente("Pedro", "Lopez", 345, 4, 170, 190, 25),
                new Cliente("Pedro", "Lopez", 345, 3, 160, 190, 28)
            };

            Cliente cliente = new Cliente("sebastian", "Perez", 123, 3, 180, 200, 30);
            clientes.Add(cliente);

            int valor_pagar = CalculoPagoCliente.CalcularValorAPagar(cliente, clientes);
            Assert.AreEqual(348000, valor_pagar);
        }

    }
}