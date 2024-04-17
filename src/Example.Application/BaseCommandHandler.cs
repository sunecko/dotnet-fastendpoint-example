using Example.Application.Common;
using FastEndpoints;

namespace Example.Application;

public abstract class BaseCommandHandler<TCommand, TResult> : CommandHandler<TCommand, TResult> where TCommand : class, ICommand<TResult>
{
    protected IContext Context { get; set; }

    protected BaseCommandHandler(IContext context)
    {
        Context = context;
    }

    protected BaseCommandHandler()
    {
        
    }
    public abstract override Task<TResult> ExecuteAsync(TCommand command, CancellationToken ct=default);
}