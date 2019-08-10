using Microsoft.Extensions.Logging;
using Simurgh.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simurgh.DAL
{
    public class SubscriberRepository : BaseRepository<Subscriber>
    {
        public SubscriberRepository(ILogger logger, bool inMemory) :
            base(logger, inMemory)
        {

        }
        
    }
}
