using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyExam.Services.ApiService
{
    public interface IRandomUserApi
    {
        [Get("/api")]
        Task <HttpResponseMessage> GetUser([AliasAs("results")] int users);
    }
}
