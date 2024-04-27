namespace ProyectoDeAula.Models.Entidades
    //el anterior era clientess
{
    public class Cliente
    {
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int cedula { get; set;  }
        public int estrato { get; set; }
        public int meta_ahorro { get; set; }
        public int consumo_energia { get; set; }
        public int consumo_agua { get; set; }


        public Cliente(string nombre, string apellido, int cedula, int estrato, int meta_ahorro, int consumo_energia, int consumo_agua)
        {
            this.nombre=nombre;
            this.Apellido = apellido;
            this.Cedula = cedula;
            this.Estrato = estrato;
            this.Meta_ahorro = meta_ahorro;
            this.Consumo_energia = consumo_energia;
            this.Consumo_agua = consumo_agua;
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Cedula { get => cedula; set => cedula = value; }
        public int Estrato { get => estrato; set => estrato = value; }
        public int Meta_ahorro { get => meta_ahorro; set => meta_ahorro = value; }
        public int Consumo_energia { get => consumo_energia; set => consumo_energia = value; }
        public int Consumo_agua { get => consumo_agua; set => consumo_agua = value; }


        public Cliente()
        {
        }

        public void ActualizarCliente(string nuevonombre, string nuevoapellido, int nuevaCedula, int nuevoEstrato, int nuevaMetaAhorro, int nuevoConsumoEnergia, int nuevoConsumoDeAgua)
        {
                this.nombre = nuevonombre;
                this.Apellido = nuevoapellido;
                this.cedula = nuevaCedula;
                this.estrato = nuevoEstrato;
                this.meta_ahorro = nuevaMetaAhorro;
                this.consumo_energia = nuevoConsumoEnergia;
                this.consumo_agua = nuevoConsumoDeAgua;
        }
    }
}



