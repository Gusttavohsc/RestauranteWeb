using RestauranteWeb.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteWeb.Application.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<ResultService<PedidoDTO>> CreateAsync(PedidoDTO pedidoDTO);
        Task<ResultService<PedidosDetailDTO>> GetByIdAsync(int id);
        Task<ResultService<ICollection<PedidosDetailDTO>>> GetAsync();
        Task<ResultService<PedidoDTO>> UpdateAsync(PedidoDTO pedidoDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
