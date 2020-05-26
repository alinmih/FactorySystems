using System;
using System.Collections.Generic;

namespace FactorySystems.CommonLibrary.Adapters
{
    public class Adapter : IAdapter
    {
        public List<T> ConvertToTListFromU<T, U>(List<U> items)
        {
            var convertedList = new List<T>();
            foreach (var item in items)
            {
                convertedList.Add(ConvertToTFromU<T, U>(item));
            }
            return convertedList;
        }

        public T ConvertToTFromU<T, U>(U model)
        {
            return (T)Activator.CreateInstance(typeof(T), model);
        }

    }
}
