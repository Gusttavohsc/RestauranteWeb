using System;

namespace RestauranteWeb.Application.DTOs
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdPrato { get; set; }
        public int Mesa { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
    }
}
