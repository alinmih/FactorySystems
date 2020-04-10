using System.Collections.Generic;

namespace FactorySystems.CommonLibrary.Adapters
{
    public interface IAdapter
    {
        T Convert<T, U>(U model);
        List<T> ConvertToList<T, U>(List<U> items);
    }
}