using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModel;

// A controller é uma classe que permite trabalhar com HTTP

// Uma Classe
// Herança no C# - ":"
// URL - Endereço - Caminho
// Rota é um trecho - sub caminho

// Anotations ou anotaçoes []
[Route("api/cancelamento")]
// Controle pode trabalhar com AspNet MVC ou API ou Outros Recursos Web
// Neste caso usaremos ApiController
[ApiController]

public class CancelamentoController : ControllerBase
{
    private readonly CancelamentoService _cancelamentoService;

    public CancelamentoController(CancelamentoService cancelamentoService)
    {
        _cancelamentoService = cancelamentoService;
    }

//---------------------------------------------------------------------------------
    [HttpPost] // - > INSERIR ! INSERT INTO
    public IActionResult AdicionarCancelamento(AdicionarCancelamentoViewModel dados)
    {
        var cancelamento = _cancelamentoService.AdicionarCancelamento(dados);
        return Ok(cancelamento);

    }

//---------------------------------------------------------------------------------
    [HttpGet] // - >  SELECT * FROM
    public IActionResult ListaCancelamento()
    {

        var cancelamento = _cancelamentoService.ListaCancelamento();
        return Ok(cancelamento);

    }

    //---------------------------------------------------------------------------------
    [HttpGet("{id}")] // - >  SELECT * FROM com WHERE "Id" . 
    public IActionResult ListarCancelamentoPeloId(int id)
    {
        var cancelamento = _cancelamentoService.ListarCancelamentoPeloId(id);
        if (cancelamento != null)
        {
            return Ok(cancelamento);
        }
        return NotFound();
    }
    
//---------------------------------------------------------------------------------
    [HttpPut("{id}")] // - Put - UPDATE
    public IActionResult AtualizarCancelamento(int id, AtualizarCancelamentoViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest(" o Id Informado na URL é Diferente do id Informado no Corpo da Requisição");
        }
        var cancelamento = _cancelamentoService.AtualizarCancelamento(dados);
        return Ok(cancelamento);
    }

//---------------------------------------------------------------------------------
     [HttpDelete("{id}")] // - Delete 
    public IActionResult ExcluirCancelamento(int id)
    {
        _cancelamentoService.ExcluirCancelamento(id);
        return NoContent();
    }
//---------------------------------------------------------------------------------
// Fim
}