using MongoDB.Bson;
using System;
namespace TaskNinja.Services
{
    /// <summary>
    /// Handles the interaction with the User Session.
    /// <br></br>
    /// Author(s): Charles Davis
    /// </summary>
    public static class UserSessionHandler
	{
        /// <summary>
        /// Sets the uid user session value.
        /// </summary>
        /// <param name="session">The session to place the uid.</param>
        /// <param name="id">The user identifier to be placed in the user session.</param>
        public static void SetUID(this ISession session, ObjectId id)
		{
			SessionHandler.Set<ObjectId>(session, SessionHandler.keyUID, id);
		}

        /// <summary>
        /// Gets the uid from the session.
        /// </summary>
        /// <param name="session">The session to pull the uid from.</param>
        /// <returns>ObjectId uid found in session</returns>
        /// <exception cref="System.IO.InvalidDataException">ObjectId is default value.</exception>
        public static ObjectId GetUID(this ISession session) 
        { 
            // Get UID from session
            var res = SessionHandler.Get<ObjectId>(session, SessionHandler.keyUID);
            // Check for non default objectID
            if(res == new ObjectId())
            {
                // Throw exception
                throw new InvalidDataException("ObjectId is default value.");
            }
            // Return resulting objectID
            return res;
        }

	}
}
