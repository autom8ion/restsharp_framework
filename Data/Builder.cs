using Newtonsoft.Json.Linq;

namespace RESTSharpFW.Data
{
    public class Builder
    {
        public static JObject ConvertBuilderToJObject(object jobj)
        {
            return (JObject)JToken.FromObject(jobj);
        }

    }
}
