using MDT.Model.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDT.UseCase.Goals
{
    public interface IGoalUseCase
    {
        Task<Goal> AddGoal(Goal goal);
        Task<List<Goal>> GetGoals();
        Task<List<Goal>> GetGoalsByUser(string userId);
        Task<Goal> GetGoalById(int goalId);
        Task<Goal> UpdateGoal(Goal goal);
        Task DeleteGoalById(int goalId);
        Task<GoalStatus> GetGoalStatusByUser(string userId);
    }
}
