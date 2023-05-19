using System;
using System.Diagnostics.Contracts;

namespace RestauranteWeb.Application.DTOs
{
    public class PratoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Preparo { get; set; }
        public decimal Valor { get; set; }
        public bool Status { get; set; }
        public string Descricao { get; set; }

    }
}
