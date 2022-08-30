namespace VoeAirlinesSenai.ViewModel;

public class ListaPilotoVewModel
{
    public ListaPilotoVewModel(int id, string nome, string matricula)
    {
        Id = id;
        Nome = nome;
        Matricula = matricula;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Matricula { get; set; }
}