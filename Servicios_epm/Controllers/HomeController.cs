using System.Diagnostics;
using System.Xml.Linq;
using ProyectoDeAula.Models;
using ProyectoDeAula.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using ProyectoDeAula_JulianaAlvarezVioletaAgudelo.Models.Entidades;

namespace ProyectoDeAula.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Datos()
        {
            ViewData["Title"] = "Informacion";
            return View();
        }
        public IActionResult Factura()
        {
            return View();
        }

        public IActionResult RegistrarCliente()
        {
            return PartialView("RegistrarCliente");
        }

        public IActionResult ActualizarInformacion()
        {
            return View();

        }

        public IActionResult EliminarCliente()
        {
            return View();
        }

        public IActionResult TablaClientes()
        {

            string textoClientes = GestionClientes.MostrarClientes(clientes);

            ViewData["TextoClientes"] = textoClientes;

            return View();
        }
        public IActionResult ConsumoGas()
        {

            return View();
        }

        public IActionResult ConsumoAgua()
        {
            return PartialView("ConsumoAgua");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ConsumoEnergia()
        {
            return PartialView("ConsumoEnergia");
        }



        [HttpPost]
        public IActionResult Crear(Cliente cliente)
        {

            int sumaConsumoAhorro = cliente.consumo_agua + cliente.meta_ahorro;

            ViewData["SumaConsumoAhorro"] = sumaConsumoAhorro;
            ViewData["SumaConsumoAhorro"] = sumaConsumoAhorro;
            ViewData["Clientes"] = cliente;


            return View("Registro", cliente);

        }

        private static List<Cliente> clientes = new List<Cliente>();


        [HttpPost]
        public IActionResult Registrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                GestionClientes.AgregarClientes(clientes, cliente);
                return View("RegistrarCliente", new Cliente());

            }
            else
            {
                return View("RegistrarCliente", cliente);
            }
        }

        public IActionResult MostrarClientes()
        {
            return View("MostrarClientes", clientes);
        }
        public IActionResult TextoClientes()
        {
            var textoClientes = GestionClientes.MostrarClientes(clientes);
            return Content(textoClientes);
        }


        [HttpPost]
        public ActionResult EliminarCliente(int id)
        {
            Cliente? clienteEliminar = clientes.Find(c => c.cedula == id);
            if (clienteEliminar != null)
            {
                clientes.Remove(clienteEliminar);
                ViewBag.Notificacion = "Cliente eliminado correctamente.";
            }
            else
            {
                ViewBag.Notificacion = "Cliente no encontrado.";
            }

            return View("EliminarCliente");
        }

        [HttpPost]
        public IActionResult ActualizarCliente(int id)
        {
            Cliente? cliente = clientes.FirstOrDefault(c => c.Cedula == id);
            if (cliente != null)
            {
                ViewBag.Cliente = cliente;
            }
            else
            {
                ViewBag.NoEncontrado = "No se encontro informaciòn";
            }
            return View("ActualizarInformacion");
        }

        [HttpGet]
        public IActionResult factura()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalcularPago(int cedula)
        {

            Cliente? cliente = clientes.FirstOrDefault(c => c.Cedula == cedula);

            if (cliente != null)
            {

                int valorAPagar = CalculoPagoCliente.CalcularValorAPagar(cliente, clientes);
                ViewBag.ValorAPagar = valorAPagar;
            }
            else
            {

                ViewBag.Error = "No se encontró un cliente con esa cédula.";
            }

            return View("Factura");
        }
        [HttpPost]
        public IActionResult aguaconsumo()
        {
            int promedio_agua = Agua.CalcularPromedioConsumoAgua(clientes);

            List<int> clientes_mayor = Agua.EstratosConConsumoAguaMayorAlPromedio(clientes);

            int estrato_mas_ahorro = Agua.EstratoConMayorAhorroDeAgua(clientes);

            ViewData["promedioagua"] = promedio_agua;
            ViewData["estratomasahorro"] = estrato_mas_ahorro;

            string estratosString = string.Join(", ", clientes_mayor);

            ViewData["consumomayor"] = estratosString;

            return View("ConsumoAgua", clientes);
        }

        [HttpPost]

        public IActionResult energiaconsumo()
        {
            int promedioEnergia = Energia.CalcularPromedioConsumoEnergia(clientes);

            List<int> clientesMayor = Energia.MostrarClientesConConsumoEnergiaMayorAlPromedio(clientes);

            int estratoMasAhorro = Energia.EstratoConMayorAhorroDeEnergia(clientes);

            ViewData["promedioEnergia"] = promedioEnergia;
            ViewData["estratoMasAhorro"] = estratoMasAhorro;

            string estratosString = string.Join(", ", clientesMayor);

            ViewData["consumoMayor"] = estratosString;

            return View("ConsumoEnergia", clientes);
        }


        public IActionResult gasconsumo()
        {

            int clientesMayor = Gas.ClienteConConsumoMayorGas(clientes);



            ViewData["consumoMayor"] = clientesMayor;

            return View("ConsumoGas", clientes);
        }



        [HttpPost]
        public ActionResult CalcularPagos()
        {

            return View("suma pagos", clientes);
        }
        public IActionResult Textopago()
        {
            int textopagos = GestionClientes.TotalPagadoPorEnergiaAgua(clientes);
            return Content(textopagos.ToString());
        }
    }

}
