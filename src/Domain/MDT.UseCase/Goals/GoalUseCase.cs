using MDT.Model.Data;
using MDT.Model.Gateway;
using System;
using System.Collections.Generic;
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

        public Task DeleteGoalById(int goalId)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.DeleteGoalById(goalId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task<Goal> GetGoalById(int goalId)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.GetGoalById(goalId);
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

        public Task<List<Goal>> GetGoalsByUser(string userId)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.GetGoalsByUser(userId); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task<Goal> UpdateGoal(Goal goal)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.UpdateGoal(goal);
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
