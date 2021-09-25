using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
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
            var client = _factory.CreateClient();
            
            var response = await client.GetAsync("/app/graphiql");
            
            response.EnsureSuccessStatusCode(); 
        }
    }
}