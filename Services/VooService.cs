using System;
using System.Text;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.EntityFrameworkCore;
using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModel;


namespace VoeAirlinesSenai.Services;

public class VooService
{
    private readonly VoeAirlinesContext _context;
    private readonly IConverter _converter;

    public VooService(VoeAirlinesContext context, IConverter converter)
    {
        _context = context;
        _converter = converter;
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

    // GerarFichaDoVoo  *********************
     public byte[]? GerarFichaDoVoo(int id)
    {
        var voo = _context.Voos.Include(v => v.Aeronave)
                               .Include(v => v.Piloto)
                               .Include(v => v.Cancelamento)
                               .FirstOrDefault(v => v.Id == id);

        if (voo != null)
        {
            var builder = new StringBuilder();

            builder.Append($"<h1 style='text-align: center'>Ficha do Voo { voo.Id.ToString().PadLeft(10, '0') }</h1>")
                   .Append($"<hr>")
                   .Append($"<p><b>ORIGEM:</b> { voo.Origem } (sa??da em { voo.DataHoraPartida:dd/MM/yyyy} ??s { voo.DataHoraPartida:hh:mm})</p>")
                   .Append($"<p><b>DESTINO:</b> { voo.Destino} (chegada em { voo.DataHoraChegada:dd/MM/yyyy} ??s { voo.DataHoraChegada:hh:mm})</p>")
                   .Append($"<hr>")
                   .Append($"<p><b>AERONAVE:</b> { voo.Aeronave!.Codigo } ({ voo.Aeronave.Fabricante } { voo.Aeronave.Modelo })</p>")
                   .Append($"<hr>")
                   .Append($"<p><b>PILOTO:</b> { voo.Piloto!.Nome } ({ voo.Piloto.Matricula})</p>")
                   .Append($"<hr>");
            if (voo.Cancelamento != null)
            {
                builder.Append($"<p style='color: red'><b>VOO CANCELADO:</b> { voo.Cancelamento.Motivo }</p>");
            }

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = builder.ToString(),
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            return _converter.Convert(doc);
        }

        return null;
    }
    // Fim
}