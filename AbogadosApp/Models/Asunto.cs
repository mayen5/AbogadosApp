using System.Diagnostics;

namespace AbogadosApp.Models
{
    public class Asunto
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; }

    }
}
