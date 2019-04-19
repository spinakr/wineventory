using System;
using Microsoft.Extensions.DependencyInjection;
using Wineventory.Domain.Utils;

namespace Wineventory.Web.Utils
{
    public class Messaging
    {

        private readonly IServiceProvider _provider;

        public Messaging(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Result Dispatch(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);


            using (var scope = _provider.CreateScope())
            {
                dynamic handler = scope.ServiceProvider.GetService(handlerType);
                Result result = handler.Handle((dynamic)command);

                return result;
            }
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            using (var scope = _provider.CreateScope())
            {
                dynamic handler = scope.ServiceProvider.GetService(handlerType);
                T result = handler.Handle((dynamic)query);
                return result;
            }
        }
    }
}