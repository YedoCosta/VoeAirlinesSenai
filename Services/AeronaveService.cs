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
}