using ProyectoDeAula.Controllers;
using ProyectoDeAula.Models.Entidades;
using ProyectoDeAula_JulianaAlvarezVioletaAgudelo.Models.Entidades;
namespace ProyectoDeAula_test

{
    [TestClass]
    public class Agua_test
    {
        
        [TestMethod]

        public void CalcularPromedioConsumoaguaTest()

        {
            //arrange
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente("Juan", "Perez", 123, 3, 150, 100, 20),
                new Cliente("Maria", "Gomez", 134, 2, 200, 180, 35),
                new Cliente("Pedro", "Lopez", 345, 4, 170, 190, 25),
                new Cliente("Pedro", "Lopez", 345, 3, 160, 190, 28)
            };

            //act
            int promedioConsumoAgua = Agua.CalcularPromedioConsumoAgua(clientes);


            Assert.AreEqual(27, promedioConsumoAgua);


        }

        [TestMethod]
        public void CalcularConsumoExcesivoAguaTest()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                    new Cliente("Juan", "Perez", 123, 3, 150, 100, 20),
                    new Cliente("Maria", "Gomez", 134, 2, 200, 180, 35),
                    new Cliente("Pedro", "Lopez", 345, 4, 170, 190, 25),
                    new Cliente("Pedro", "Lopez", 345, 3, 160, 190, 28)
            };


            int consumo_excesivo_agua = Agua.CalcularConsumoExcesivoAgua(clientes);

            Assert.AreEqual(9, consumo_excesivo_agua);
        }

        [TestMethod]
        public void MostrarPorcentajesConsumoExcesivoAguaTest()

        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente("Juan", "Perez", 123, 3, 150, 100, 20),
                new Cliente("Maria", "Gomez", 134, 2, 200, 180, 35),
                new Cliente("Pedro", "Lopez", 345, 4, 170, 190, 25),
                new Cliente("Pedro", "Lopez", 345, 3, 160, 190, 28)
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
         
                Agua.MostrarPorcentajesConsumoExcesivoAguaPorEstrato(clientes);

               
                string expectedOutput = "El porcentaje de consumo excesivo de agua en el estrato";
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
            }

        }


        [TestMethod]
        public void EstratosConConsumoAguaMayorAlPromedioTest()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                        new Cliente("Juan", "Perez", 123, 3, 150, 100, 20),
                        new Cliente("Maria", "Gomez", 134, 2, 200, 180, 35),
                        new Cliente("Pedro", "Lopez", 345, 4, 170, 190, 25),
                        new Cliente("Pedro", "Lopez", 345, 3, 160, 190, 28)

            };

            List<int> estratosClientesMayor = Agua.EstratosConConsumoAguaMayorAlPromedio(clientes);


            CollectionAssert.Contains(estratosClientesMayor, 2 );
            CollectionAssert.Contains(estratosClientesMayor, 3);

        }

        [TestMethod]
        public void EstratoConMayorAhorroDeaguaTest()

        {
            //arrange
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente("Juan", "Perez", 123, 3, 150, 100, 20),
                new Cliente("Maria", "Gomez", 134, 2, 200, 180, 35),
                new Cliente("Pedro", "Lopez", 345, 4, 170, 190, 25),
                new Cliente("Pedro", "Lopez", 345, 3, 160, 190, 28)
            };

            //act
            int estratoMenorGastoAgua = Agua.EstratoConMayorAhorroDeAgua(clientes);


            Assert.AreEqual(4, estratoMenorGastoAgua);


        }
    }
}