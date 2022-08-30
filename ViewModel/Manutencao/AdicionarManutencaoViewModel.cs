using VoeAirlinesSenai.Entities.Enums;

namespace VoeAirlinesSenai.ViewModel;

public class AdicionarManutencaoViewModel
{
    public AdicionarManutencaoViewModel(DateTime dataHora, string? observacoes, TipoManutencao tipo, string descTipo, int aeronaveId)
    {
        DataHora = dataHora;
        Observacoes = observacoes;
        Tipo = tipo;
        DescTipo = descTipo;
        AeronaveId = aeronaveId;
    }

    public DateTime DataHora { get; set; }
    public string? Observacoes { get; set; }
    public TipoManutencao Tipo { get; set; }
    public string DescTipo { get; set; }
    public int AeronaveId { get; set; }
}
