using MediatR;
using PipelineBehaviors;
using PipelineBehaviors.Behaviors;
using PipelineBehaviors.Commands;
using PipelineBehaviors.Entities;
using PipelineBehaviors.Repositories;
using PipelineBehaviors.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblyContaining<Program>();

    //Colocar as pipeline em ordem de execução
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
    config.AddBehavior<IPipelineBehavior<EnviarPedidoCommand, CommandResult<Pedido>>,
    EnviarPedidoValidationBehavior<EnviarPedidoCommand, CommandResult<Pedido>>>();
});

builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<ICepServices, CepServices>();

var host = builder.Build();
host.Run();
