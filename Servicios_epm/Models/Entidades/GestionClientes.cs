
using System.Text;
using ProyectoDeAula_JulianaAlvarezVioletaAgudelo.Models.Entidades;


namespace ProyectoDeAula.Models.Entidades
{
    public class GestionClientes
    {
        public static void AgregarClientes(List<Cliente> clientes, Cliente cliente)
        {
            clientes.Add(cliente);
        }


        public static string MostrarClientes(List<Cliente> clientes)
        {
            StringBuilder texto = new StringBuilder();

            texto.AppendLine(" ");

            foreach (Cliente cliente in clientes)
            {
                texto.AppendLine($" Nombre: {cliente.nombre}, Apellido: {cliente.apellido}, Cédula: {cliente.cedula}, Estrato: {cliente.estrato}, Meta de ahorro: {cliente.meta_ahorro}, Consumo de energía: {cliente.consumo_energia}, Consumo de agua: {cliente.consumo_agua},  Consumo de gas: {cliente.consumo_gas}");
            }

            return texto.ToString();
        }

        static void EliminarCliente(List<Cliente> clientes)
        {
            Console.WriteLine("Ingrese la cédula del cliente a eliminar:");
            int cedulaCliente = Convert.ToInt32(Console.ReadLine());
            Cliente? clienteEliminar = clientes.Find(c => c.cedula == cedulaCliente);
            if (clienteEliminar != null)
            {
                clientes.Remove(clienteEliminar);
                Console.WriteLine("Cliente eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }


        static void ActualizarCliente(List<Cliente> clientes)

        {
            Console.WriteLine("Ingrese la cédula del cliente a actualizar:");
            int cedulaCliente = Convert.ToInt32(Console.ReadLine());
            Cliente? clienteActualizar = clientes.Find(c => c.cedula == cedulaCliente);
            if (clienteActualizar != null)
            {
                Console.WriteLine("Ingrese el nuevo nombre del cliente:");
                string nuevonombre = Console.ReadLine();
                Console.WriteLine("Ingrese el nuevo apellido del cliente:");
                string nuevoapellido = Console.ReadLine();
                Console.WriteLine("Ingrese la nueva cédula del cliente:");
                int nuevaCedula = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo periodo del cliente:");
                int nuevoperiodo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo estrato del cliente:");
                int nuevoEstrato = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese la nueva meta de ahorro de energía:");
                int nuevaMetaAhorro = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo consumo actual de energía:");
                int nuevoConsumoEnergia = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo consumo actual de agua:");
                int nuevoConsumoAgua = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo consumo actual de gas:");
                int nuevoConsumoDeGas = Convert.ToInt32(Console.ReadLine());
                clienteActualizar.ActualizarCliente(nuevonombre, nuevoapellido, nuevoperiodo, nuevaCedula, nuevoEstrato, nuevaMetaAhorro, nuevoConsumoEnergia, nuevoConsumoAgua, nuevoConsumoDeGas);
                Console.WriteLine("Cliente actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }


        }
        public static int TotalPagadoPorEnergiaAgua(List<Cliente> clientes)
        {
            int valor_total = 0;
            int promedio_consumo_agua = Agua.CalcularPromedioConsumoAgua(clientes);
            foreach (Cliente cliente in clientes)
            {
                valor_total += CalculoPagoCliente.CalcularValorAPagar(cliente, clientes);
            }
            return valor_total;
        }
    }
}

