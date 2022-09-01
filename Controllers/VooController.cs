using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModel;

// A controller é uma classe que permite trabalhar com HTTP


// Anotations ou anotaçoes []
[Route("api/voo")]
// Controle pode trabalhar com AspNet MVC ou API ou Outros Recursos Web
// Neste caso usaremos ApiController
[ApiController]

public class VooController : ControllerBase
{
    private readonly VooService _vooService;

    public VooController(VooService vooService)
    {
        _vooService = vooService;
    }
//---------------------------------------------------------------------------------
    [HttpPost] // - > INSERIR ! INSERT INTO
    public IActionResult AdicionarVoo(AdicionarVooViewModel dados)
    {

        var voo = _vooService.AdicionarVoo(dados);
        return Ok(voo);

    }
//---------------------------------------------------------------------------------
    [HttpGet] // - >  SELECT * FROM
    public IActionResult ListaVoo()
    {

        var voo = _vooService.ListaVoo();
        return Ok(voo);
    }
    //---------------------------------------------------------------------------------
   [HttpGet("{id}")] // - >  SELECT * FROM com WHERE "Id" . 
    public IActionResult ListarVooPeloId(int id)
    {
        var voo = _vooService.ListarVooPeloId(id);
        if (voo != null)
        {
            return Ok(voo);
        }
        return NotFound();
    }
    //---------------------------------------------------------------------------------
    [HttpPut("{id}")] // - Put - UPDATE
    public IActionResult AtualizarVoo(int id, AtualizarVooViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest(" o Id Informado na URL é Diferente do id Informado no Corpo da Requisição");
        }
        var voo = _vooService.AtualizarVoo(dados);
        return Ok(voo);
    }
    //---------------------------------------------------------------------------------
     [HttpDelete("{id}")] // - Delete 
    public IActionResult ExcluirV00(int id)
    {
        _vooService.ExcluirVoo(id);
        return NoContent();
    }
    //---------------------------------------------------------------------------------
    [HttpGet("{id}/ficha")] // - Emitir Ficha do Voo
    public IActionResult GerarFichaDoVoo(int id)
    {
        var conteudo = _vooService.GerarFichaDoVoo(id);

        if (conteudo != null)
            return File(conteudo, "application/pdf");

        return NotFound();
    }
// Fim
}