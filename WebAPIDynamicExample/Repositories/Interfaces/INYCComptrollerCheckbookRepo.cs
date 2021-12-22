using System.Threading.Tasks;

namespace WebAPIDynamicExample.Repositories.Interfaces
{
    public interface INYCComptrollerCheckbookRepo
    {
        Task<string> GetSpendingDataAsync(string body);
    }
}
