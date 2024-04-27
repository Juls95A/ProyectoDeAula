using ProyectoDeAula.Models.Entidades;
namespace ProyectoDeAula_test

{
    [TestClass]
    public class Cliente_test
    {
        [TestMethod]

        public void ClienteTest()
        {

            //arrange
            string nombre = "paco";
            string apellido = "pilates";
            int cedula = 123;
            int estrato = 3;
            int meta_ahorro = 150;
            int consumo_energia = 130;
            int consumo_agua = 20;


            //act
            Cliente cliente = new Cliente(nombre, apellido, cedula, estrato, meta_ahorro, consumo_energia, consumo_agua);

            //assert
            Assert.AreEqual(nombre, cliente.nombre);
            Assert.AreEqual(apellido, cliente.apellido);
            Assert.AreEqual(estrato, cliente.estrato);
            Assert.AreEqual(meta_ahorro, cliente.meta_ahorro);
            Assert.AreEqual(consumo_energia, cliente.consumo_energia);
            Assert.AreEqual(consumo_agua, cliente.consumo_agua);

        }
    }
}