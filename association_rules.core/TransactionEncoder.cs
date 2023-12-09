using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.TableLayout;

namespace association_rules.core
{
    internal class TransactionEncoder
    {
        internal string[] ItemSet { get; private set; }

        internal bool[,] Transform(IEnumerable<string[]> input_data, int transactColIndex = 0, int tItemColIndex = 1)
        {
            string[] tansactUniqueItems = GetUniqueItems(input_data, transactColIndex);
            string[] elementUniqueItems = GetUniqueItems(input_data, tItemColIndex);
            bool[,] encoderArray = new bool[tansactUniqueItems.Length, elementUniqueItems.Length];
            foreach (var row in input_data)
            {
                int t_index = Array.IndexOf(tansactUniqueItems,row[transactColIndex]);
                int e_index = Array.IndexOf(elementUniqueItems,row[tItemColIndex]);
                encoderArray[t_index, e_index] = true;
            }
            ItemSet = elementUniqueItems;
            return encoderArray;
        }

        private string[] GetUniqueItems(IEnumerable<string[]> input_data, int transactionColumnId = 0)
        {
            string[] transactions = new string[input_data.Count()];
            for (int i = 0; i < transactions.Length; i++)
            {
                transactions[i] = input_data.ElementAt(i)[transactionColumnId];
            }
            string[] uniqueItems = transactions.Distinct().ToArray();
            return uniqueItems;
        }
    }
}
