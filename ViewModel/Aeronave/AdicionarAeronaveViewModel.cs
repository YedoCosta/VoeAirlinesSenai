namespace VoeAirlinesSenai.ViewModel;

public class AdicionarAeronaveViewModel
{
    
        public AdicionarAeronaveViewModel(string fabricante, string codigo, string modelo)
    {
        Fabricante = fabricante;
        Modelo = modelo;
        Codigo = codigo;
    }

    public string Fabricante { get; set; }
    public string Modelo { get; set; }
    public string Codigo { get; set; }
}
