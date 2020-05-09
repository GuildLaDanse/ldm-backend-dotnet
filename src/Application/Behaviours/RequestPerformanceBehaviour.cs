using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace LaDanse.Application.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private static readonly ILogger Logger = Log.ForContext<TRequest>();

        private readonly Stopwatch _timer;
        
        public RequestPerformanceBehaviour()
        {
            _timer = new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            if (_timer.ElapsedMilliseconds <= 500) return response;
            
            var name = typeof(TRequest).Name;

            // TODO: Add User Details

            Logger.Warning("Hermes Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}", name, _timer.ElapsedMilliseconds, request);

            return response;
        }
    }
}