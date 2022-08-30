using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModel;

namespace VoeAirlinesSenai.Services;

public class VooService
{
    private readonly VoeAirlinesContext _context;

    public VooService(VoeAirlinesContext context)
    {
        _context = context;
    }
 
        // AdicionarVoo  *************************
        public DetalheVooViewModel AdicionarVoo(AdicionarVooViewModel dados)
        {
            // Vamos criar o objeto voo
            var voo = new Voo
            (
            dados.Origem, 
            dados.Destino, 
            dados.DataHoraPartida, 
            dados.DataHoraChegada, 
            dados.AeronaveId, 
            dados.PilotoId 
            );

            // EntityFramework Core - ORM
            _context.Add(voo);
            _context.SaveChanges();

                return new DetalheVooViewModel
            (
                voo.Id,
                voo.Origem,
                voo.Destino,
                voo.DataHoraPartida,
                voo.DataHoraChegada,
                voo.AeronaveId,
                voo.PilotoId
            );
        } 


    // AtualizarVoo  *********************
    public DetalheVooViewModel? AtualizarVoo(AtualizarVooViewModel dados)
    {
        var voo = _context.Voos.Find(dados.Id);
        if (voo != null)
        {
            voo.Id = dados.Id;
            voo.Origem = dados.Origem;
            voo.Destino = dados.Destino;
            voo.DataHoraPartida = dados.DataHoraPartida;
            voo.DataHoraChegada = dados.DataHoraChegada;
            voo.AeronaveId = dados.AeronaveId;
            voo.PilotoId = dados.PilotoId;

            _context.Update(voo);
            _context.SaveChanges();

            return new DetalheVooViewModel
            (
            voo.Id,
            voo.Origem,
            voo.Destino,
            voo.DataHoraPartida,
            voo.DataHoraChegada,
            voo.AeronaveId,
            voo.PilotoId
            );
        }
        return null;
    }

    
    // ListarVoo  ******************************
      public IEnumerable<Voo> ListaVoo()
    {
        return _context.Voos.ToList();
    }

   // ListarVooPeloId  ******************************
    public DetalheVooViewModel? ListarVooPeloId(int id)
    {
        var voo = _context.Voos.Find(id);
        if (voo != null)
        {
            return new DetalheVooViewModel
            (
            voo.Id,
            voo.Origem,
            voo.Destino,
            voo.DataHoraPartida,
            voo.DataHoraChegada,
            voo.AeronaveId,
            voo.PilotoId
            );
        }
        return null;
    }

    // ExcluiVoo  *********************
    public void ExcluirVoo(int id)
    {
        var voo = _context.Voos.Find(id);

            if (voo != null)
            {
                _context.Voos.Remove(voo);
                _context.SaveChanges();          
            } 
    }
    // Fim
}