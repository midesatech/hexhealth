using System;

namespace MDT.Model.Data
{
    public class Award
    {
        public Int64 Id { get; private set; }
        public Int64 IdGoal { get; private set; }
        public String IdUser { get; private set; }
        public DateTime GivenAt { get; private set; }

        public Award(Int64 id, Int64 idGoal, String idUser, DateTime givenAt)
        {
            this.Id = id;
            this.IdGoal = idGoal;
            this.IdUser = idUser;
            this.GivenAt = givenAt;
        }
    }
}
