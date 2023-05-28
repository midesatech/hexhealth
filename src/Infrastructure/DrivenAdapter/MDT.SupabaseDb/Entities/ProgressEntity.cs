using Postgrest.Attributes;
using Postgrest.Models;

namespace MDT.SupabaseDb.Entities
{
    [Table("tbl_progress")]

    internal class ProgressEntity : BaseModel
    {
        [PrimaryKey("id")]
        public Int64 Id { get; set; }

        [Column("id_user")]
        public String IdUser { get; set; }

        [Column("id_goal")]
        public Int64 IdGoal { get; set; }

        [Column("taken_at")]
        public DateTime TakenAt { get; set; }

        [Column("created_at", ignoreOnInsert: true)]
        public DateTime CreatedAt { get; set; }

    }
}
