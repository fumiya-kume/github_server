using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public interface IGithubClient
    {
        Task<string> GetAccessTokenAsync(string code);
    }
}