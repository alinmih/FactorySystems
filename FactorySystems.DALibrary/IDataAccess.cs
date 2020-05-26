using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorySystems.DALibrary
{
    public interface IDataAccess
    {
        Task<V> SaveDataAsync<U, V>(string procName, U parameters);

        Task<List<T>> GetDataAsync<T, U>(string procName, U parameters);

        Task UpdateDataAsync<U>(string procName, U parameters);

        Task DeleteDataAsync<U>(string procName, U parameters);
    }
}