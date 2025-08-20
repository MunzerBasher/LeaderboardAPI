using LeaderboardAPI.Contracts;
using LeaderboardAPI.Date.Entites;

namespace LeaderboardAPI.IServices
{
    public interface IRacerServices
    {

        Task<bool> AddAsync(RacerRequest racerRequest);

        Task<bool> AddStarsAsync(RacerStartRequest racerStatrsRequest);

        Task<bool> AddAccoladeAsync(RacerAccoladeRequest accoladeRequest);

        Task<bool> UpdateAsync(int Id ,RacerRequest racerRequest);

        Task<bool> DeleteAsync(int Id);


        Task<IList<RacerResponse>> GetAllByDetailsAsync();

        Task<IList<RacerResponse>> GetAllByDetailsAsync(DateTime startDate , DateTime endDate);

        Task<IList<RacerResponseByDetails>> GetAsync(int Id);

        Task<IList<RacerResponseByDetails>> SearchAsync(string name);


    }


}
