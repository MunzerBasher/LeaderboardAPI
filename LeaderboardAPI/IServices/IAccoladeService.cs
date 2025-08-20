using LeaderboardAPI.Date.Entites;
using LeaderboardAPI.IRepository;

namespace LeaderboardAPI.IServices
{
    public interface IAccoladeService : IRepository<Accolade>, IUpdatebaleRepository<Accolade>,
        IDeletebleRepository

    {


    }



}