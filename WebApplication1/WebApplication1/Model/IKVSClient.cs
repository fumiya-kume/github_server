using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace WebApplication1.Model
{
    public interface IKVSClient
    {
        Task<T> LoadWithKeyAsync<T>(string tableName, string key) where T : ITableEntity;
        Task SaveAsync(string tableName, string key, ITableEntity value);
    }
}