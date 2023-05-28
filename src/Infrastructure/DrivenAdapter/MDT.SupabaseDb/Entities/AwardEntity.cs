using Postgrest.Attributes;
using Postgrest.Models;

namespace MDT.SupabaseDb.Entities
{
        [Table("tbl_awards")]

        internal class AwardEntity : BaseModel
        {
            [PrimaryKey("id")]
            public Int64 Id { get; set; }

            [Column("id_user")]
            public String IdUser { get; set; }

            [Column("id_goal")]
            public Int64 IdGoal { get; set; }

            [Column("given_at")]
            public DateTime GivenAt { get; set; }

            [Column("created_at", ignoreOnInsert: true)]
            public DateTime CreatedAt { get; set; }

        }
}
