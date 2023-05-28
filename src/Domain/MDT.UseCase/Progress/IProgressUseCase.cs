using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MDT.UseCase.Progress
{
    public interface IProgressUseCase
    {
        Task<Model.Data.Progress> AddProgress(Model.Data.Progress progress);
        Task DeleteProgressById(int id);
        Task<Model.Data.Progress> GetProgressById(int id);
        Task<List<Model.Data.Progress>> GetAllProgress();
        Task<List<Model.Data.Progress>> GetAllProgressByUser(string userId);
        Task<List<Model.Data.Progress>> GetAllProgressByGoal(Int64 goalId);
        Task<Model.Data.Progress> UpdateProgress(Model.Data.Progress progress);
    }
}
