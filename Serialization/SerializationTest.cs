using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Text.Json;

namespace Demo.BenchmarkDotNet.Serialization
{

    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
    [MemoryDiagnoser]
    [RankColumn]
    public class SerializationTest
    {
        private List<UserModel> usersForSrcGenMethod;
        private List<UserModel> users;

        public void SetupData()
        {
            users = new() {
                new UserModel { Id = 1, Email = "test@email.com",
                    Address1 = "123 Road", Address2 = "House #456", City = "My City",
                    PostalCode = "75000", State = "Texas", Country = "USA"}
            };

            usersForSrcGenMethod = new() {
                new UserModel { Id = 1, Email = "test@email.com",
                    Address1 = "123 Road", Address2 = "House #456", City = "My City",
                    PostalCode = "75000", State = "Texas", Country = "USA"}
            };
        }

        [Benchmark]
        public List<UserModel> WithSourceGen()
        {

            byte[] utf8Json = JsonSerializer.SerializeToUtf8Bytes(usersForSrcGenMethod, UserModelSourceGenerationContext.Default.ListUserModel);
            List<UserModel> result = JsonSerializer.Deserialize(utf8Json, UserModelSourceGenerationContext.Default.ListUserModel);
            return result;
        }

        [Benchmark]
        public List<UserModel> WithourSourceGen()
        {
            string json = JsonSerializer.Serialize(users);
            List<UserModel> result = JsonSerializer.Deserialize<List<UserModel>>(json);
            return result;
        }
    }
}
