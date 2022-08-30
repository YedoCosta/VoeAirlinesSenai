using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModel;

// A controller é uma classe que permite trabalhar com HTTP

// Anotations ou anotaçoes []
[Route("api/pilotos")]
// Controle pode trabalhar com AspNet MVC ou API ou Outros Recursos Web
// Neste caso usaremos ApiController
[ApiController]

public class PilotoController : ControllerBase
{
    private readonly PilotoService _pilotoService;

    public PilotoController(PilotoService pilotoService)
    {
        _pilotoService = pilotoService;
    }
//---------------------------------------------------------------------------------
    [HttpPost] // - > INSERIR ! INSERT INTO
    public IActionResult AdicionarPiloto(AdicionarPilotoViewModel dados)
    {

        var piloto = _pilotoService.AdicionarPiloto(dados);
        return Ok(piloto);

    }
//---------------------------------------------------------------------------------
    [HttpGet] // - >  SELECT * FROM
    public IActionResult ListaPiloto()
    {

        var piloto = _pilotoService.ListaPiloto();
        return Ok(piloto);
    }
    //---------------------------------------------------------------------------------
   [HttpGet("{id}")] // - >  SELECT * FROM com WHERE "Id" . 
    public IActionResult ListarPilotoPeloId(int id)
    {
        var piloto = _pilotoService.ListarPilotoPeloId(id);
        if (piloto != null)
        {
            return Ok(piloto);
        }
        return NotFound();
    }
    //---------------------------------------------------------------------------------
    [HttpPut("{id}")] // - Put - UPDATE
    public IActionResult AtualizarPiloto(int id, AtualizarPilotoViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest(" o Id Informado na URL é Diferente do id Informado no Corpo da Requisição");
        }
        var piloto = _pilotoService.AtualizarPiloto(dados);
        return Ok(piloto);
    }
    //---------------------------------------------------------------------------------
     [HttpDelete("{id}")] // - Delete 
    public IActionResult ExcluirPiloto(int id)
    {
        _pilotoService.ExcluirPiloto(id);
        return NoContent();
    }
    //---------------------------------------------------------------------------------


}
