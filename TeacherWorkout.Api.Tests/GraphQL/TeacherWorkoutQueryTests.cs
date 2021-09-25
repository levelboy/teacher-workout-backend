using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.AspNetCore.Mvc.Testing;
using TeacherWorkout.Api.GraphQL.Types;
using Xunit;

namespace TeacherWorkout.Api.Tests.GraphQL
{
    public class TeacherWorkoutQueryTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TeacherWorkoutQueryTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Fact]
        public async Task Test()
        {
            HttpClient client = _factory.CreateClient();
            var graphClient = new GraphQLHttpClient(new GraphQLHttpClientOptions { EndPoint = new Uri("http://localhost/graphql") }, new SystemTextJsonSerializer(), client);
            
            var input = new GraphQLRequest 
            { 
                Query = @"{ lessons(themeId: ""1"") { items { title } } }" 
            };

            var graphQLResponse = await graphClient.SendQueryAsync<LessonType>(input);

            var personName = graphQLResponse.Data;
        }
    }
}