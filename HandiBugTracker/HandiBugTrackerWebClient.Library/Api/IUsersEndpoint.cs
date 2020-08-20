using System.Collections.Generic;
using System.Threading.Tasks;
using HandiBugTrackerWebClient.Library.Models;

namespace HandiBugTrackerWebClient.Library.Api
{
    public interface IUsersEndpoint
    {
        Task<IEnumerable<UserViewModel>> GetAll();
    }
}