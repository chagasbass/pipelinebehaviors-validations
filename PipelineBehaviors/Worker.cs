using MediatR;
using PipelineBehaviors.Commands;

namespace PipelineBehaviors
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMediator _mediator;

        public Worker(ILogger<Worker> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }

                var command = new EnviarPedidoCommand(Guid.Empty, string.Empty, string.Empty);

                await _mediator.Send(command);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
