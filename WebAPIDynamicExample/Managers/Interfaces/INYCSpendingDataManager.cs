using System.Threading.Tasks;

namespace WebAPIDynamicExample.Managers.Interfaces
{
    public interface INYCSpendingDataManager
    {
        Task<string> GetSpendingData();
    }
}
