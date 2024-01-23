using MediatR;
namespace PipelineBehaviors.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger) :
                            IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("Operação iniciada");

        var result = await next();

        logger.LogInformation("Operação finalizada");

        return result;
    }
}