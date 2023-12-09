using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace association_rules.core
{
    internal class Apriori
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputData"></param>
        /// <param name="power"></param>
        /// <param name="transactColIndex"></param>
        /// <param name="tItemColIndex"></param>
        /// <param name="minSupport"></param>
        /// <param name="maxSupport"></param>
        /// <param name="minConfidence"></param>
        /// <param name="maxConfidence"></param>
        /// <param name="colHeaders"></param>
        internal static void Rules(
            IEnumerable<string[]> inputData, out int power,
            int transactColIndex = 0, int tItemColIndex = 1,
            double minSupport = 0.5, double maxSupport = 1.0,
            double minConfidence = 0.5, double maxConfidence = 1.0,
            bool colHeaders = false)
        {
            power = 0;
            if (colHeaders)
            {
                inputData = inputData.Skip(1);
            }

            var encoder = new TransactionEncoder();
            bool[,] encodeArray = encoder.Transform(inputData, transactColIndex, tItemColIndex);
            string[] itemSet = encoder.ItemSet;

            

            var supportDict =
                GetSupportAllCombin(encodeArray,itemSet, transactColIndex, tItemColIndex, minSupport, maxSupport);

            var rules = new List<object[]>();

            foreach (var item in supportDict)
            {
                var array = GetArrayFromKey(item.Key);
                if (array.Count() == 1)
                    continue;
                for (int c = 1; c < array.Count(); c++)
                {
                    var subsets = GenerateSubsets(array.ToArray(), c);
                    
                    foreach (var subset in subsets)
                    {
                        var condition = array;
                        var consequence = subset.ToArray();
                        var aC = array.Except(subset);
                        string conditionKey = GetKeyFromArray(condition);
                        string consequenceKey = GetKeyFromArray(consequence);
                        string aCKey = GetKeyFromArray(aC);
                        double conditionSupp = supportDict[conditionKey];
                        double consequenceSupp = supportDict[consequenceKey];
                        double aCSupp = supportDict[aCKey];
                        double support = conditionSupp;
                        double confidence = conditionSupp / consequenceSupp;
                        double lift = confidence / aCSupp;
                        var rule = BuildRule(itemSet, condition.Except(subset).ToArray(), consequence.ToArray(),
                            support, confidence, lift);
                        rules.Add(rule);
                    }
                }
            }
        }

        private static object[] BuildRule
        (
            string[] itemSet, 
            int[] condition, int[] consequence, 
            double support,
            double confidence, double lift
            )
        {
            string conditionStr = string.Empty;
            string consequenceStr = string.Empty;
            foreach (var index   in condition)
            {
                conditionStr += itemSet[index] + ",";
            }
            foreach (var index in consequence)
            {
                consequenceStr += itemSet[index] + ",";
            }
            conditionStr = conditionStr.Remove(conditionStr.Length - 1, 1);
            consequenceStr = consequenceStr.Remove(consequenceStr.Length - 1, 1);

            double suppPercentage = ConvertToPercentages(support);
            double confidencePercentage = ConvertToPercentages(confidence);
            object[] result =
            {
                conditionStr, consequenceStr,
                suppPercentage, confidencePercentage,
                lift
            };
            return result;
        }

        private static double ConvertToPercentages(double value)
        {
            return value * 100;
        }

        static List<List<int>> GenerateSubsets(int[] arr, int length)
        {
            var result = new List<List<int>>();
            GenerateSubsetsHelper(arr, length, 0, new List<int>(), result);
            return result;
        }

        static void GenerateSubsetsHelper(int[] arr, int length, int index, List<int> currentSubset, List<List<int>> result)
        {
            if (length == 0)
            {
                result.Add(new List<int>(currentSubset));
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


        private static Dictionary<string, double> GetSupportAllCombin(
            bool[,] encodeArray, string[] itemSet,
            int transactColIndex = 0, int tItemColIndex = 1,
            double minSupport = 0.5, double maxSupport = 1.0)
        {
           
            double[] support = Supports(encodeArray);
            int[] indexes = Enumerable.Range(0, itemSet.Length).ToArray();

            var excludeIndexes =
                Utilities.GetExcludedIndexes(support, x => x <= minSupport || x >= maxSupport);
            var supportsList = new List<IEnumerable<double>>
            {
                Utilities.RemoveElementsByIndex(support, excludeIndexes)
            };
            var items = Utilities.RemoveElementsByIndex(indexes, excludeIndexes);
            var items2D = Make2DArray(items, items.Count(), width: 1);
            var itemSetList = new List<IEnumerable<IEnumerable<int>>>();
            itemSetList.Add(items2D);

            int maxItemset = 1;
            while (true)
            {
                int nextMaxItemset = maxItemset + 1;
                var combinations
                    = GenerateNewCombinations(itemSetList[maxItemset - 1]);
                if (combinations.Count() == 0)
                {
                    break;
                }
                var extractSubarrays = ExtractSubarrays(encodeArray, combinations);
                var bools = CheckAll(extractSubarrays);
                support = Supports(bools);
                excludeIndexes =
                    Utilities.GetExcludedIndexes(support, x => x <= minSupport || x >= maxSupport);
                bool any = support.Length != excludeIndexes.Count();
                if (any)
                {
                    supportsList.Add(Utilities.RemoveElementsByIndex(support, excludeIndexes));
                    items2D = Utilities.RemoveElementsByIndex(combinations, excludeIndexes);
                    itemSetList.Add(items2D);
                    maxItemset = nextMaxItemset;
                }
                else
                {
                    break;
                }
            }
            var supportDict = new Dictionary<string, double>();
            for (int i = 0; i < itemSetList.Count; i++)
            {
                for (int j = 0; j < itemSetList[i].Count(); j++)
                {
                    string key = GetKeyFromArray(itemSetList[i].ElementAt(j));
                    supportDict.Add(key, supportsList[i].ElementAt(j));
                }
            }
            return supportDict;
        }

        private static string GetKeyFromArray(IEnumerable<int> array)
        {
            string key = string.Empty;
            foreach (int i in array)
            {
                key += i + ",";
            }
            key = key.Remove(key.Length - 1, 1);
            return key;
        }

        private static IEnumerable<int> GetArrayFromKey(string key)
        {
            string[] elements = key.Split(',');
            int[] array = new int[elements.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(elements[i]);
            }
            return array;
        }

        private static bool[,] CheckAll(bool[,,] subarrays)
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

        private static bool[,,] ExtractSubarrays(bool[,] X, IEnumerable<IEnumerable<int>> combin)
        {
            int numRows = X.GetLength(0);
            int numCombin = combin.Count();
            int numCols = combin.ElementAt(0).Count();

            bool[,,] subarrays = new bool[numRows, numCombin, numCols];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCombin; j++)
                {
                    for (int k = 0; k < numCols; k++)
                    {
                        subarrays[i, j, k] = X[i, combin.ElementAt(j).ElementAt(k)];
                    }
                }
            }

            return subarrays;
        }

        private static List<List<int>> ToList2D(IEnumerable<IEnumerable<int>> array)
        {
            var result = new List<List<int>>();

            for (int i = 0; i < array.Count(); i++)
            {
                var list = new List<int>();
                for (int j = 0; j < array.ElementAt(0).Count(); j++)
                {
                    list.Add(array.ElementAt(i).ElementAt(j));
                }
                result.Add(list);
            }

            return result;
        }

        private static double[] Supports(bool[,] encodeArray)
        {
            int transactionsNum = encodeArray.GetLength(0);
            int itemsetNum = encodeArray.GetLength(1);
            var supports = new double[itemsetNum];
            for (int i = 0; i < itemsetNum; i++)
            {
                int count = 0;
                for (int j = 0; j < transactionsNum; j++)
                {
                    if (encodeArray[j,i])
                    {
                        count++;
                    }
                }
                double support = ((double)count / (double)transactionsNum);
                supports[i] = support;
            }
            return supports.ToArray();
        }

        private static IEnumerable<IEnumerable<int>> GenerateNewCombinations(IEnumerable<IEnumerable<int>> oldCombinations)
        {
            var itemsTypesInPreviousStep = oldCombinations.SelectMany(combination => combination).Distinct().ToList();
            var newCombinations = new List<IEnumerable<int>>();
            foreach (var oldCombination in oldCombinations)
            {
                int maxCombination = oldCombination.Last();
                var validItems = itemsTypesInPreviousStep.Where(item => item > maxCombination).ToList();
                var oldTuple = new List<int>(oldCombination);
                foreach (int item in validItems)
                {
                    newCombinations.Add(oldTuple.Concat(new List<int> { item }).ToList());
                }
            }
            return newCombinations;
        }
        private static IEnumerable<IEnumerable<T>> Make2DArray<T>(IEnumerable<T> input, int height, int width)
        {
            var output = new List<List<T>>();
            var inputArray = input.ToArray();
            for (int i = 0; i < height; i++)
            {
                output.Add(new List<T>());
                for (int j = 0; j < width; j++)
                {
                    output.Last().Add(inputArray[i * width + j]);
                }
            }
            return output;
        }
    }
}
