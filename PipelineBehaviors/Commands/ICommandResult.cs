namespace PipelineBehaviors.Commands;

public interface ICommandResult
{
}

public class CommandResult<T>
{
    public T? Data { get; set; }
    public object? Notifications { get; set; }
    public string? Mensagem { get; set; }
    public bool Sucesso { get; set; }

    public CommandResult() { }

    public CommandResult(string? mensagem, bool sucesso = false)
    {
        Mensagem = mensagem;
        Sucesso = sucesso;
    }

    public CommandResult(CommandResult<T> commandResult)
    {
        Data = commandResult.Data;
        Notifications = commandResult.Notifications;
        Mensagem = commandResult.Mensagem;
        Sucesso = commandResult.Sucesso;
    }

    public CommandResult<T> AddNotifications(object? notifications)
    {
        Notifications = notifications;

        return this;
    }

    public CommandResult<T> AddData(T? data)
    {
        Data = data;

        return this;
    }
}