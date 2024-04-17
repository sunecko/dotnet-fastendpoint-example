using Example.Application.Common;
using FastEndpoints;

namespace Example.Application;

public abstract class BaseQueryHandler<TQuery, TResult> : CommandHandler<TQuery, TResult> where TQuery : class, ICommand<TResult>
{
    protected IContext Context { get; set; }

    protected BaseQueryHandler(IContext context)
    {
        Context = context;
    }

    protected BaseQueryHandler()
    {
        
    }
    public abstract override Task<TResult> ExecuteAsync(TQuery command, CancellationToken ct=default);
}