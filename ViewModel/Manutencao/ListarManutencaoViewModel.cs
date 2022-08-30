using VoeAirlinesSenai.Entities.Enums;

namespace VoeAirlinesSenai.ViewModel;

public class ListarManutencaoViewModel
{
    public ListarManutencaoViewModel(int id, DateTime dataHora, string? observacoes, TipoManutencao tipo, string descTipo, int aeronaveId)
    {
        Id = id;
        DataHora = dataHora;
        Observacoes = observacoes;
        Tipo = tipo;
        DescTipo = descTipo;
        AeronaveId = aeronaveId;
    }

    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public string? Observacoes { get; set; }
    public TipoManutencao Tipo { get; set; }
    public string DescTipo { get; set; }
    public int AeronaveId { get; set; }
}