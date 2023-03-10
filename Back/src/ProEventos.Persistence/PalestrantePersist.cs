using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;
        public PalestrantePersist(ProEventosContext context){
            _context = context;
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query =  _context.Palestrantes
                .Include(p => p.RedesSociais);

            query = query.AsNoTracking().OrderBy(p => p.Id);

            if (includeEventos)
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNameAsync(string name, bool includeEventos = false)
        {
            IQueryable<Palestrante> query =  _context.Palestrantes
                .Include(p => p.RedesSociais);

            query = query.OrderBy(e => e.Id)
                .AsNoTracking()
                .Where(p => p.Nome.ToLower().Contains(name.ToLower()));

            if (includeEventos)
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetEPalestrantesByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query =  _context.Palestrantes
                .Include(p => p.RedesSociais);

            query = query.OrderBy(e => e.Id)
                .AsNoTracking()
                .Where(p => p.Id == palestranteId);

            if (includeEventos)
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);

            return await query.FirstOrDefaultAsync();
        }
    }
}