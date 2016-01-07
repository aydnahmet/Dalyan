using Dalyan.Entities.Models;
using SimpleInjector;
using System;

namespace Dalyan.Domain
{
    public class Mediator : IMediator
    {
        private readonly Container _container;
        
        public Mediator(Container container)
        {
            _container = container;
        }
        public TResult Proccess<TResult>(IQuery<TResult> query)
        {
            try
            {
                var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
                dynamic handler = _container.GetInstance(handlerType);
                return handler.Handler((dynamic)query);
            }
            catch (ExceptionLog ex)
            {
                throw ex;
            }
        }
    }
}
