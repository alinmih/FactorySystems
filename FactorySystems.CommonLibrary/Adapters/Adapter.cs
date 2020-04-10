using System;
using System.Collections.Generic;

namespace FactorySystems.CommonLibrary.Adapters
{
    public class Adapter : IAdapter
    {
        public List<T> ConvertToList<T, U>(List<U> items)
        {
            var convertedList = new List<T>();
            foreach (var item in items)
            {
                convertedList.Add(Convert<T, U>(item));
            }
            return convertedList;
        }

        public T Convert<T, U>(U model)
        {
            return (T)Activator.CreateInstance(typeof(T), model);
        }

    }
}
