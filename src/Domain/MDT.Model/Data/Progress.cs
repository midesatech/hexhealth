using System;

namespace MDT.Model.Data
{
    public class Progress
    {
        public Int64 Id { get; private set; }
        public Int64 IdGoal { get; private set; }
        public String IdUser { get; private set; }
        public DateTime TakenAt { get; private set; }

        public Progress(Int64 id, Int64 idGoal, String idUser, DateTime takenAt) {
            this.Id = id;
            this.IdGoal = idGoal;
            this.IdUser = idUser;
            this.TakenAt = takenAt;
        }
    }
}
