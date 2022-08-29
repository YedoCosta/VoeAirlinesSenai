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

public class AeronaveController : ControllerBase
{
    private readonly AeronaveService _aeronaveService;

    public AeronaveController(AeronaveService aeronaveService)
    {
        _aeronaveService = aeronaveService;
    }
    [HttpPost] // - > INSERIR ! INSERT INTO
    public IActionResult AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {

        var aeronave = _aeronaveService.AdicionarAeronave(dados);
        return Ok(aeronave);

    }

    [HttpGet] // - >  SELECT * FROM
    public IActionResult ListaAeronaves()
    {

        var aeronave = _aeronaveService.ListaAeronaves();
        return Ok(aeronave);

    }

    [HttpGet("{id}")] // - >  SELECT * FROM com WHERE "Id" . 
    public IActionResult ListarAeronavePeloId(int id)
    {
        var aeronave = _aeronaveService.ListarAeronavePeloId(id);
        if (aeronave != null)
        {
            return Ok(aeronave);
        }
        return NotFound();
    }

    [HttpPut("{id}")] // - Put - UPDATE
    public IActionResult AtualizarAeronave(int id, AtualizarAeronaveViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest(" o Id Informado na URL é Diferente do id Informado no Corpo da Requisição");
        }
        var aeronave = _aeronaveService.AtualizarAeronave(dados);
        return Ok(aeronave);
    }

     [HttpDelete("{id}")] // - Delete 
    public IActionResult ExcluirAeronave(int id)
    {
        _aeronaveService.ExcluirAeronave(id);
        return NoContent();
    }

}