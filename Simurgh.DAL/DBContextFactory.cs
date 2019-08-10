using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Simurgh.DAL
{
    //class DBContextFactory //: IDisposable
    //{
            //private DbConnection _connection;

            //private DbContextOptions<SimurghDB> CreateOptions()
            //{
            //    return new DbContextOptionsBuilder<SimurghDB>()
            //        .UseSqlite(_connection).Options;
            //}

            //public SimurghDB CreateContext()
            //{
            //    if (_connection == null)
            //    {
            //        _connection = new SqliteConnection("DataSource=:memory:");
            //        _connection.Open();

            //        var options = CreateOptions();
            //        using (var context = new SimurghDB())
            //        {
            //            context.Database.EnsureCreated();
            //        }
            //    }

            //    return new SimurghDB();
            //}

            //public void Dispose()
            //{
            //    if (_connection != null)
            //    {
            //        _connection.Dispose();
            //        _connection = null;
            //    }
            //}

    //}
}
