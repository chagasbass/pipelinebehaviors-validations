namespace PipelineBehaviors.Validations;

//public sealed class EnviarPedidoCommandValidator : AbstractValidator<EnviarPedidoCommand>
//{
//    public EnviarPedidoCommandValidator(EstadosEntrega estadosEntrega)
//    {
//        RuleFor(command => command.PedidoId)
//               .NotEmpty()
//               .WithMessage("O identificador do Pedido não pode ser vazio");

//        RuleFor(command => command.Cep)
//               .NotEmpty()
//               .WithMessage("O cep do Pedido não pode ser vazio");

//        RuleFor(command => command.Estado)
//               .Must(estado => estadosEntrega.Equals(estado))
//               .WithMessage("O identificador do Pedido não pode ser vazio");
//    }
//}
