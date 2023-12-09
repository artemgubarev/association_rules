using System;
using System.Collections.Generic;
using System.Linq;

namespace association_rules.core
{
    internal static class Utilities
    {
        /// <summary>
        /// Получить индексы элементов которые необходимо удалить
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">Коллекция</param>
        /// <param name="predicate">Предикат условие</param>
        /// <returns>Коллекция индексов элементов которые не соотвествуют условию predicate</returns>
        internal static IEnumerable<int> GetExcludedIndexes<T>(IEnumerable<T> collection, Func<T,bool> predicate)
        {
            return collection.Select((value, index) => new { Index = index, Value = value })
                .Where(item => predicate(item.Value))
                .Select(item => item.Index);
        }

        /// <summary>
        /// Удалить элементы из коллекции по указанным индексам
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">Коллекция</param>
        /// <param name="indexes">Индексы элементов которые необходимо удалить</param>
        /// <returns>Коллекция элементов из которых исключены элементы по индексам indexes</returns>
        internal static IEnumerable<T> RemoveElementsByIndex<T>(IEnumerable<T> collection, IEnumerable<int> indexes)
        {
            var list = collection.ToList();
            foreach (var index  in indexes.OrderByDescending(e => e))
            {
                list.RemoveAt(index);
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        internal static IEnumerable<bool> GetMask<T>(IEnumerable<T> collection, Func<T, bool> predicate)
        {
            bool[] mask = new bool[collection.Count()];
            int count = 0;
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    mask[count] = true;
                }
                count++;
            }
            return mask;
        }

    }
}
