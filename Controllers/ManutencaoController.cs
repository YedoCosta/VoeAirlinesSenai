using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModel;


// Anotations ou anotaçoes []
[Route("api/manutencao")]
// Controle pode trabalhar com AspNet MVC ou API ou Outros Recursos Web
// Neste caso usaremos ApiController
[ApiController]

public class ManutencaoController : ControllerBase
{
    private readonly ManutencaoService _manutencaoService;

    public ManutencaoController(ManutencaoService manutencaoService )
    {
        _manutencaoService = manutencaoService;
    }

//--------------------------------------------------------------------------------
    [HttpPost] // Inserir Manutenção

    public IActionResult AdicionarManutencao(AdicionarManutencaoViewModel dados)
    {
        var manutencao = _manutencaoService.AdicionarManutencao(dados);
        return Ok(manutencao);
    } 
//---------------------------------------------------------------------------------
    [HttpGet] // Lista Manutenção

    public IActionResult ListarManutencao()
    {
        return Ok(_manutencaoService.ListarManutencoes());
    }
//---------------------------------------------------------------------------------
    [HttpGet("{id}")] // Lista Manutenção por Id

    public IActionResult BuscaManutencaoPeloId(int id)
    {
        var manutencao = _manutencaoService.ListarManutencaoPeloId(id);
        if (manutencao != null)
        {
            return Ok(manutencao);
        }
        return NotFound();
    }
//---------------------------------------------------------------------------------
    [HttpGet("PelaNve/{aeronaveId}")] //Buscar Manutencao pelo Id da Aeronave

    public IActionResult ManutencaoDaAeronave(int aeronaveId)
    {
        var manutencaoAeronave = _manutencaoService.ManutencaoDaAeronave(aeronaveId);
        if (manutencaoAeronave != null)
        {
            return Ok(manutencaoAeronave);
        }
        return NotFound();
    }
//---------------------------------------------------------------------------------
    [HttpPut("{id}")] // Atualizar Manutenção

    public IActionResult AtualizarManutencao(int id, AtualizarManutencaoViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest("O Id Informado na URL é Diferente do id da Tabela");
        }
        var manutencao = _manutencaoService.AtulizarManutencao(dados);
        return Ok(manutencao);
    }
//---------------------------------------------------------------------------------
    [HttpDelete("{id}")]  //Deletar Manutenção
    public IActionResult ExcluirManutencao(int id)
    {
        _manutencaoService.ExcluirManutencao(id);
        return NoContent();
    }
//---------------------------------------------------------------------------------
// Fim
}
