using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Domain.Entities;
using RestauranteWeb.Domain.Repositories;
using RestauranteWeb.Infra.Data.Context;
using System;

namespace RestauranteWeb.Infra.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _db;

        public PedidoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Pedido> CreateAsync(Pedido pedido)
        {
            _db.Add(pedido);
            await _db.SaveChangesAsync();
            return pedido;
        }

        public async Task DeleteAsync(Pedido pedido)
        {
            _db.Remove(pedido);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Pedido pedido)
        {
            _db.Update(pedido);
            await _db.SaveChangesAsync();
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            var pedido = await _db.Pedidos
                .Include(x => x.Prato)
                .Include(x => x.Cliente)
                .FirstOrDefaultAsync(x => x.Id == id);

            return pedido;
        }

        public async Task<ICollection<Pedido>> GetAllSync()
        {
            return await _db.Pedidos
                .Include(x=> x.Prato)
                .Include(x=> x.Cliente)
                .ToListAsync();
        }

        public async Task<ICollection<Pedido>> GetByClienteIdAsync(int idCliente)
        {
            return await _db.Pedidos
                .Include(x=> x.Cliente)
                .Include(x=> x.Prato)
                .Where(x=> x.IdCliente == idCliente).ToListAsync();
        }

        public async Task<ICollection<Pedido>> GetByPratoIdAsync(int idPrato)
        {
            return await _db.Pedidos
                .Include(x => x.Prato)
                .Include(x => x.Cliente)
                .Where(x => x.IdPrato == idPrato).ToListAsync();
        }
    }
}
