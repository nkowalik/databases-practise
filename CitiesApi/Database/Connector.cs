using MongoDB.Driver;

namespace CitiesApi.Database
{
    public class Connector
    {
        static readonly string ConnectionString = "mongodb://localhost";

        public static MongoClient Connect()
        {
            return new MongoClient(ConnectionString);
        }
    }
}
