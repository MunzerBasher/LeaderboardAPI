using LeaderboardAPI.Date.DbContext;
using Microsoft.EntityFrameworkCore;
using LeaderboardAPI.Date.Entites;
using LeaderboardAPI.IServices;


namespace LeaderboardAPI.Services
{

    public class AccoladeService(ApplicationDbContext applicationDbContext) : IAccoladeService
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task<Accolade> AddAsync(Accolade entity)
        {
            await _applicationDbContext.AddAsync(entity);
            return await _applicationDbContext.SaveChangesAsync() > 0 ? entity: null!;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            return await _applicationDbContext.accolades.Where(r => r.Id == Id).ExecuteDeleteAsync() > 0;
        }

        public async Task<IList<Accolade>> GetAllAsync()
        {
            return await _applicationDbContext.accolades.AsNoTracking().ToListAsync();
        }

        public async Task<Accolade> GetAsync(int Id)
        {
            if (Id <= 0) return null!;
            if (await _applicationDbContext.accolades.AnyAsync(r => r.Id == Id)) return null!;
            return (await _applicationDbContext.accolades.FirstOrDefaultAsync(r => r.Id == Id))!;
        }

        public async Task<bool> IsExistAsync(int Id)
        {
            return await _applicationDbContext.accolades.AnyAsync(a => a.Id == Id);
        }

        public async Task<bool> UpdateAsync(Accolade entity)
        {
            return await _applicationDbContext.accolades.Where(r => r.Id == entity.Id)
                .ExecuteUpdateAsync(r => r.SetProperty(a => a.Name, entity.Name)
                .SetProperty(a => a.Description, entity.Description)
                ) > 0;
        }
    }

}