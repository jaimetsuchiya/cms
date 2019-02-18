using cms.web.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected string _dbName;
        protected string _collectionName;
        protected string _connectionString;

        public BaseRepository(string dbName, string collectionName)
        {
            _dbName = dbName;
            _dbName += ".db";
            _connectionString = $@"Filename={_dbName}; Mode=Exclusive";//Mode=Exclusive
            _collectionName = collectionName;
        }

        public BaseRepository(string dbName, string collectionName, DateTime version)
        {
            _dbName = dbName;
            _dbName += "_";
            _dbName += version.ToString("yyyy-MM-dd");
            _dbName += ".db";
            _connectionString = $@"Filename={_dbName}; Mode=Exclusive";//Mode=Exclusive

            _collectionName = collectionName;
        }

        public T GetSingle(Guid id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                // Get customer collection
                var collection = db.GetCollection<T>(_collectionName);
                return collection.FindById(id);
            }
        }

        public List<T> GetAll()
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                // Get customer collection
                var collection = db.GetCollection<T>(_collectionName);
                return collection.FindAll().ToList();
            }
        }

        public void Save(ref T model)
        {
            if (model.Id == Guid.Empty)
            {

                model.Id = Guid.NewGuid();
                model.CreatedAt = DateTime.Now;

                using (var db = new LiteDatabase(_connectionString))
                {
                    var collection = db.GetCollection<T>(_collectionName);
                    collection.Insert(model);
                }
            }
            else
            {
                using (var db = new LiteDatabase(_connectionString))
                {
                    var collection = db.GetCollection<T>(_collectionName);
                    collection.Update(model);
                }
            }
        }

        public void Delete(Guid id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                // Get customer collection
                var collection = db.GetCollection<T>(_collectionName);
                collection.Delete(id);
            }
        }

    }
}
