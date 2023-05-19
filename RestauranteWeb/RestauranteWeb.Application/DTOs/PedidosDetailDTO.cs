using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteWeb.Application.DTOs
{
    public class PedidosDetailDTO
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Prato { get; set; }
        public int? Mesa { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
    }
}
