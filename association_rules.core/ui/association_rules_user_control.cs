using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace association_rules.core
{
    public partial class association_rules_user_control : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly RepositoryItemCheckEdit _repositoryCheckEdit = new RepositoryItemCheckEdit()
        {
            AllowGrayed = false,
            ValueChecked = CheckState.Checked.ToString(),
            ValueUnchecked = CheckState.Unchecked.ToString(),
            ValueGrayed = null
        };
        private string _currentFilePath;
        private readonly List<int> _excludedColumns = new List<int>();

        public association_rules_user_control()
        {
            InitializeComponent();
            
            _repositoryCheckEdit.QueryCheckStateByValue += _repositoryCheckEdit_QueryCheckStateByValue;
        }

        private void _repositoryCheckEdit_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
        {
            if (e.Value.ToString() == CheckState.Indeterminate.ToString())
            {
                e.CheckState = CheckState.Unchecked;
                e.Handled = true;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            try
            {
                var data = GetDataTableData();
                InputDataValidate();
                double min_support = Double.Parse(minSupportTextEdit.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
                double max_support = Double.Parse(maxSupportTextEdit.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
                double min_confidence = Double.Parse(minConfidenceTextEdit.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
                double max_confidence = Double.Parse(maxConfidenceTextEdit.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
                bool colsHeaders = colnamesCheckEdit.Checked;
                var rules = AssociationRules.FindRules(data, out int power,
                    min_support, max_support,
                    min_confidence,max_confidence, colsHeaders);
                FillResultsDataTable(rules);
                MessageBox.Show("Ассоциативные правила построены.\n" +
                                $"Количество правил = {rules.Count()}\n" + 
                                $"Мощность часто встречающихся множеств = {power}");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void FillResultsDataTable(IEnumerable<string[]> rules)
        {
            string[] colHeaders = new[]
            {
                "Условие",
                "Следствие",
                "Поддержка",
                "Достоверность %",
                "Лифт",

            };
            var dataTable = new DataTable();
            foreach (var header in colHeaders)
            {
                dataTable.Columns.Add(header);
            }
            foreach (var rule in rules)
            {
                var row = new object[colHeaders.Length];

                double support = double.Parse(rule[4]);
                double confidence = double.Parse(rule[5]);
                double lift = double.Parse(rule[6]);

                support *= 100;
                confidence *= 100;

                row[0] = rule[0];
                row[1] = rule[1];
                row[2] = support;
                row[3] = confidence;
                row[4] = lift;
                dataTable.Rows.Add(row);
            }
            GridViewRefresh(resultsGridControl,resultsGridView,dataTable);
            resultsGridView.Columns[3].SortMode = ColumnSortMode.Custom;
        }

        private void InputDataValidate()
        {
            if (!double.TryParse(minSupportTextEdit.Text, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out double min_support) || min_support < 0)
            {
                throw new Exception("Неверно указано значение минимальной поддержки");
            }
            if (!double.TryParse(maxSupportTextEdit.Text, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out double max_support) || max_support < 0)
            {
                throw new Exception("Неверно указано значение максимальной поддержки");
            }
            if (!double.TryParse(minConfidenceTextEdit.Text, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out double min_confidence) || min_confidence < 0)
            {
                throw new Exception("Неверно указано значение минимального доверия");
            }
            if (!double.TryParse(maxConfidenceTextEdit.Text, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out double max_confidence) || max_confidence < 0)
            {
                throw new Exception("Неверно указано значение максимального доверия");
            }
        }

        private IEnumerable<string[]> GetDataTableData()
        {
            var data = new List<string[]>();
            var dataTable = (DataTable)gridControl.DataSource;
            int colsCount = dataTable.Columns.Count;
            int excludedColumnsCount = _excludedColumns.Count;

            if (colsCount - excludedColumnsCount < 2)
            {
                throw new Exception("Для построения ассоциативных правил,\n" +
                                    " необходимо иметь как минимум 2 столбца");
            }

            if (dataTable != null)
            {
                for (int i = 1; i < dataTable.Rows.Count; i++)
                {
                    string[] row = new string[colsCount - excludedColumnsCount];
                    int diff = 0;
                    for (int j = 0; j < colsCount; j++)
                    {
                        if (_excludedColumns.Contains(j))
                        {
                            diff = excludedColumnsCount;
                            continue;
                        }
                        string value = dataTable.Rows[i][j].ToString();
                        if (string.IsNullOrEmpty(value))
                        {
                            throw new Exception("Одно из значений таблицы является пустым!");
                        }
                        row[j - diff] = value;
                    }
                    data.Add(row);
                }
            }
            return data;
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            OpenFile();
            UpdateDataTable();
            runButton.Enabled = true;
        }

        private IEnumerable<string> GetDelimiters()
        {
            var delimiters = new List<string>();
            if (tabCheckEdit.Checked)
            {
                delimiters.Add("\t");
            }
            if (commaCheckEdit.Checked)
            {
                delimiters.Add(",");
            }
            if (semicolonCheckEdit.Checked)
            {
                delimiters.Add(";");
            }
            if (spaceCheckEdit.Checked)
            {
                delimiters.Add(" ");
            }
            if (!string.IsNullOrEmpty(otherTextEdit.Text))
            {
                delimiters.Add(otherTextEdit.Text);
            }
            delimiters.Add("\n");
            return delimiters;
        }

        private void OpenFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _currentFilePath = openFileDialog.FileName;
                }
            }
        }

        private DataTable CreateDataTable(string filePath, IEnumerable<string> delimiters)
        {
            var dataTable = new DataTable();
            var lines = File.ReadAllLines(filePath, Encoding.UTF8);
            var enumerable = delimiters as string[] ?? delimiters.ToArray();
            int count = GetMaxColumnsCount(lines, delimiters);
            string[] checkStates = new string[count];
            for (int i = 0; i < count; i++)
            {
                dataTable.Columns.Add(new DataColumn());
                checkStates[i] = CheckState.Unchecked.ToString();
            }
            dataTable.Rows.Add(checkStates); 
            foreach (var line in lines)
            {
                object[] words = line.Split(enumerable.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                dataTable.Rows.Add(words);
            }
            return dataTable;
        }

        private int GetMaxColumnsCount(string[] lines,IEnumerable<string> delimiters)
        {
            int max = 0;
            foreach (var line in lines)
            {
                int count = line.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Length;
                max = Math.Max(max, count);
            }
            return max;
        }

        private void UpdateDataTable()
        {
            if (_currentFilePath != null)
            {
                var delimiters = GetDelimiters();
                var dataTable = CreateDataTable(_currentFilePath, delimiters);
                GridViewRefresh(gridControl, gridView,dataTable);
                _excludedColumns.Clear();
            }
        }

        private void delimitersCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDataTable();
        }

        #region GridView
        private void gridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle == 0)
            {
                e.RepositoryItem = _repositoryCheckEdit;
            }
        }
        
        private void gridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridView.PostEditor();
            int rowIndex = e.RowHandle;
            if (rowIndex == 0)
            {
                var dataTable = (DataTable)gridControl.DataSource;
                int colIndex = e.Column.AbsoluteIndex;
                var checkState = gridView.GetRowCellValue(rowHandle: 0, e.Column);
                if (checkState.ToString() == CheckState.Unchecked.ToString())
                {
                    _excludedColumns.Add(colIndex);
                    dataTable.Rows[rowIndex][colIndex] = CheckState.Checked.ToString();
                }
                else
                {
                    _excludedColumns.Remove(colIndex);
                    dataTable.Rows[rowIndex][colIndex] = CheckState.Unchecked.ToString();
                }
            }
            gridView.LayoutChanged();
        }

        private void gridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            int colIndex = e.Column.AbsoluteIndex;
            if (_excludedColumns.Contains(colIndex))
            {
                e.Appearance.BackColor = Color.DarkSalmon;
            }
        }
        
        private void GridViewRefresh(GridControl gridControl, GridView gridView, DataTable dataTable)
        {
            gridControl.BeginUpdate();
            gridView.Columns.Clear();
            gridControl.DataSource = null;
            GC.Collect();
            gridControl.DataSource = dataTable;
            gridControl.EndUpdate();
            gridView.LayoutChanged();
        }

        #endregion
        
    }
}
