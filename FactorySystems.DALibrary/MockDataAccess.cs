using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactorySystems.DALibrary
{
    public class MockDataAccess : IDataAccess
    {
        public Task DeleteDataAsync<U>(string procName, U parameters)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetDataAsync<T, U>(string procName, U parameters)
        {
            throw new NotImplementedException();
        }

        public Task<V> SaveDataAsync<U, V>(string procName, U parameters)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDataAsync<U>(string procName, U parameters)
        {
            throw new NotImplementedException();
        }
    }
}
