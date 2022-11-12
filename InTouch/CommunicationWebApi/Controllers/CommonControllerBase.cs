using CommunicationWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationWebApi.Controllers
{
    public abstract class CommonControllerBase : ControllerBase
    {
        protected readonly ILogger<ControllerBase> logger;
        protected readonly ServiceBase queryService;

        protected CommonControllerBase(ILogger<ControllerBase> logger, ServiceBase service)
        {
            this.logger = logger;
            queryService = service;
        }
    }
}
