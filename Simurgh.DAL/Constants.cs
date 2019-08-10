using System;
using System.Collections.Generic;
using System.Text;

namespace Simurgh.DAL
{
    public class Constants
    {
        //public static string DBFilePath = "Simurgh1.db";
        public static string DBFilePath = @"Simurgh1.db";
        public static string DBInMemory = @":memory:";
        public static string CollectionNameClients = "clients";
        public static string CollectionNameProjects = "projects";
        public static string CollectionNameSubscribers = "subscribers";

        public static string ProjectsFolderName = "images/projects";
        public static string ClientsFolderName = "images/clients";
    }
}
