using System.Threading.Tasks;
using HandiBugTrackerWebClient.Library.Models;

namespace HandiBugTrackerWebClient.Library.Api
{
    public interface ICompBugAllOptionsEndPoint
    {
        Task<CompBugOptionsViewModel> GetAll();
    }
}