using MDT.Model.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDT.Model.Gateway
{
    public interface IGoalRepository
    {
        Task<Goal> GetGoalById(string id);

        Task<List<Goal>> GetGoals();

        Task<Goal> AddGoal(Goal goal);
    }
}
