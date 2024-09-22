using Microsoft.EntityFrameworkCore;
using System;

namespace DashboardFinanceiro.Models
{
    public class NotaFiscal
    {
        public int Id { get; set; }
        public string NomePagador { get; set; } = string.Empty;
        public string NumeroNota { get; set; } = string.Empty;
        public DateTime DataEmissao { get; set; }
        public DateTime? DataCobranca { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public string DocumentoNota { get; set; } = string.Empty;
        public string DocumentoBoleto { get; set; } = string.Empty;
        public string StatusNota { get; set; } = string.Empty;
    }

    public class FinanceiroContext : DbContext
    {
        public DbSet<NotaFiscal> NotasFiscais { get; set; }

        public FinanceiroContext(DbContextOptions<FinanceiroContext> options)
            : base(options)
        { }
    }
}
