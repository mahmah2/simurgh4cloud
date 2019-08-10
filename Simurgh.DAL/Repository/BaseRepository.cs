using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Simurgh.DAL.Model;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;


namespace Simurgh.DAL
{
    //public class BaseRepository<T> : IGenericRepository<T> where T : class, IEntity
    public class BaseRepository<T> where T : BaseModel
    {
        private SimurghDB _db;

        protected ILogger _logger;

        public BaseRepository(ILogger logger, bool inMemory = false)
        {
            _logger = logger;

            logger.LogEntrance(this.GetType().Name);

            SqliteConnection connection;
            if (inMemory)
            {
                connection = new SqliteConnection($"DataSource={Constants.DBInMemory}");
            }
            else
            {
                connection = new SqliteConnection($"DataSource={Constants.DBFilePath}");
            }

            connection.Open();

            logger.LogInformation($"connection string = {connection.ConnectionString}");

            var options = new DbContextOptionsBuilder<SimurghDB>()
                    .UseSqlite(connection)
                    .Options;

            _db = new SimurghDB(options);

            _db.Database.EnsureCreated();

            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            logger.LogExit(this.GetType().Name);
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().AsNoTracking();
        }

        public Task<T> GetById(int id)
        {
            return _db.Set<T>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(T entity)
        {
            _logger.LogEntrance(nameof(AddAsync), entity.ToString());

            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();

            _logger.LogExit(nameof(AddAsync));
        }

        public void Add(T entity)
        {
            _logger.LogEntrance(nameof(Add), entity.ToString());

            _db.Set<T>().Add(entity);
            _db.SaveChanges();

            _logger.LogExit(nameof(Add));
        }

        public async Task UpdateAsync(T entity)
        {
            _logger.LogEntrance(nameof(UpdateAsync), entity.ToString());

            _db.Entry(entity).State = EntityState.Modified;

            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();

            _logger.LogExit(nameof(UpdateAsync));
        }

        public void Update(T entity)
        {
            _logger.LogEntrance(nameof(Update), entity.ToString());

            _db.Set<T>().Update(entity);
            _db.SaveChanges();

            _logger.LogExit(nameof(Update));
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogEntrance(nameof(DeleteAsync), id.ToString());

            var entity = await GetById(id);
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();

            _logger.LogExit(nameof(DeleteAsync));
        }

        public void Delete(int id)
        {
            _logger.LogEntrance(nameof(Delete), id.ToString());

            T entity = null;
            entity = GetById(id).GetAwaiter().GetResult();
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();

            _logger.LogExit(nameof(Delete));
        }

        public void Detach(T entity)
        {
            _db.Entry(entity).State = EntityState.Detached;
        }

        public void Delete(T entity)
        {
            _logger.LogEntrance(nameof(Delete), entity.ToString());

            try
            {
                _db.Remove<T>(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                throw;
            }
            finally
            {
                _logger.LogExit(nameof(Delete));
            }
        }

    }
}
