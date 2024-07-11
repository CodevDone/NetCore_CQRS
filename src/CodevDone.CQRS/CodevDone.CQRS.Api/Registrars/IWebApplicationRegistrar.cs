
using static CodevDone.CQRS.Api.Extensions.RegistrarExtensions;

namespace CodevDone.CQRS.Api.Registrars
{
    public interface IWebApplicationRegistrar : IRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app);
    }
}