using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModel;

// A controller é uma classe que permite trabalhar com HTTP

// Uma Classe
// Herança no C# - ":"
// URL - Endereço - Caminho
// Rota é um trecho - sub caminho

// Anotations ou anotaçoes []
[Route("api/aeronaves")]
// Controle pode trabalhar com AspNet MVC ou API ou Outros Recursos Web
// Neste caso usaremos ApiController
[ApiController]

public class AeronaveController: ControllerBase{
    

    private readonly AeronaveService _aeronaveService;

    public AeronaveController(AeronaveService aeronaveService)
    {
        _aeronaveService = aeronaveService;
    }
    [HttpPost]
    public IActionResult AdicionarAeronave(AdicionarAeronaveViewModel dados){
       
       var aeronave = _aeronaveService.AdicionarAeronave(dados);
       return Ok(aeronave);

    }
}