using MDT.Model.Data;
using MDT.Model.Gateway;
using Postgrest;
using static Postgrest.QueryOptions;

namespace MDT.SupabaseDb.Entities
{
    public class ProgressAdapter : IProgressRepository
    {
        private readonly Supabase.Client supabaseClient;

        public ProgressAdapter(Supabase.Client supabaseClient)
        {
            this.supabaseClient = supabaseClient;
        }

        public async Task<Progress> AddProgress(Progress progress)
        {
            var model = new ProgressEntity
            {
                IdUser = progress.IdUser,
                IdGoal = progress.IdGoal,
                TakenAt = progress.TakenAt
            };
            var response = await supabaseClient
                .From<ProgressEntity>()
                .Insert(model, new QueryOptions { Returning = ReturnType.Representation });

            var result = response.Model;
            return new Progress(result.Id, result.IdGoal, result.IdUser, result.TakenAt);
        }

        public async Task DeleteProgressById(int id)
        {
            await supabaseClient
                .From<ProgressEntity>()
                .Where(x => x.Id == id)
                .Delete();
        }

        public async Task<Progress?> GetProgressById(int id)
        {
            var result = await supabaseClient.From<ProgressEntity>()
                .Where(x => x.Id == id)
                .Single();

            if (result != null)
            {
                return new Progress(result.Id, result.IdGoal, result.IdUser, result.TakenAt);
            }

            return null;
        }

        public async Task<List<Progress>> GetAllProgress()
        {
            var progress = new List<Progress>();

            var response = await supabaseClient.From<ProgressEntity>().Get();
            response.Models.ForEach(x => {
                progress.Add(new Progress(x.Id, x.IdGoal, x.IdUser, x.TakenAt));
            });
            return progress;
        }

        public async Task<List<Progress>> GetAllProgressByUser(string userId)
        {
            var progress = new List<Progress>();

            var response = await supabaseClient.From<ProgressEntity>()
                .Where(x => x.IdUser == userId)
                .Get();
            response.Models.ForEach(x => {
                progress.Add(new Progress(x.Id, x.IdGoal, x.IdUser, x.TakenAt));
            });
            return progress;
        }

        public async Task<List<Progress>> GetAllProgressByGoal(Int64 goalId)
        {
            var progress = new List<Progress>();

            var response = await supabaseClient.From<ProgressEntity>()
                .Where(x => x.IdGoal == goalId)
                .Get();
            response.Models.ForEach(x => {
                progress.Add(new Progress(x.Id, x.IdGoal, x.IdUser, x.TakenAt));
            });
            return progress;
        }

        public async Task<Progress> UpdateProgress(Progress progress)
        {
            var model = new ProgressEntity
            {
                Id = progress.Id,
                IdUser = progress.IdUser,
                IdGoal = progress.IdGoal,
                TakenAt = progress.TakenAt,
            };

            var response = await supabaseClient
                .From<ProgressEntity>()
                .Upsert(model, new QueryOptions { Returning = ReturnType.Representation });

            var result = response.Model;
            return new Progress(result.Id, result.IdGoal, result.IdUser, result.TakenAt);
        }  
    }
}
