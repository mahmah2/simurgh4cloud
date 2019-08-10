using System.Collections.Generic;

namespace Simurgh.DAL.Model
{
    public class Client : BaseModel
    {
        public string ClientName        { get; set; }
        public string ClientDescription { get; set; }
        public string GoogleMapAddress  { get; set; }
        public string Avatar            { get; set; }
        public int?    RowNo             { get; set; }

        public ICollection<Picture> Pictures   { get; set; }

        public ICollection<Project> Projects { get; set; }
    }

}
