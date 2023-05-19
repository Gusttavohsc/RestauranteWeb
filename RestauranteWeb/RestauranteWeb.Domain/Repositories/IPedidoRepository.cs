using RestauranteWeb.Domain.Entities;
using System;

namespace RestauranteWeb.Domain.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> GetByIdAsync(int id);
        Task<ICollection<Pedido>> GetAllSync();
        Task<Pedido> CreateAsync(Pedido pedido);
        Task EditAsync(Pedido pedido);
        Task DeleteAsync(Pedido pedido);
        Task<ICollection<Pedido>> GetByClienteIdAsync(int idCliente);
        Task<ICollection<Pedido>> GetByPratoIdAsync(int idPrato);

    }
}
