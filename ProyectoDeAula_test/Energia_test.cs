using ProyectoDeAula.Controllers;
using ProyectoDeAula.Models.Entidades;
using ProyectoDeAula_JulianaAlvarezVioletaAgudelo.Models.Entidades;
namespace ProyectoDeAula_test

{
    [TestClass]
    public class Energia_test
    {

        [TestMethod]

        public void CalcularPromedioConsumoEnergiaTest()

        {
            //arrange
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente("Juan", "Perez", 123, 3, 150, 100, 20),
                new Cliente("Maria", "Gomez", 134, 2, 200, 180, 35),
                new Cliente("Pedro", "Lopez", 345, 4, 170, 190, 25),
                new Cliente("Dayana", "Rojas", 345, 3, 160, 190, 28)
            };

            //act
            int promedioConsumoEnergia = Energia.CalcularPromedioConsumoEnergia(clientes);


            Assert.AreEqual(27, promedioConsumoEnergia);


        }

        [TestMethod]
        public void CalcularConsumoExcesivoEnergiaTest()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                    new Cliente("Juan", "Perez", 123, 3, 150, 100, 20),
                    new Cliente("Maria", "Gomez", 134, 2, 200, 180, 35),
                    new Cliente("Pedro", "Lopez", 345, 4, 170, 190, 25),
                    new Cliente("Dayana", "Rojas", 345, 3, 160, 190, 28)
            };


            int consumo_excesivo_energia = Energia.CalcularConsumoExcesivoEnergia(clientes);

            Assert.AreEqual(9, consumo_excesivo_energia);
        }

        [TestMethod]
        public void MostrarPorcentajesConsumoExcesivoEnergiaTest()

        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente("Juan", "Perez", 123, 3, 150, 100, 20),
                new Cliente("Maria", "Gomez", 134, 2, 200, 180, 35),
                new Cliente("Pedro", "Lopez", 345, 4, 170, 190, 25),
                new Cliente("Dayana", "Rojas", 345, 3, 160, 190, 28)
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Energia.MostrarPorcentajesConsumoExcesivoEnergiaPorEstrato(clientes);


                string expectedOutput = "El porcentaje de consumo excesivo de energia en el estrato";
                Assert.IsTrue(sw.ToString().Contains(expectedOutput));
            }

        }


        [TestMethod]
        public void EstratosConConsumoEnergiaMayorAlPromedioTest()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                        new Cliente("Juan", "Perez", 123, 3, 150, 100, 20),
                        new Cliente("Maria", "Gomez", 134, 2, 200, 180, 35),
                        new Cliente("Pedro", "Lopez", 345, 4, 170, 190, 25),
                        new Cliente("Dayana", "Rojas", 345, 3, 160, 190, 28)

            };

            List<int> estratosClientesMayor = Energia.EstratosConConsumoEnergiaMayorAlPromedio(clientes);


            CollectionAssert.Contains(estratosClientesMayor, 2);
            CollectionAssert.Contains(estratosClientesMayor, 3);

        }

        [TestMethod]
        public void EstratoConMayorAhorroDeenergiaTest()

        {
            //arrange
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente("Juan", "Perez", 123, 3, 150, 100, 20),
                new Cliente("Maria", "Gomez", 134, 2, 200, 180, 35),
                new Cliente("Pedro", "Lopez", 345, 4, 170, 190, 25),
                new Cliente("Dayana", "Rojas", 345, 3, 160, 190, 28)
            };

            //act
            int estratoMenorGastoEnergia = Energia.EstratoConMayorAhorroDeEnergia(clientes);


            Assert.AreEqual(4, estratoMenorGastoEnergia);


        }
    }
}
