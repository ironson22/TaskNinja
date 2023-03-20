using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using TaskNinja.Models;

namespace TaskNinja.Services
{
    /// <summary>
    /// Class <c>TasksDAO</c> provides the implementation for managing tasks in a MongoDB database.
    /// <br></br>
    /// Author(s): Gabriel Cepleanu
    /// <br></br>
    /// Version: 0.1
    /// </summary>
	public class TasksDAO : ITasksDAO
	{
        // INSERT MONGODB CONNECTION STRING HERE
        private const string connectionString = "";
        private MongoClient mongoClient;
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> collection;

        public TasksDAO()
		{
            this.mongoClient = new MongoClient(connectionString);
            this.database = mongoClient.GetDatabase("Task-Ninja");
            this.collection = database.GetCollection<BsonDocument>("Task");
        }

        public Task<bool> AddTask(TaskModel task)
        {
            return null;
        }

        public Task<bool> DeleteTask(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            // get list of documents from the collection
            var documents = await collection.Find(new BsonDocument()).ToListAsync();

            // deserialize each document into TaskModel
            var tasks = documents.Select(doc => BsonSerializer.Deserialize<TaskModel>(doc)).ToList();

            return tasks;
        }

        public Task<TaskModel> GetTask(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TaskModel>> GetUserTasks(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTask(TaskModel updated)
        {
            throw new NotImplementedException();
        }
    }
}

