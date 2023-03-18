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
        public const String msgUSERNAMETAKEN = "Username Taken";
        public const String msgEMAILTAKEN = "Email Taken";

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

        /// <summary>
        /// Method <c>GetUsers</c> returns a list of all users from the database asynchronously
        /// <br></br>
        /// Author(s): Gabriel Cepleanu
        /// </summary>
        /// <returns>
        /// List of UserModel objects
        /// </returns>
        public async Task<List<UserModel>> GetUsers()
        {
            // get list of documents from the collection
            var documents = await collection.Find(new BsonDocument()).ToListAsync();

            // deserialize each document into UserModel
            var users = documents.Select(doc => BsonSerializer.Deserialize<UserModel>(doc)).ToList();

            return users;
        }

        /// <summary>
        /// Authenticates a given UserModel by username and password using the database asynchronously
        /// <br></br>
        /// Author(s): Gabriel Cepleanu
        /// </summary>
        /// <param name="user">User information</param>
        /// <returns>
        /// Status
        /// </returns>
        public async Task<bool> Login(UserModel user)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("username", user.username)
                & Builders<BsonDocument>.Filter.Eq("password", user.password);

            var documents = await collection.Find(filter).ToListAsync();

            return documents.FirstOrDefault() != null;
        }

        /// <summary>
        /// Registers a new user and saves the information to the database asynchronously
        /// <br></br>
        /// Author(s): Charles Davis
        /// </summary>
        /// <param name="user">New User</param>
        /// <returns>
        /// Status String
        /// </returns>
        public async Task<string> RegisterUser(UserModel user)
        {
            // Check for existing username
            if(await this.DoesUserExistByUsername(user.username))
            {
                // return username taken status
                return msgUSERNAMETAKEN;
            }
            // Check for existing email
            if(await this.DoesUserExistByEmail(user.email))
            {
                // return email taken status
                return msgEMAILTAKEN;
            }
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
            // return success status
            return msgSUCCESS;
        }

        /// <summary>
        /// Does the user exist by username.
        /// </summary>
        /// <param name="username">The username to search for.</param>
        /// <returns></returns>
        public async Task<bool> DoesUserExistByUsername(String username)
        {
            // Create filter for paramater username
            var filter = Builders<BsonDocument>.Filter.Eq("username", username);
            // Find users using the filter
            var documents = await this.collection.Find(filter).ToListAsync();
            return documents.FirstOrDefault() != null;
        }

        /// <summary>
        /// Does the user exist by email.
        /// </summary>
        /// <param name="email">The email to search for.</param>
        /// <returns></returns>
        public async Task<bool> DoesUserExistByEmail(String email)
        {
            // Create filter for paramater email
            var filter = Builders<BsonDocument>.Filter.Eq("email", email);
            // Find users using the filter
            var documents = await this.collection.Find(filter).ToListAsync();
            return documents.FirstOrDefault() != null;
        }
    }
}

