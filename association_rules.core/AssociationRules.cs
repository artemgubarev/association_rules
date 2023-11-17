using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace association_rules.core
{
    internal class AssociationRules
    {
        public static IEnumerable<string[]> FindRules(IEnumerable<string[]> input_data, out int power, 
            double min_support = 0.5, double max_support = 1.0, 
            double min_confidence = 0.5, double max_confidence = 1.0,
            bool colHeaders = false)
        {
            string pythonFile = @"..\..\..\..\association_rules.core\python\association_rules.py";
            var python = new PythonInterop();
            var result = python.RunPythonCode(pythonFile,
                new[] { "data", "min_support", "max_support", "min_confidence", "max_confidence", "headers" },
                new object[] { input_data, min_support,max_support, min_confidence, max_confidence, colHeaders }, 
                "rules");
            var str_result = result.ToString();
            var results = ParseResults(str_result, out int _power);
            power = _power;
            return results;
        }

        private static IEnumerable<string[]> ParseResults(string str, out int power)
        {
            str = str.Substring(1);
            str = str.Substring(0, str.Length - 1);
            str = str.Replace("\n", "");

            string pattern = @"\[(.*?)\]";
            MatchCollection matches = Regex.Matches(str, pattern);
            
            var results = new List<string[]>();
            pattern = @"'([^']+)'";

            power = 0;
            
            for (int i = 0; i < matches.Count; i++)
            {
                var result = new List<string>();
                var rule = matches[i].Groups[1].Value;
                var splitted = rule.Split(new string[]{"frozenset"}, StringSplitOptions.RemoveEmptyEntries);
                var frozenset1 = Regex.Matches(splitted[0], pattern);
                var frozenset2 = Regex.Matches(splitted[1], pattern);
                string antecedent = string.Empty;
                string consequent = string.Empty;
                for (int j = 0; j < frozenset1.Count; j++)
                {
                    antecedent += frozenset1[j].Groups[1].Value + ",";
                }
                for (int j = 0; j < frozenset2.Count; j++)
                {
                    consequent += frozenset2[j].Groups[1].Value + ",";
                }
                if (antecedent.Length != 0)
                {
                    antecedent = antecedent.Substring(0, antecedent.Length - 1);
                }
                if (consequent.Length != 0)
                {
                    consequent = consequent.Substring(0, consequent.Length - 1);
                }
                int _power = frozenset1.Count + frozenset2.Count;
                if (_power > power)
                {
                    power = _power;
                }
                result.Add(antecedent);
                result.Add(consequent);
                var numbers_matchs = rule.Split(' ');
                for (int j = 0; j < numbers_matchs.Length; j++)
                {
                    if (double.TryParse(numbers_matchs[j], NumberStyles.Any, 
                            CultureInfo.InvariantCulture, out double value) || numbers_matchs[j] == "inf")
                    {
                        result.Add(value.ToString());
                    }
                }
                results.Add(result.ToArray());
            }
            return results;
        }
    }
}
