// Utilização dos namespaces
using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModel;

//Definição do namespaces
namespace VoeAirlinesSenai.Services;

// Classe de Serviço: trabalhar com funcionalidade do sistema
public class AeronaveService{
    
    // RF - Requisito Funcional
    // RF - Não Funcional
    // Neste caso usaremos requisitos funcionais

    // O sistema de cafastrar a aeronave
    // Neste pontp do código veremos na prática

    //propriedade para injeção de dependência
    private readonly VoeAirlinesContext _context;

    // Construtor
    // ter o mesmo nome da classe
    // Ele não tem retorno
    // Atribui valores no momento da instanciação

    public AeronaveService(VoeAirlinesContext context)
    {
        _context = context;
    }

    // criamos na View model várias classes
    // A estratégia é:
    // Ao adicionar a Aeronave no banco será gerado o Id
    // e assim retornaremos todos os dados a Aeronave incluindo o seu Id
    
    // Adicionar Aeronave  *************************
    public DetalheAeronaveViewModel AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {
        // Vamos criar o objeto aeronave
        var aeronave = new Aeronave(dados.Fabricante, dados.Modelo, dados.Codigo);

        // EntityFramework Core - ORM
        _context.Add(aeronave);
        _context.SaveChanges();

            return new DetalheAeronaveViewModel
        (
            aeronave.Id,
            aeronave.Fabricante,
            aeronave.Modelo,
            aeronave.Codigo
        );
    } 

    // Atualizar Aeronave  *********************
    public DetalheAeronaveViewModel AtualizarAeronave(AtualizarAeronaveViewModel dados)
    {
        var aeronave = new Aeronave(dados.Fabricante, dados.Modelo, dados.Codigo);
        aeronave.Id = dados.Id;

        _context.Update(aeronave);
        _context.SaveChanges();

        return new DetalheAeronaveViewModel
        (
            aeronave.Id,
            aeronave.Fabricante,
            aeronave.Modelo,
            aeronave.Codigo
        );

    }
    // Listar Aeronaves  ******************************

    //public IEnumerable<ListaAeronaveViewModel> ListaAeronaves()
      public IEnumerable<Aeronave> ListaAeronaves()
    {

        //return _context.Aeronaves.Select(a=>new ListaAeronaveViewModel(a.Id, a.Modelo, a.Codigo));
        return _context.Aeronaves.ToList();

    }
    /*  
    public DetalheAeronaveViewModel? ListarAeronavePeloId(int id)
    {
        var aeronave = _context.Aeronaves.Find(id);
        if (aeronave != null){
            return new DetalheAeronaveViewModel(
                aeronave.Id,
                aeronave.Fabricante,
                aeronave.Modelo,
                aeronave.Codigo
            );
        
        return null;
        }
    }

*/
    // Deleta Aeronave  *********************
    public DetalheAeronaveViewModel RemoverAeronave(int id)
    {
        var aeronaveDel = _context.Aeronaves.Find(id);

            if (aeronaveDel == null)
            {
                return new DetalheAeronaveViewModel(aeronaveDel.Id,aeronaveDel.Fabricante,aeronaveDel.Modelo,aeronaveDel.Codigo);
            }
            else
            {
                _context.Aeronaves.Remove(aeronaveDel);
                _context.SaveChanges();
                return new DetalheAeronaveViewModel(aeronaveDel.Id,aeronaveDel.Fabricante,aeronaveDel.Modelo,aeronaveDel.Codigo);
            } 
    }
    
    /*
      public DetalheAeronaveViewModel? AtualizarAeronave(AtualizarAeronaveViewModel dados){
    } */
}