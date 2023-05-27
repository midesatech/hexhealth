using Postgrest.Attributes;
using Postgrest.Models;

namespace MDT.SupabaseDb.Entities
{
    [Table("tbl_goals")]
    internal class GoalEntity: BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("id_user")]
        public string IdUser { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("date_init")]
        public DateTime DateInit { get; set; }

        [Column("date_end")]
        public DateTime DateEnd { get; set; }

        [Column("created_at", ignoreOnInsert: true)]
        public DateTime CreatedAt { get; set; }
    }
}
