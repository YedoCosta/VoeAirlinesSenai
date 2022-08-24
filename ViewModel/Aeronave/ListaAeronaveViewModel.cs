namespace VoeAirlinesSenai.ViewModel;

public class ListaAeronaveViewModel
{
    public ListaAeronaveViewModel(int id, string codigo, string modelo)
    {
        Id = id;
        Modelo = modelo;
        Codigo = codigo;
    }

    public int Id { get; set; }
    public string Modelo { get; set; }
    public string Codigo { get; set; }
}