using Newtonsoft.Json;

namespace Starter.Framework.Extensions
{
    /// <summary>
    /// Extension methods to the Object type
    /// </summary>
    public static class ObjectExtensions
    {
        public static string ToJson(this object data, bool format = false)
        {
            var jss = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

            var formatting = (format) ? Formatting.Indented : Formatting.None;

            return JsonConvert.SerializeObject(data, formatting, jss);
        }
    }
}