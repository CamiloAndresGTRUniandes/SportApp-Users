namespace Users.Aplication.Behavious ;
using MediatR;
using Microsoft.Extensions.Logging;

    public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger _loger;

        public UnhandledExceptionBehavior(ILogger loger)
        {
            _loger = loger;
        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception e)
            {
                var requestName = typeof(TRequest).Name;

                _loger.LogError(e, "Aplication Request: Sucedio una excepcion para el request {Name} {@Request}", requestName, request);
                throw;
            }
        }
    }
