namespace AbogadosApp.ViewModels
{
    public class AsuntoClienteViewModel
    {
        public IEnumerable<AbogadosApp.Models.Asunto> Asuntos { get; set; }
        public AbogadosApp.Models.Cliente Cliente { get; set; }
    }
}
