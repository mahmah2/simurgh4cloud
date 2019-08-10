using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Model
{
    public class SubscribeRequest
    {
        public string FirstName       { get; set; }
        public string EMail           { get; set; }
        public override string ToString()
        {
            return $"[{FirstName}],[{EMail}]";
        }
    }
}
