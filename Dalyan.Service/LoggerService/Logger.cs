using Dalyan.Entities.Interfaces;
using Dalyan.Entities.Models;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalyan.Service.LoggerService
{
    public static class Logger
    {
        public static void Log(Container _container, ExceptionLog ex)
        {
            ILog logger = _container.GetInstance<ILog>();
            IUserContext currentUser = _container.GetInstance<IUserContext>();
            logger.Logger(ex.LogType, ex.LogLevel, ex.Ex, ex.ExMessage, currentUser.CurrentUserIdentity);
        }
    }
}
