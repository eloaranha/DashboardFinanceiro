//NotasFiscaisController.cs
using Microsoft.AspNetCore.Mvc;
using DashboardFinanceiro.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class NotasFiscaisController : ControllerBase
{
    private readonly FinanceiroContext _context;

    public NotasFiscaisController(FinanceiroContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotaFiscal>>> GetNotasFiscais()
    {
        return await _context.NotasFiscais.ToListAsync();
    }

    [HttpGet("dashboard")]
    public ActionResult GetDashboardData()
    {
        var totalEmitidas = _context.NotasFiscais.Sum(n => n.Valor);
        var totalInadimplentes = _context.NotasFiscais
                                .Where(n => n.StatusNota == "Pagamento em atraso")
                                .Sum(n => n.Valor);
        var totalPagas = _context.NotasFiscais
                                .Where(n => n.StatusNota == "Pagamento realizado")
                                .Sum(n => n.Valor);

        return Ok(new
        {
            totalEmitidas,
            totalInadimplentes,
            totalPagas
        });
    }

    //criar metodo para adicionar uma nova nota fiscal
    [HttpPost] 
    public async Task<ActionResult<NotaFiscal>> PostNotaFiscal(NotaFiscal notaFiscal)
    {
        _context.NotasFiscais.Add(notaFiscal);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetNotasFiscais", new { id = notaFiscal.Id }, notaFiscal);
    }
    
[HttpGet("filtrar")]
public async Task<ActionResult<IEnumerable<NotaFiscal>>> GetFilteredNotasFiscais(
    [FromQuery] int? mesEmissao,
    [FromQuery] int? mesCobranca,
    [FromQuery] int? mesPagamento,
    [FromQuery] string statusNota)
{
    var query = _context.NotasFiscais.AsQueryable();

    if (mesEmissao.HasValue)    {
        query = query.Where(n => n.DataEmissao.Month == mesEmissao.Value);
    }

    if (mesCobranca.HasValue)    {
        query = query.Where(n => n.DataCobranca.Value.Month == mesCobranca.Value);
    }

    if (mesPagamento.HasValue)    {
        query = query.Where(n => n.DataPagamento.Value.Month == mesPagamento.Value);
    }

    if (!string.IsNullOrEmpty(statusNota))    {
        query = query.Where(n => n.StatusNota == statusNota);
    }

    return await query.ToListAsync();
}
[HttpGet("evolucao")]
public ActionResult GetEvolucaoFinanceira()
{
    var inadimplenciaMes = _context.NotasFiscais
        .Where(n => n.StatusNota == "Pagamento em atraso")
        .GroupBy(n => n.DataEmissao.Month)
        .Select(g => new { Mes = g.Key, TotalInadimplencia = g.Sum(n => n.Valor) })
        .ToList();

    var receitaMes = _context.NotasFiscais
        .Where(n => n.StatusNota == "Pagamento realizado")
        .GroupBy(n => n.DataEmissao.Month)
        .Select(g => new { Mes = g.Key, TotalReceita = g.Sum(n => n.Valor) })
        .ToList();


    return Ok(new { inadimplenciaMes, receitaMes });
}

[HttpGet("notas")]
public ActionResult NotasFiscaisPage()
{
    return Ok("NotasFiscaisPage");
}
}
