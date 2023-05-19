using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Domain.Entities;
using RestauranteWeb.Domain.Repositories;
using RestauranteWeb.Infra.Data.Context;

namespace RestauranteWeb.Infra.Data.Repositories
{
	public class PratoRepository : IPratoRepository
	{
		private readonly ApplicationDbContext _db;

		public PratoRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<Prato> CreateAsync(Prato prato)
		{
			_db.Add(prato);
			await _db.SaveChangesAsync();
			return prato;
		}

		public async Task DeleteAsync(Prato prato)
		{
			_db.Remove(prato);
			await _db.SaveChangesAsync();
		}

		public async Task EditAsync(Prato prato)
		{
			_db.Update(prato);
			await _db.SaveChangesAsync();
		}

		public async Task<Prato> GetByIdAsync(int id)
		{
			return await _db.Pratos.FirstOrDefaultAsync(x => x.Id == id);
		}

        public async Task<int> GetIdByPratoIdAsync(int id)
        {
			return (await _db.Pratos.FirstOrDefaultAsync(x => x.Id == id))?.Id ?? 0;
        }

        public async Task<ICollection<Prato>> GetPratosAsync(string? categoria = null, bool? status = null)
		{
			var query = _db.Pratos.AsQueryable();

			if (!string.IsNullOrEmpty(categoria))
			{
				query = query.Where(x => x.Categoria == categoria);
			}

			if (status.HasValue)
			{
				query = query.Where(x => x.Status == status.Value);
			}

			return await _db.Pratos.ToListAsync();
		}
	}
}
