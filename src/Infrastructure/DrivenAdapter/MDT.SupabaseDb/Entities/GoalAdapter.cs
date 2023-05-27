using MDT.Model.Data;
using MDT.Model.Gateway;
using Postgrest;
using static Postgrest.QueryOptions;

namespace MDT.SupabaseDb.Entities
{
    public class GoalAdapter : IGoalRepository
    {

        private readonly Supabase.Client supabaseClient;

        public GoalAdapter(Supabase.Client supabaseClient)
        {
            this.supabaseClient = supabaseClient;
        }

        public async Task<Goal> AddGoal(Goal goal)
        {
            var model = new GoalEntity
            {
                IdUser = goal.IdUser,
                Title = goal.Title,
                Description = goal.Description,
                DateInit = goal.DateInit,
                DateEnd = goal.DateEnd,
                IsActive = goal.IsActive
            };
            var response = await supabaseClient
                .From<GoalEntity>()
                .Insert(model, new QueryOptions { Returning = ReturnType.Representation });

            var result = response.Model;
            return new Goal(result.Id, result.IdUser, result.Title, result.Description, result.DateInit, result.DateEnd, result.IsActive);
        }

        public async Task DeleteGoalById(int id)
        {
            await supabaseClient
                .From<GoalEntity>()
                .Where(x => x.Id == id)
                .Delete();
        }

        public async Task<Goal?> GetGoalById(int id)
        {
            var result = await supabaseClient.From<GoalEntity>()
                .Where(x => x.Id == id)
                .Single();

            if (result != null)
            {
                return new Goal(result.Id, result.IdUser, result.Title, result.Description, result.DateInit, result.DateEnd, result.IsActive);
            }

            return null;
        }

        public async Task<List<Goal>> GetGoals()
        {
            var goals = new List<Goal>();

            var response = await supabaseClient.From<GoalEntity>().Get();
            response.Models.ForEach(x => {
                goals.Add(new Goal(x.Id, x.IdUser, x.Title, x.Description, x.DateInit, x.DateEnd, x.IsActive));                
            });
            return goals;
        }

        public async Task<List<Goal>> GetGoalsByUser(string userId)
        {
            var goals = new List<Goal>();

            var response = await supabaseClient.From<GoalEntity>()
                .Where(x => x.IdUser == userId)
                .Get();
            response.Models.ForEach(x => {
                goals.Add(new Goal(x.Id, x.IdUser, x.Title, x.Description, x.DateInit, x.DateEnd, x.IsActive));
            });
            return goals;
        }

        public async Task<Goal> UpdateGoal(Goal goal)
        {
            var model = new GoalEntity
            {
                Id = goal.Id,
                IdUser = goal.IdUser,
                Title = goal.Title,
                Description = goal.Description,
                DateInit = goal.DateInit,
                DateEnd = goal.DateEnd,
                IsActive = goal.IsActive
            };

            var response = await supabaseClient
                .From<GoalEntity>()
                .Upsert(model, new QueryOptions { Returning = ReturnType.Representation });

            var result = response.Model;
            return new Goal(result.Id, result.IdUser, result.Title, result.Description, result.DateInit, result.DateEnd, result.IsActive);
        }
    }
}


