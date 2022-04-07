
using static CodevDone.CQRS.Api.Extensions.RegistrarExtensions;

namespace CodevDone.CQRS.Api.Registrars
{
    public interface IWebApplicationBuilderRegistrar : IRegistrar
    {
        void RegisterServices(WebApplicationBuilder builder);
    }
}