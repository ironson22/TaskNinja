using System;
using TaskNinja.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace TaskNinja.Services
{
    /// <summary>
    /// Class <c>UsersDAO</c> provides a service for getting, creating, and authenticating users with the MongoDB database.
    /// <br></br>
    /// Author(s): Gabriel Cepleanu, Charles Davis
    /// <br></br>
    /// Version: 0.1
    /// </summary>
	public class UsersDAO : IUsersDAO
	{
        // Task<String> Responses
        public const String msgSUCCESS = "Success";
        public const String msgFAILURE = "Failure";

        // INSERT MONGODB CONNECTION STRING HERE
        private const string connectionString = "";
        private MongoClient mongoClient;
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersDAO"/> class.
        /// </summary>
        public UsersDAO()
		{
            this.mongoClient = new MongoClient(connectionString);
            this.database = mongoClient.GetDatabase("Task-Ninja");
            this.collection = database.GetCollection<BsonDocument>("User");
        }
        public Task<UserModel> GetUserByID(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> GetUsers()
        {
            // get list of documents from the collection
            var documents = await collection.Find(new BsonDocument()).ToListAsync();

            // deserialize each document into UserModel
            var users = documents.Select(doc => BsonSerializer.Deserialize<UserModel>(doc)).ToList();

            return users;
        }

        public async Task<bool> Login(UserModel user)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("username", user.username)
                & Builders<BsonDocument>.Filter.Eq("password", user.password);

            var documents = await collection.Find(filter).ToListAsync();

            return documents.FirstOrDefault() != null;
        }

        public async Task<string> RegisterUser(UserModel user)
        {
            // TODO: Check for existing username/email
            // Converts UserModel to BsonDocument
            var document = new BsonDocument
            {
                {"firstName",  user.firstName},
                {"lastName", user.lastName },
                {"email", user.email},
                {"username", user.username},
                {"password", user.password}
            };
            // Inserts user data BsonDocuemtn into table
            await this.collection.InsertOneAsync(document);
            return msgSUCCESS;
        }
    }
}

