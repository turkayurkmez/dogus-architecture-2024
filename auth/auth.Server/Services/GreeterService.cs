using auth.Server;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;

namespace auth.Server.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        [Authorize(Roles ="Admin")]
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var httpContext = context.GetHttpContext();
            if (httpContext.User.Identity.IsAuthenticated)
            {
                _logger.LogInformation($"{httpContext.User.Identity.Name} kişisi oturum açıldı");
            }
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
