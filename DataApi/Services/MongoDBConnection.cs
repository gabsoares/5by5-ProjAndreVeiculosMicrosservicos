using Models;
using MongoDB.Driver;

namespace DataApi.Services
{
    public class MongoDBConnection
    {
        private static MongoDBConnection _instance;
        public MongoClient client { get; private set; }
        private MongoDBConnection()
        {
            client = new MongoClient("mongodb://root:Mongo%402024%23@localhost:27017/");
        }
        public static MongoDBConnection GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MongoDBConnection();
            }
            return _instance;
        }
    }
}
