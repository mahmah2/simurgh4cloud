using System;
using System.Collections.Generic;

namespace Simurgh.DAL.Model
{
    public class Project : BaseModel
    {
        public string   Name { get; set; }
        public string   Description { get; set; }
        public DateTime? Created { get; set; }

        public string   GoogleMapAddress { get; set; }

        public int?      ClientId { get; set; }
        public Client   Client { get; set; }    

        public Stage?    ProjectStage { get; set; }

        public DateTime? EvaluationDate { get; set; }
        public decimal?  EvaluationAmount { get; set; }
        public decimal?  MoneyRaised { get; set; }
        public decimal?  AcctualMoneySpent { get; set; }


        public DateTime? ExecutionStarted { get; set; }
        public DateTime? Finished { get; set; }

        public ICollection<Picture> Pictures { get; set; }

        public DateTime? LastUpdated { get; set; }

        public int?      RowNo { get; set; }
    }

}
