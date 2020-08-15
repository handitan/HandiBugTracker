using System.Net.Http;
using System.Threading.Tasks;

namespace HandiBugTrackerWebClient.Library.Api
{
    public interface IAPIHelper
    {
        Task<bool> VerifyLogin(string pLoginName, string pPassword);
    }
}