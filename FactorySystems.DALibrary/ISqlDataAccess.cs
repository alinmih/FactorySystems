using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorySystems.DALibrary
{
    public interface ISqlDataAccess
    {
        Task<V> SaveDataAsync<U, V>(string procName, U parameters);

        Task<List<T>> LoadDataAsync<T, U>(string procName, U parameters);

        Task UpdateDataAsync<U>(string procName, U parameters);

        Task DeleteDataAsync<U>(string procName, U parameters);
    }
}