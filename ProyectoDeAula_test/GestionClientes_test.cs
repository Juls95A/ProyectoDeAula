using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDeAula.Models.Entidades;

namespace ProyectoDeAula_test


{
    [TestClass]
    public class GestionClientes_test
    {
        [TestMethod]

        public void AgregarClienteTest()
        {

            List<Cliente> clientes = new List<Cliente>();
            Cliente cliente=new Cliente("Juan", "Perez", 123, 3, 100, 50, 20);

            GestionClientes.AgregarClientes(clientes, cliente);


            Assert.IsTrue(clientes.Count == 1);

        }
    }
}
