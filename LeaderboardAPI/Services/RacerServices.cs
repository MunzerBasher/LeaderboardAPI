using LeaderboardAPI.Contracts; 
using LeaderboardAPI.IServices;
using LeaderboardAPI.Date.Entites;
using LeaderboardAPI.Date.DbContext;
using Microsoft.EntityFrameworkCore;



namespace LeaderboardAPI.Services
{

    public class RacerServices(ApplicationDbContext applicationDbContext) : IRacerServices
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task<bool> AddAccoladeAsync(RacerAccoladeRequest accoladeRequest)
        {
            await _applicationDbContext.AddAsync(new RacerAccolade { 
                AccoladeId = accoladeRequest.AccoladeId
                ,RacerId = accoladeRequest.RacerId ,
                DateTime = accoladeRequest.DateTime, 
                Reason = accoladeRequest.Reason
            
            });
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddAsync(RacerRequest racerRequest)
        {
            await _applicationDbContext.AddAsync(new Racer { Description = racerRequest .Description, Name = racerRequest .Name});    
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddStarsAsync(RacerStartRequest racerStatrsRequest)
        {
            if (racerStatrsRequest == null) return false;
            if (!await _applicationDbContext.racers.AnyAsync(r => r.Id == racerStatrsRequest.RacerId)) return false;
            await _applicationDbContext.racersStart.AddAsync(
                new RacerStatrs
                {
                    DateTime = racerStatrsRequest.DateTime,
                    RacerId = racerStatrsRequest.RacerId,
                    Number = racerStatrsRequest.Number,
                    Reason = racerStatrsRequest.Reason, 
                });
            if( await _applicationDbContext.SaveChangesAsync() < 0) return false;
            var racer = await _applicationDbContext.racers.FirstOrDefaultAsync(a => a.Id == racerStatrsRequest.RacerId);
            if (racer == null) return false;
            return await _applicationDbContext.racers.Where(a => a.Id == racerStatrsRequest.RacerId)
                .ExecuteUpdateAsync( r => r
                .SetProperty(a => a.TotalOfStart,(racer.TotalOfStart + racerStatrsRequest.Number))) > 0;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            return await _applicationDbContext.racers.Where(r => r.Id == Id).ExecuteDeleteAsync() > 0;
        }

        

        public async Task<IList<RacerResponse>> GetAllByDetailsAsync()
        {
            return await _applicationDbContext.racers
                .Include(a => a.racerAccolade)
               
                .Select(
                r => new RacerResponse { 
                Id = r.Id,
                Description = r.Description ??"", Name = r.Name ,
                TotalOfStars = r.TotalOfStart,
                Accolade = r.racerAccolade.Select(s => new AccoladeResponse {Id = s.Id , Name = s.accolade.Name }).ToList(),
                }
                ).AsNoTracking().ToListAsync();
        }

        public async Task<IList<RacerResponse>> GetAllByDetailsAsync(DateTime startDate, DateTime endDate)
        {
            return await _applicationDbContext.racers
                .Include(a => a.racerAccolade)
                .Select(
                r => new RacerResponse
                {
                    Id = r.Id,
                    Description = r.Description ?? "",
                    Name = r.Name,
                    TotalOfStars = r.TotalOfStart,
                    
                    Accolade = r.racerAccolade.Select(s => new AccoladeResponse { Id = s.Id, Name = s.accolade.Name }).ToList(),
                }
                ).AsNoTracking().ToListAsync();
        }

        public async Task<IList<RacerResponseByDetails>> GetAsync(int Id)
        {
            if (Id <= 0) return null!;
            if(!await _applicationDbContext.racers.AnyAsync(r => r.Id == Id)) return null!;
            return await  _applicationDbContext.racers.Where(a => a.Id == Id)
                .Include(a => a.racerAccolade)
                .Include(a => a.racerStatrs)
                .Select(
                r => new RacerResponseByDetails
                {
                    Id = r.Id,
                    Description = r.Description ?? "",
                    Name = r.Name,
                    TotalOfStars = r.TotalOfStart,
                    Accolade = r.racerAccolade.Select(s => new AccoladeResponse { Id = s.Id, Name = s.accolade.Name }).ToList(),
                    StartResponse = r.racerStatrs.Select(d => new StartResponse {Reason = d.Reason , Number = d.Number ,DateTime = d.DateTime }).ToList()
                }
                ).AsNoTracking().ToListAsync();
        }

        public async Task<IList<RacerResponseByDetails>> SearchAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null!;
            if (!await _applicationDbContext.racers.AnyAsync(r => r.Name.StartsWith(name))) return null!;
            return await _applicationDbContext.racers.Where(a => a.Name.StartsWith(name))
                .Include(a => a.racerAccolade)
                .Include(a => a.racerStatrs)
                .Select(
                r => new RacerResponseByDetails
                {
                    Id = r.Id,
                    Description = r.Description ?? "",
                    Name = r.Name,
                    TotalOfStars = r.TotalOfStart,
                    Accolade = r.racerAccolade.Select(s => new AccoladeResponse { Id = s.Id, Name = s.accolade.Name }).ToList(),
                    StartResponse = r.racerStatrs.Select(d => new StartResponse { Reason = d.Reason, Number = d.Number, DateTime = d.DateTime }).ToList()
                }
                ).AsNoTracking().ToListAsync();
        }

        public async Task<bool> UpdateAsync(int Id, RacerRequest racerRequest)
        {
            return await _applicationDbContext.racers.Where(r => r.Id == Id)
                .ExecuteUpdateAsync(r => r.SetProperty(a => a.Name, racerRequest.Name)
                .SetProperty(a => a.Description, racerRequest.Description)
                ) > 0;
        }
    }


}