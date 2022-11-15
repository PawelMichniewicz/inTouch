using Microsoft.AspNetCore.Mvc;

namespace CommunicationWebApi.Controllers
{
    public abstract class CommonControllerBase<T> : ControllerBase
    {
        protected readonly ILogger<ControllerBase> logger;
        protected readonly T service;

        protected CommonControllerBase(ILogger<ControllerBase> logger, T service)
        {
            this.logger = logger;
            this.service = service;
        }
    }
}
