using System.Text.Json.Serialization;
using System.Text.Json;

namespace WebApi_Carsharing_EP3.Session
{
    public static class SessionService
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };
            session.SetString(key, JsonSerializer.Serialize(value, options));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };
            var value = session.GetString(key);
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value, options);
        }
    }
}
