using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModel;

namespace VoeAirlinesSenai.Services;

public class PilotoService
{
        private readonly VoeAirlinesContext _context;

    public PilotoService(VoeAirlinesContext context)
    {
        _context = context;
    }

    // Adicionar Piloto  *************************
    public DetalhePilotoViewModel AdicionarPiloto(AdicionarPilotoViewModel dados)
    {
        // Vamos criar o objeto 
        var piloto = new Piloto(dados.Nome, dados.Matricula);

        // EntityFramework Core - ORM
        _context.Add(piloto);
        _context.SaveChanges();

            return new DetalhePilotoViewModel
        (
            piloto.Id,
            piloto.Nome,
            piloto.Matricula
        );
    } 

    // Atualizar Piloto  *********************
    public DetalhePilotoViewModel? AtualizarPiloto(AtualizarPilotoViewModel dados)
    {
        var piloto = _context.Pilotos.Find(dados.Id);
        if(piloto!= null){
            piloto.Nome = dados.Nome;
            piloto.Matricula = dados.Matricula;

            _context.Update(piloto);
            _context.SaveChanges();
            return new DetalhePilotoViewModel(piloto.Id,piloto.Nome,piloto.Matricula);
        }
        return null;
    }

    // Listar Piloto  ******************************
      public IEnumerable<Piloto> ListaPiloto()
    {
        //return _context.Aeronaves.Select(a=>new ListaAeronaveViewModel(a.Id, a.Modelo, a.Codigo));
        return _context.Pilotos.ToList();
    }

   // Listar Piloto  pelo Id ******************************
    public DetalhePilotoViewModel? ListarPilotoPeloId(int id)
    {
        var piloto = _context.Pilotos.Find(id);
        if (piloto != null)
        {
            return new DetalhePilotoViewModel(
                piloto.Id,
                piloto.Nome,
                piloto.Matricula
            );
        }
        return null;
    }

    // Deleta Piloto  *********************
    public void ExcluirPiloto(int id)
    {
        var piloto = _context.Pilotos.Find(id);

            if (piloto != null)
            {
                _context.Pilotos.Remove(piloto);
                _context.SaveChanges();          
            } 
    }
// Fim
}