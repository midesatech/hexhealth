using MDT.Model.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDT.UseCase.Awards
{
    public interface IAwardUseCase
    {
        Task<Award> AddAward(Award award);
        Task DeleteAwardById(int id);
        Task<Award> GetAwardById(int id);
        Task<List<Award>> GetAwards();
        Task<List<Award>> GetAwardsByUser(string userId);
        Task<List<Award>> GetAwardsByGoal(Int64 goalId);
        Task<Award> UpdateAward(Award award);
    }
}
