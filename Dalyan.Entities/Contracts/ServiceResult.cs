using Dalyan.Entities.Interfaces;
using System.Collections.Generic;


namespace Dalyan.Entities.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceResult
    {
        public ServiceResultStates State { get; set; }
        public string Message { get; set; }
        public IEntity PortalTask { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResult<T> : ServiceResult where T : class
    {
        public ServiceResult() { }

        public ServiceResult(T result, string message = "", ServiceResultStates state = ServiceResultStates.SUCCESS)
        {
            Result = result;
            State = state;
            Message = message;
        }

        public ServiceResult(IList<T> results, string message = "", ServiceResultStates state = ServiceResultStates.SUCCESS)
        {
            ResultList = results;
            State = state;
            Message = message;
        }

        public T Result { get; set; }
        public IList<T> ResultList { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ServiceResultStates
    {
        SUCCESS,
        FAIL,
        WARNING,
        INFO,
        ERROR
    }
}
