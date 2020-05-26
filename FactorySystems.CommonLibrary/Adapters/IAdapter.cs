using System.Collections.Generic;

namespace FactorySystems.CommonLibrary.Adapters
{
    public interface IAdapter
    {
        T ConvertToTFromU<T, U>(U model);
        List<T> ConvertToTListFromU<T, U>(List<U> items);
    }
}