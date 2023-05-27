using MDT.Model.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDT.UseCase.Goals
{
    public interface IGoalUseCase
    {
        Task<List<Goal>> GetGoals();
        Task<Goal> AddGoal(Goal goal);
    }
}
