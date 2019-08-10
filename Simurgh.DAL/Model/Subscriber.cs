using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;


namespace Simurgh.DAL.Model
{
    public class Subscriber : BaseModel
    {
        public DateTime Created { get; set; }
        public string EMail { get; set; }
        public string FirstName { get; set; }

        public Subscriber()
        {

        }

        public Subscriber(string firstName, String email)
        {
            FirstName = firstName;
            EMail = email;
            Created = DateTime.Now;
        }
    }
}
