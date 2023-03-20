using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace TaskNinja.Services
{
    /// <summary>
    /// Handles the interactions with the session.
    /// <br></br>
    /// Author(s): Charles Davis
    /// </summary>
    public static class SessionHandler
	{
        public const String keyUID = "uid";

        /// <summary>
        /// Sets the value to the key in the session.
        /// </summary>
        /// <typeparam name="T">The variable type to set</typeparam>
        /// <param name="session">The session to set a value to.</param>
        /// <param name="key">The key to assing a value to in the session.</param>
        /// <param name="value">The value to set to the key in the session.</param>
        /// <example>SessionHandler.Set<string>(HttpContext.Session, SessionHandler.keyUID, uid);</example>
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        /// <summary>
        /// Gets the specified key value from the session.
        /// </summary>
        /// <typeparam name="T">The variable type to get</typeparam>
        /// <param name="session">The session to get the value from.</param>
        /// <param name="key">The key of the value in the session.</param>
        /// <returns></returns>
        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
