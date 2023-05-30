using MDT.Model.Data;
using MDT.Model.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDT.UseCase.Goals
{
    public class GoalUseCase : IGoalUseCase
    {
        private readonly IGoalRepository  _goalRepository;
        private readonly IProgressRepository _progressRepository;
        private readonly IAwardRepository _awardRepository;

        public GoalUseCase(IGoalRepository repository, IProgressRepository progressRepository, IAwardRepository awardRepository)
        {
            _goalRepository = repository;
            _progressRepository = progressRepository;   
            _awardRepository = awardRepository;
        }

        public Task<Goal> AddGoal(Goal goal)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _goalRepository.AddGoal(goal);
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
                    return _goalRepository.DeleteGoalById(goalId);
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
                    return _goalRepository.GetGoalById(goalId);
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
                    return _goalRepository.GetGoals(); 
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
                    var goalsProgress = GetGoalStatusByUser(userId).Result;

                    var currentGoals = _goalRepository.GetGoalsByUser(userId);

                    List<Goal> result = new List<Goal>();

                    currentGoals.Result.ForEach(goal => {
                        var progress = goalsProgress.GoalsStatus.Find(x => x.Id == goal.Id).Progress == 100 ? true: false;  
                        result.Add(
                            new Goal(goal.Id, goal.IdUser, goal.Title, goal.Description, goal.DateInit, goal.DateEnd, goal.IsActive, progress));
                    });

                    return result;                     
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
                    return _goalRepository.UpdateGoal(goal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }


        public Task<GoalStatus> GetGoalStatusByUser(string userId)
        {
            return Task.Run(() => {
                var goals = _goalRepository.GetGoalsByUser(userId);


                var totalGoals = goals.Result.Count;
                var goalsProgress = new List<GoalProgress>();

                var goalsAchieved = 0;

                goals.Result.ForEach(item => {
                    var diff = (item.DateEnd - item.DateInit).Days + 1;

                    var progress = _progressRepository.GetAllProgressByGoal(item.Id).Result.GroupBy(g => g.CreatedAt.Day);
                    var progressCount = progress.Count();
                    var percentage = (progressCount * 100) / diff;
                    var isDone = percentage == 100;
                    goalsProgress.Add(new GoalProgress(item.Id, percentage, isDone, item.Title, item.Description));

                    if (isDone)
                    {
                        goalsAchieved++;
                        CreateAward(item);
                    }

                });

                return new GoalStatus(userId, totalGoals, goalsAchieved, totalGoals - goalsAchieved, goalsProgress);
            });            

        }

        private void CreateAward(Goal goal)
        {
            //Find award

            Task.Run(() =>
            {
                var currentAwards = _awardRepository.GetAwardsByGoal(goal.Id);

                    var award = currentAwards.Result.Find(x => x.IdGoal == goal.Id);
                    if (award == null)
                    {
                        _awardRepository.AddAward(new Award(0, goal.Id, goal.IdUser, "Award!", "Lograste un premio por completar tu meta: " + goal.Title, DateTime.Now));
                    }

            });


        }

    }
}
