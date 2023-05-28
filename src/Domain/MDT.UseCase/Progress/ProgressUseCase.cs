using MDT.Model.Data;
using MDT.Model.Gateway;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDT.UseCase.Progress
{
    public class ProgressUseCase : IProgressUseCase
    {
        private readonly IProgressRepository _repository;

        public ProgressUseCase(IProgressRepository repository)
        {
            _repository = repository;
        }

        public Task<Model.Data.Progress> AddProgress(Model.Data.Progress progress)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.AddProgress(progress);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task DeleteProgressById(int progressId)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.DeleteProgressById(progressId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task<List<Model.Data.Progress>> GetAllProgress()
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.GetAllProgress(); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task<List<Model.Data.Progress>> GetAllProgressByGoal(long goalId)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.GetAllProgressByGoal(goalId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task<Model.Data.Progress> GetProgressById(int id)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.GetProgressById(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task<List<Model.Data.Progress>> GetAllProgressByUser(string userId)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.GetAllProgressByUser(userId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            });
        }

        public Task<Model.Data.Progress> UpdateProgress(Model.Data.Progress progress)
        {
            return Task.Run(() =>
            {
                try
                {
                    return _repository.UpdateProgress(progress);
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
