using System;

namespace MDT.Model.Data
{
    public class Award
    {
        public Int64 Id { get; private set; }
        public Int64 IdGoal { get; private set; }
        public String IdUser { get; private set; }
        public String Description { get; private set; }

        public String Title { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Award(Int64 id, Int64 idGoal, String idUser, String title, String description, DateTime createdAt)
        {
            this.Id = id;
            this.IdGoal = idGoal;
            this.IdUser = idUser;
            this.Title = title;
            this.Description = description;
            this.CreatedAt = createdAt;
        }
    }
}
