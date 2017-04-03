using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
 
namespace TestMongoDB.Models
{
    public class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;
 
        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("UserDB");      
        }
 
        public IEnumerable<WUser> GetUsers()
        {
            return _db.GetCollection<WUser>("Users").FindAll();
        }
 
 
        public WUser GetUser(ObjectId id)
        {
            var res = Query<WUser>.EQ(p=>p.Id,id);
            return _db.GetCollection<WUser>("Users").FindOne(res);
        }
 
        public WUser Create(WUser p)
        {
            _db.GetCollection<WUser>("Users").Save(p);
            return p;
        }
 
        public void Update(ObjectId id,WUser p)
        {
            p.Id = id;
            var res = Query<WUser>.EQ(pd => pd.Id,id);
            var operation = Update<WUser>.Replace(p);
            _db.GetCollection<WUser>("Users").Update(res,operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<WUser>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<WUser>("Users").Remove(res);
        }
    }
}