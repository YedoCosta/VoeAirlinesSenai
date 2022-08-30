using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModel;

namespace VoeAirlinesSenai.Services;

public class ManutencaoService
{
private readonly VoeAirlinesContext _context;

public ManutencaoService(VoeAirlinesContext context)
{
    _context = context;
}

// Inserir Manutenção               
  public DetalheManutencaoViewModel AdicionarManutencao(AdicionarManutencaoViewModel dados)
    {
        
         dados.DescTipo = "Preventiva";
         if (dados.Tipo !=0)
         {
             dados.DescTipo = "Corretiva";
         }
         
        // Vamos criar o objeto manutencao
        var manutencao = new Manutencao(dados.DataHora, dados.Observacoes, dados.Tipo, dados.DescTipo, dados.AeronaveId);

        // EntityFramework Core - ORM
        _context.Add(manutencao);
        _context.SaveChanges();

            return new DetalheManutencaoViewModel
        (
            manutencao.Id,
            manutencao.DataHora,
            manutencao.Observacoes,
            manutencao.Tipo,
            manutencao.DescTipo,
            manutencao.AeronaveId
        );
    } 

    // Listar Manutenção

    public IEnumerable<ListarManutencaoViewModel> ListarManutencoes()
    {
         return _context.Manutencoes.Select(m => new ListarManutencaoViewModel(m.Id, m.DataHora, m.Observacoes, m.Tipo, m.DescTipo, m.AeronaveId));

    }

    // Listar Manutenção por ID

    public DetalheManutencaoViewModel? ListarManutencaoPeloId(int id)
    {
        var manutencao = _context.Manutencoes.Find(id);
        if (manutencao != null)
        {
            return new DetalheManutencaoViewModel
            (
                
                manutencao.Id,
                manutencao.DataHora,
                manutencao.Observacoes,
                manutencao.Tipo,
                manutencao.DescTipo,
                manutencao.AeronaveId
            );
        }
        return null;
    }

    //Listar Manutencao Aeronave 
    public IEnumerable<ListarManutencaoViewModel> ManutencaoDaAeronave(int AeronaveId)
    {
        return _context.Manutencoes.Where(m=>m.AeronaveId == AeronaveId).Select(m=> new ListarManutencaoViewModel(m.Id, m.DataHora, m.Observacoes, m.Tipo, m.DescTipo, m.AeronaveId));
    }

    // Atualizar Manutenção

    public DetalheManutencaoViewModel? AtulizarManutencao(AtualizarManutencaoViewModel dados)
    {
        var manutencao = _context.Manutencoes.Find(dados.Id);
        if (manutencao != null)
        {
                 dados.DescTipo = "Preventiva";
                 if (dados.Tipo != 0)
                 {
                     dados.DescTipo = "Corretiva";
                 }
                manutencao.Id = dados.Id;
                manutencao.DataHora = dados.DataHora;
                manutencao.Observacoes = dados.Observacoes;
                manutencao.Tipo = dados.Tipo;  
                manutencao.DescTipo = dados.DescTipo;
                manutencao.AeronaveId = dados.AeronaveId;

                _context.Update(manutencao);
                _context.SaveChanges();
        }
         return null;
    }

    // Deletar Manutençao

    public void ExcluirManutencao(int id)
    {
        var manutencao = _context.Manutencoes.Find(id);
        if (manutencao != null)
        {
            _context.Remove(manutencao);
            _context.SaveChanges();
            
        }

    }
 // Fim
}