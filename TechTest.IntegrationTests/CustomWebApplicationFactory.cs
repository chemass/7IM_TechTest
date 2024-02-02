using Microsoft.AspNetCore.Mvc.Testing;

namespace _7IM_IntegrationTests
{
    public class CustomWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // here we would configure any services for testing if it was a real application
            });

            builder.UseEnvironment("Development");
        }
    }
}
