using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModel;

namespace VoeAirlinesSenai.Services;

public class CancelamentoService
{
        private readonly VoeAirlinesContext _context;

    // Construtor
    // ter o mesmo nome da classe
    // Ele não tem retorno
    // Atribui valores no momento da instanciação

    public CancelamentoService(VoeAirlinesContext context)
    {
        _context = context;
    }

//---------------------------------------------------------------------
    // AdicionarCancelamento  *************************
    public DetalheCancelamentoViewModel AdicionarCancelamento(AdicionarCancelamentoViewModel dados)
    {
        // Vamos criar o objeto aeronave
        var cancelamento = new Cancelamento(dados.Motivo, dados.DataHoraNotificacao, dados.VooId);

        // EntityFramework Core - ORM
        _context.Add(cancelamento);
        _context.SaveChanges();

            return new DetalheCancelamentoViewModel
        (
            cancelamento.Id,
             cancelamento.Motivo,
            cancelamento.DataHoraNotificacao,
            cancelamento.VooId
        );
    } 

//---------------------------------------------------------------------
   // AtualizarCancelamento  *********************
    public DetalheCancelamentoViewModel? AtualizarCancelamento(AtualizarCancelamentoViewModel dados)
    {
        var cancelamento = _context.Cancelamentos.Find(dados.Id);
        if(cancelamento!= null)
        {
             cancelamento.Motivo = dados.Motivo;
            cancelamento.DataHoraNotificacao = dados.DataHoraNotificacao;
            cancelamento.VooId = dados.VooId;

            _context.Update(cancelamento);
            _context.SaveChanges();

            return new DetalheCancelamentoViewModel
            (
            cancelamento.Id,
             cancelamento.Motivo,
            cancelamento.DataHoraNotificacao,
            cancelamento.VooId
            );
        }
        return null;
    }
//---------------------------------------------------------------------
    // ListarCancelamento  ******************************
      public IEnumerable<Cancelamento> ListaCancelamento()
    {
        return _context.Cancelamentos.ToList();
    }
//---------------------------------------------------------------------
   // ListarCancelamentoPeloId ******************************
    public DetalheCancelamentoViewModel? ListarCancelamentoPeloId(int id)
    {
        var cancelamento = _context.Cancelamentos.Find(id);
        if (cancelamento != null)
        {
            return new DetalheCancelamentoViewModel
            (
            cancelamento.Id,
             cancelamento.Motivo,
            cancelamento.DataHoraNotificacao,
            cancelamento.VooId
            );

        }
        return null;
    }
//---------------------------------------------------------------------
    // ExccluirCancelamento  *********************
    public void ExcluirCancelamento(int id)

    {
        var cancelamento = _context.Cancelamentos.Find(id);

            if (cancelamento != null)
            {

                _context.Cancelamentos.Remove(cancelamento);
                _context.SaveChanges();
                
            } 
    }
//---------------------------------------------------------------------
// Fim
}