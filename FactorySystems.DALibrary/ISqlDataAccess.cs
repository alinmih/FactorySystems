using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactorySystems.DALibrary
{
    public interface ISqlDataAccess
    {
        Task<V> SaveData<U, V>(string procName, U parameters);

        Task<List<T>> LoadData<T,U>(string procName, U parameters);

        //Task<T> LoadDataById<T,U>(string procName, U parameters);

        Task UpdateData<U>(string procName, U parameters);

        Task DeleteData<U>(string procName, U parameters);
    }
}