using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Domain.Entities;
using RestauranteWeb.Domain.Repositories;
using RestauranteWeb.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<ICollection<Prato>> GetPratosAsync()
        {
            return await _db.Pratos.ToListAsync();
        }
    }
}
