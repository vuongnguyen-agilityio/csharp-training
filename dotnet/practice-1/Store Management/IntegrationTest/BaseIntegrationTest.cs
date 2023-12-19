using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace IntegrationTest
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebFactory>
    {
        private readonly IServiceScope _scope;
        protected readonly ISender Sender;
        protected readonly ApplicationDbContext DbContext;
        protected readonly HttpClient Client;
        protected readonly IntegrationTestWebFactory Factory;


        protected BaseIntegrationTest(IntegrationTestWebFactory factory)
        {
            _scope = factory.Services.CreateScope();

            Sender = _scope.ServiceProvider.GetRequiredService<ISender>();

            DbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            Client = factory.CreateClient();

            Factory = factory;
        }
    }
}
