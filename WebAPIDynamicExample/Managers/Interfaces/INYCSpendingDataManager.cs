using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIDynamicExample.Models;

namespace WebAPIDynamicExample.Managers.Interfaces
{
    public interface INYCSpendingDataManager
    {
        Task<List<AccountingData>> GetExceedFunding();
    }
}
