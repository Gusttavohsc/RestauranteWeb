using RestauranteWeb.Domain.Entities;
using System;

namespace RestauranteWeb.Domain.Repositories
{
    public interface IPratoRepository
    {
        Task<Prato> GetByIdAsync(int id);
        Task<ICollection<Prato>> GetPratosAsync();
        Task<Prato> CreateAsync(Prato prato);
        Task EditAsync(Prato prato);
        Task DeleteAsync(Prato prato);
    }
}
