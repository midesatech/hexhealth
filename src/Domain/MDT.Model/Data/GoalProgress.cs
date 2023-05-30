using System;

namespace MDT.Model.Data
{
    public class GoalProgress
    {
        public Int32 Id { get; private set; }
        public Int32 Progress { get; private set; }

        public String Title { get; private set; }
        public String Description { get; private set; }
        public Boolean IsDone { get; private set; }

        public GoalProgress(Int32 goalId, Int32 progress, Boolean isDone, String title, String description)
        {
            this.Id = goalId;
            this.Progress = progress;
            this.IsDone = isDone;
            this.Title = title;
            this.Description = description;
        }
    }
}
