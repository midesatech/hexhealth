using System;

namespace MDT.Model.Data
{
    public class Progress
    {
        public Int64 Id { get; private set; }
        public Int64 IdGoal { get; private set; }
        public String IdUser { get; private set; }
        public String Title { get; private set; }
        public String Description { get; private set; }
        public Boolean IsDone { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Progress(Int64 id, Int64 idGoal, String idUser, String title, String description, Boolean isDone, DateTime createdAt) {
            this.Id = id;
            this.IdGoal = idGoal;
            this.IdUser = idUser;
            this.Title = title;
            this.Description = description;
            this.IsDone = isDone;
            this.CreatedAt = createdAt;
        }
    }
}
