using MDT.Model.Data;
using MDT.Model.Gateway;
using Postgrest;
using static Postgrest.QueryOptions;

namespace MDT.SupabaseDb.Entities
{
    public class AwardAdapter : IAwardRepository
    {
        private readonly Supabase.Client supabaseClient;

        public AwardAdapter(Supabase.Client supabaseClient)
        {
            this.supabaseClient = supabaseClient;
        }

        public async Task<Award> AddAward(Award award)
        {
            var model = new AwardEntity
            {
                IdUser = award.IdUser,
                IdGoal = award.IdGoal,
                Description = award.Description,
                GivenAt = award.GivenAt
            };
            var response = await supabaseClient
                .From<AwardEntity>()
                .Insert(model, new QueryOptions { Returning = ReturnType.Representation });

            var result = response.Model;
            return new Award(result.Id, result.IdGoal, result.IdUser, result.Description, result.GivenAt);
        }

        public async Task DeleteAwardById(int id)
        {
            await supabaseClient
                .From<AwardEntity>()
                .Where(x => x.Id == id)
                .Delete();
        }

        public async Task<Award?> GetAwardById(int id)
        {
            var result = await supabaseClient.From<AwardEntity>()
                .Where(x => x.Id == id)
                .Single();

            if (result != null)
            {
                return new Award(result.Id, result.IdGoal, result.IdUser, result.Description, result.GivenAt);
            }

            return null;
        }

        public async Task<List<Award>> GetAwards()
        {
            var Award = new List<Award>();

            var response = await supabaseClient.From<AwardEntity>().Get();
            response.Models.ForEach(x => {
                Award.Add(new Award(x.Id, x.IdGoal, x.IdUser, x.Description, x.GivenAt));
            });
            return Award;
        }

        public async Task<List<Award>> GetAwardsByUser(string userId)
        {
            var Award = new List<Award>();

            var response = await supabaseClient.From<AwardEntity>()
                .Where(x => x.IdUser == userId)
                .Get();
            response.Models.ForEach(x => {
                Award.Add(new Award(x.Id, x.IdGoal, x.IdUser, x.Description, x.GivenAt));
            });
            return Award;
        }

        public async Task<List<Award>> GetAwardsByGoal(Int64 goalId)
        {
            var Award = new List<Award>();

            var response = await supabaseClient.From<AwardEntity>()
                .Where(x => x.IdGoal == goalId)
                .Get();
            response.Models.ForEach(x => {
                Award.Add(new Award(x.Id, x.IdGoal, x.IdUser, x.Description, x.GivenAt));
            });
            return Award;
        }

        public async Task<Award> UpdateAward(Award award)
        {
            var model = new AwardEntity
            {
                Id = award.Id,
                IdUser = award.IdUser,
                IdGoal = award.IdGoal,
                Description = award.Description, 
                GivenAt = award.GivenAt,
            };

            var response = await supabaseClient
                .From<AwardEntity>()
                .Upsert(model, new QueryOptions { Returning = ReturnType.Representation });

            var result = response.Model;
            return new Award(result.Id, result.IdGoal, result.IdUser, result.Description, result.GivenAt);
        }
    }
}
