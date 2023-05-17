using RestauranteWeb.Domain.Entities;
using System;

namespace RestauranteWeb.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> GetByIdAsync(int id);
        Task<ICollection<Cliente>> GetClientesAsync();
        Task<Cliente> CreateAsync(Cliente cliente);
        Task EditAsync(Cliente cliente);
        Task DeleteAsync(Cliente cliente);
    }
}
