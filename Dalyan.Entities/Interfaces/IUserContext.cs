using Dalyan.Entities.Models;

namespace Dalyan.Entities.Interfaces
{
    public interface IUserContext
    {
        CurrentUser CurrentUserIdentity { get; }
        bool IsLogged { get; }
    }
}