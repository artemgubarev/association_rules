using System;
using System.Collections.Generic;
using System.Linq;

namespace association_rules.core
{
    internal class Apriori
    {
        /// <summary>
        /// Получить ассоциативные правила
        /// </summary>
        /// <param name="inputData">Входные данные</param>
        /// <param name="power">Выходной параметр - мощность часто встречающихся множеств</param>
        /// <param name="transactColIndex">Индекс столбца транзацкции</param>
        /// <param name="itemColIndex">Индекс столбца элемента</param>
        /// <param name="minSupport">Минимальная поддержка</param>
        /// <param name="maxSupport">Максимальная поддержка</param>
        /// <param name="minConfidence">Минимальное доверие</param>
        /// <param name="maxConfidence">Максимальное доверие</param>
        /// <param name="colHeaders">Исключать первую строку из датасета</param>
        internal IEnumerable<object[]> Rules(
            IEnumerable<object[]> inputData, out int power,
            int transactColIndex = 0, int itemColIndex = 1,
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
            bool[,] encodeArray = encoder.Transform(inputData, transactColIndex, itemColIndex);
            object[] itemSet = encoder.ItemSet;

            var supportDict =
                SupportAllCombin(encodeArray, itemSet, minSupport, maxSupport);

            var rules = new List<object[]>();
            int datasetNum = inputData.Count();

            foreach (var item in supportDict)
            {
                var array = GetArrayFromKey(item.Key);
                int lenght = array.Length;
                if (lenght == 1)
                {
                    continue;
                }
                for (int c = 1; c < array.Count(); c++)
                {
                    var subsets = Utilities.Subsets(array.ToArray(), c);
                    int count = 0;
                    foreach (var subset in subsets)
                    {
                        var XuY = array;
                        var X = subset.ToArray();
                        var Y = array.Except(subset);

                        string XuYkey = GetKeyFromArray(XuY);
                        string Xkey = GetKeyFromArray(X);
                        string Ykey = GetKeyFromArray(Y);

                        double XuYsupp = supportDict[XuYkey];
                        double Xsupp = supportDict[Xkey];
                        double Ysupp = supportDict[Ykey];

                        double ruleSupp = XuYsupp;
                        double confidence = XuYsupp / Xsupp;

                        if (confidence < minConfidence || confidence > maxConfidence)
                        {
                            count++;
                            continue;
                        }
                        double lift = confidence / Ysupp;
                        var rule = BuildRule(itemSet, XuY.Except(subset).ToArray(), X.ToArray(),
                            ruleSupp, confidence, lift);
                        rules.Add(rule);
                    }
                    if (count == subsets.Length)
                    {
                        power = Math.Max(power, lenght);
                    }
                }
               
            }
            return rules;
        }

        private object[] BuildRule
        (
            object[] itemSet,
            int[] condition, int[] consequence,
            double support,
            double confidence, double lift
            )
        {
            string conditionStr = string.Empty;
            string consequenceStr = string.Empty;
            foreach (var index in condition)
            {
                conditionStr += itemSet[index] + ",";
            }
            foreach (var index in consequence)
            {
                consequenceStr += itemSet[index] + ",";
            }
            conditionStr = conditionStr.Remove(conditionStr.Length - 1, 1);
            consequenceStr = consequenceStr.Remove(consequenceStr.Length - 1, 1);

            // конвертировать в проценты
            support *= 100;
            confidence *= 100;
            object[] result =
            {
                conditionStr, consequenceStr,
                support, confidence,
                lift
            };
            return result;
        }

        private void FilterSupport(
            ref int[][] combinations, ref double[] support,
            double minSupport = 0.5, double maxSupport = 1.0)
        {
            var excludeIndexes =
                Utilities.GetExcludedIndexes(support, x => x <= minSupport || x >= maxSupport);
            support = Utilities.RemoveElementsByIndex(support, excludeIndexes).ToArray();
            combinations = Utilities.RemoveElementsByIndex(combinations, excludeIndexes).ToArray();
        }

        private Dictionary<string, double> SupportAllCombin(
            bool[,] encodeArray, object[] itemSet,
            double minSupport = 0.5, double maxSupport = 1.0)
        {
            double[] support = Support(encodeArray);
            var supportsList = new List<double[]> { support };

            int[] indexes = Enumerable.Range(0, itemSet.Length).ToArray();
            int[][] combinations = Utilities.Make2DArray(indexes, indexes.Length, width: 1).ToArray();
            FilterSupport(ref combinations, ref support, minSupport, maxSupport);
            var itemSetList = new List<int[][]>();
            itemSetList.Add(combinations);

            int maxItemset = 1;

            while (true)
            {
                int nextMaxItemset = maxItemset + 1;
                combinations
                    = GenerateNewCombinations(itemSetList[maxItemset - 1]);
                if (combinations.Length == 0)
                {
                    break;
                }
                var extractSubarrays = Utilities.ExtractSubarrays(encodeArray, combinations);
                var bools = Utilities.CheckAll(extractSubarrays);
                support = Support(bools);
                FilterSupport(ref combinations, ref support, minSupport, maxSupport);
                if (support.Length != 0)
                {
                    supportsList.Add(support);
                    itemSetList.Add(combinations);
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
                for (int j = 0; j < itemSetList[i].Length; j++)
                {
                    string key = GetKeyFromArray(itemSetList[i].ElementAt(j));
                    supportDict.Add(key, supportsList[i].ElementAt(j));
                }
            }
            return supportDict;
        }

        private string GetKeyFromArray(IEnumerable<int> array)
        {
            string key = string.Empty;
            foreach (int i in array)
            {
                key += i + ",";
            }
            key = key.Remove(key.Length - 1, 1);
            return key;
        }

        private int[] GetArrayFromKey(string key)
        {
            string[] elements = key.Split(',');
            int[] array = new int[elements.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(elements[i]);
            }
            return array;
        }

        private double[] Support(bool[,] encodeArray)
        {
            int transactionsNum = encodeArray.GetLength(0);
            int itemsetNum = encodeArray.GetLength(1);
            var supports = new double[itemsetNum];
            for (int i = 0; i < itemsetNum; i++)
            {
                int count = 0;
                for (int j = 0; j < transactionsNum; j++)
                {
                    if (encodeArray[j, i])
                    {
                        count++;
                    }
                }
                double support = ((double)count / (double)transactionsNum);
                supports[i] = support;
            }
            return supports.ToArray();
        }

        private int[][] GenerateNewCombinations(int[][] oldCombinations)
        {
            var itemsTypesInPreviousStep = oldCombinations.SelectMany(combination => combination).Distinct().ToList();
            var newCombinations = new List<int[]>();
            foreach (var oldCombination in oldCombinations)
            {
                int maxCombination = oldCombination.Last();
                var validItems = itemsTypesInPreviousStep.Where(item => item > maxCombination).ToList();
                var oldTuple = new List<int>(oldCombination);
                foreach (int item in validItems)
                {
                    newCombinations.Add(oldTuple.Concat(new List<int> { item }).ToArray());
                }
            }
            return newCombinations.ToArray();
        }
    }
}
