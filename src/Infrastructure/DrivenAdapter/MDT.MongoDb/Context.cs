using MongoDB.Driver;
using MDT.MongoDb.Entities;

namespace MDT.MongoDb
{
    public class Context
    {
        private readonly IMongoDatabase database;
        

        public Context(string connectionString, string databaseName)
        {
            database = new MongoClient(connectionString).GetDatabase(databaseName);
        }


        internal IMongoCollection<EmpleadoEntity> Empleados
        {
            get
            {
                return database.GetCollection<EmpleadoEntity>("employee");
            }
        }
    }
}