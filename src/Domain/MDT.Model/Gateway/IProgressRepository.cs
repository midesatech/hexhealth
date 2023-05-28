using MDT.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDT.Model.Gateway
{
    public interface IProgressRepository
    {
        Task<Progress> AddProgress(Progress progress);
        Task DeleteProgressById(int id);
        Task<Progress> GetProgressById(int id);
        Task<List<Progress>> GetAllProgress();
        Task<List<Progress>> GetAllProgressByUser(string userId);
        Task<List<Progress>> GetAllProgressByGoal(Int64 goalId);
        Task<Progress> UpdateProgress(Progress progress);
    }
}
