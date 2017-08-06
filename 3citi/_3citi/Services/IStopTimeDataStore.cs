using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3citi.Services
{
    public interface IStopTimeDataStore<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(int route,int i,bool forceRefresh = false);

        Task InitializeAsync(int route,int i);

        void Clear();
    }
}