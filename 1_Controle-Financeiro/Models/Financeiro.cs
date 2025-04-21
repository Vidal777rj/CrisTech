using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace _1_Controle_Financeiro.Models
{
    public class Financeiro
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime DataDaOperacao { get; set; }

        public string? CategoriaId { get; set; }

        [ValidateNever]
        public Categoria? Categoria { get; set; }

        public string? TransacaoId { get; set; }

        [ValidateNever]
        public Transacao? Transacao { get; set; }
    }
}