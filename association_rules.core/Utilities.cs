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
        
        internal static T[][] Make2DArray<T>(IEnumerable<T> input, int height, int width)
        {
            var inputArray = input.ToArray();
            var output = new T[height][];
            for (int i = 0; i < height; i++)
            {
                T[] array= new T[width];
                for (int j = 0; j < width; j++)
                {
                    array[j] = inputArray[i * width + j];
                }
                output[i] = array;
            }
            return output;
        }

        internal static T[,,] ExtractSubarrays<T>(T[,] array, int[][] combin)
        {
            int numRows = array.GetLength(0);
            int numCombin = combin.Count();
            int numCols = combin.ElementAt(0).Count();
            T[,,] subarrays = new T[numRows, numCombin, numCols];
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCombin; j++)
                {
                    for (int k = 0; k < numCols; k++)
                    {
                        subarrays[i, j, k] = array[i, combin[j][k]];
                    }
                }
            }
            return subarrays;
        }

        internal static bool[,] CheckAll(bool[,,] subarrays)
        {
            int numRows = subarrays.GetLength(0);
            int numCombin = subarrays.GetLength(1);
            bool[,] result = new bool[numRows, numCombin];
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCombin; j++)
                {
                    result[i, j] = subarrays[i, j, 0];
                    for (int k = 1; k < subarrays.GetLength(2); k++)
                    {
                        result[i, j] &= subarrays[i, j, k];
                    }
                }
            }
            return result;
        }

        internal static T[][] Subsets<T>(T[] arr, int length)
        {
            var result = new List<T[]>();
            GenerateSubsetsHelper(arr, length, 0, new List<T>(), result);
            return result.ToArray();
        }

        private static void GenerateSubsetsHelper<T>(T[] arr, int length, int index, List<T> currentSubset, List<T[]> result)
        {
            if (length == 0)
            {
                result.Add(currentSubset.ToArray());
                return;
            }
            if (index == arr.Length)
            {
                return;
            }
            currentSubset.Add(arr[index]);
            GenerateSubsetsHelper(arr, length - 1, index + 1, currentSubset, result);
            currentSubset.RemoveAt(currentSubset.Count - 1);
            GenerateSubsetsHelper(arr, length, index + 1, currentSubset, result);
        }
    }
}
