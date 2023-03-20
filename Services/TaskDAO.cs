using System;
using TaskNinja.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace TaskNinja.Services
{
    public class TaskDAO : ITaskDAO
    {
        // Task<String> Responses
        public const String msgSUCCESS = "Success";
        public const String msgFAILURE = "Failure";

        // INSERT MONGODB CONNECTION STRING HERE
        private string connectionString = Environment.GetEnvironmentVariable("MongoDB ConString");
        private MongoClient mongoClient;
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> collection;

        ///Create new instance of Task
        public TaskDAO()
        {
            this.mongoClient = new MongoClient(connectionString);
            this.database = mongoClient.GetDatabase("Task-Ninja");
            this.collection = database.GetCollection<BsonDocument>("Task");
        }
        /// <summary>
        /// This method will fetch all the task with a matching userID and will return the as a UserModel Object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TaskModel> GetTaskById(string id)
        {
            var filter = new BsonDocument { { "userID", id } };
            //Get the document from the collection using filter based on id
            var documents = await collection.FindOneAsync(filter);
            // deserialize each document into TaskModel
            var task = documents.Select(x => x.Value).ToList();
            return task;
        }
    }
}
