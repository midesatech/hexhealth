using System;

namespace MDT.Model.Data
{
    public class Goal
    {
        public Int32? Id { get; private set; }

        public String IdUser { get; private set; }
        public String Title { get; private set; }
        public String Description { get; private set; }
        public Boolean IsActive { get; private set; }
        public DateTime DateInit { get; private set; }
        public DateTime DateEnd { get; private set; }
        public Goal(Int32? id, String iduser, String Title, String Description, DateTime dateinit, DateTime dateend, Boolean isactive) {
            this.Id = id;
            this.IdUser = iduser;
            this.Title = Title;
            this.Description = Description;
            this.DateInit = dateinit;
            this.DateEnd = dateend;
            this.IsActive = isactive;
        }   

    }
}
