using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Domain.Entities;
using RestauranteWeb.Domain.Repositories;
using RestauranteWeb.Infra.Data.Context;

namespace RestauranteWeb.Infra.Data.Repositories
{
	public class ClienteRepository : IClienteRepository
	{
		private readonly ApplicationDbContext _db;

		public ClienteRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<Cliente> CreateAsync(Cliente cliente)
		{
			_db.Add(cliente);
			await _db.SaveChangesAsync();
			return cliente;
		}

		public async Task DeleteAsync(Cliente cliente)
		{
			_db.Remove(cliente);
			await _db.SaveChangesAsync();
		}

		public async Task EditAsync(Cliente cliente)
		{
			_db.Update(cliente);
			await _db.SaveChangesAsync();
		}

		public async Task<Cliente> GetByIdAsync(int id)
		{
			return await _db.Clientes.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<ICollection<Cliente>> GetClientesAsync()
		{
			return await _db.Clientes.ToListAsync();
		}

        public async Task<int> GetIdByClienteIdAsync(int idCliente)
        {
            return (await _db.Clientes.FirstOrDefaultAsync(x => x.Id == idCliente))?.Id ?? 0;
        }
    }
}
