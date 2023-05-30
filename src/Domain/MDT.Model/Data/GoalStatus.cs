using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDT.Model.Data
{
    public class GoalStatus
    {
        public String IdUser { get; private set; }
        public Int64 Total { get; private set; }
        public Int64 Achieved { get; private set; }
        public Int64 UnAchieved { get; private set; }
        public List<GoalProgress> GoalsStatus { get; private set; }



        public GoalStatus(String idUser, Int64 total, Int64 achieved, Int64 unAchieved, List<GoalProgress> goalsStatus)
        {
            this.IdUser = idUser;
            this.Total = total;
            this.Achieved = achieved;
            this.UnAchieved = unAchieved;
            this.GoalsStatus = goalsStatus;
        }
    }
}
