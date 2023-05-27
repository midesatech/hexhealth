using MDT.Model.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDT.Model.Gateway
{
    public interface IGoalRepository
    {
        Task<Goal> AddGoal(Goal goal);
        Task<Goal> GetGoalById(int id);

        Task<List<Goal>> GetGoals();

        Task<List<Goal>> GetGoalsByUser(string userId);
        Task<Goal> UpdateGoal(Goal goal);
        Task DeleteGoalById(int id);

    }
}
