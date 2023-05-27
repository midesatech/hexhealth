using MDT.Model.Data;
using MDT.Model.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDT.UseCase.Goals
{
    public class GoalUseCase : IGoalUseCase
    {
        private readonly IGoalRepository  _repository;

        public GoalUseCase(IGoalRepository repository)
        {
            _repository = repository;
        }

        public Task<Goal> AddGoal(Goal goal)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.AddGoal(goal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task<List<Goal>> GetGoals()
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.GetGoals(); ;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }
    }
}
