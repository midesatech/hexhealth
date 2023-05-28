using MDT.Model.Gateway;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDT.UseCase.Awards
{
    public class AwardUseCase : IAwardUseCase
    {
        private readonly IAwardRepository _repository;

        public AwardUseCase(IAwardRepository repository)
        {
            _repository = repository;
        }

        public Task<Model.Data.Award> AddAward(Model.Data.Award award)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.AddAward(award);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task DeleteAwardById(int awardId)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.DeleteAwardById(awardId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task<List<Model.Data.Award>> GetAwards()
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.GetAwards();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task<List<Model.Data.Award>> GetAwardsByGoal(long goalId)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.GetAwardsByGoal(goalId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task<Model.Data.Award> GetAwardById(int id)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.GetAwardById(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task<List<Model.Data.Award>> GetAwardsByUser(string userId)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.GetAwardsByUser(userId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task<Model.Data.Award> UpdateAward(Model.Data.Award award)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.UpdateAward(award);
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
