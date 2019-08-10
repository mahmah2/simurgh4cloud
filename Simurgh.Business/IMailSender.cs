using System;
using System.Collections.Generic;
using System.Text;

namespace Simurgh.Business
{
    public interface IMailSender
    {
        bool Authenticate(string server, string userName, string password);
        bool SendPlain(string from, List<string> to, string subject, string body);
    }
}
