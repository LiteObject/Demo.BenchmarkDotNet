using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Demo.BenchmarkDotNet.Serialization
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }

    /// <summary>
    /// To opt into source generation, define a partial class which derives from 
    /// a new class called JsonSerializerContext, and indicate serializable types 
    /// using a new JsonSerializableAttribute class.
    /// </summary>
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    [JsonSerializable(typeof(List<UserModel>))]
    internal partial class UserModelSourceGenerationContext : JsonSerializerContext
    { }
}
