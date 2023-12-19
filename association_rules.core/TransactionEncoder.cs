using System;
using System.Collections.Generic;
using System.Linq;

namespace association_rules.core
{
    internal class TransactionEncoder
    {
        internal object[] ItemSet { get; private set; }

        internal bool[,] Transform(IEnumerable<object[]> inputData, int transactColIndex = 0, int tItemColIndex = 1)
        {
            object[] transactUniqueItems = GetUniqueItems(inputData, transactColIndex);
            object[] elementUniqueItems = GetUniqueItems(inputData, tItemColIndex);
            bool[,] encoderArray = new bool[transactUniqueItems.Length, elementUniqueItems.Length];
            foreach (var row in inputData)
            {
                int tIndex = Array.IndexOf(transactUniqueItems,row[transactColIndex]);
                int eIndex = Array.IndexOf(elementUniqueItems,row[tItemColIndex]);
                encoderArray[tIndex, eIndex] = true;
            }
            ItemSet = elementUniqueItems;
            return encoderArray;
        }

        private object[] GetUniqueItems(IEnumerable<object[]> inputData, int transactColIndex = 0)
        {
            object[][] dataArray = inputData.ToArray();
            object[] transactions = new object[dataArray.Length];
            for (int i = 0; i < transactions.Length; i++)
            {
                transactions[i] = dataArray[i][transactColIndex];
            }
            object[] uniqueItems = transactions.Distinct().ToArray();
            return uniqueItems;
        }
    }
}
