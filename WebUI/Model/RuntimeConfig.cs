using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Model
{
    public class RuntimeConfig
    {
        public List<string> ContactUsEmails { get; set; }
        public string SmtpServer { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
    }

}
