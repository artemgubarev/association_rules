﻿using DevExpress.XtraEditors.Repository;
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
using System.Threading;
using System.Windows.Forms;

namespace association_rules.core
{
    public partial class AprioriUserControl : DevExpress.XtraEditors.XtraUserControl
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
        private int _transactColIndex = 0;
        private int _itemColIndex = 1;

        public AprioriUserControl()
        {
            InitializeComponent();
            _repositoryCheckEdit.QueryCheckStateByValue += _repositoryCheckEdit_QueryCheckStateByValue;
            FillData();
            SetCultureInfo();
        }

        static void SetCultureInfo()
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
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
                InputDataValidate(data.ElementAt(0).Length);
                double min_support = Double.Parse(minSupportTextEdit.Text, NumberStyles.Any, CultureInfo.InvariantCulture)/100;
                double max_support = Double.Parse(maxSupportTextEdit.Text, NumberStyles.Any, CultureInfo.InvariantCulture)/100;
                double min_confidence = Double.Parse(minConfidenceTextEdit.Text, NumberStyles.Any, CultureInfo.InvariantCulture) / 100;
                double max_confidence = Double.Parse(maxConfidenceTextEdit.Text, NumberStyles.Any, CultureInfo.InvariantCulture) / 100;
                int transactionColumnIndex = GetColIndex(int.Parse(tranColIndexTextEdit.Text));
                int itemColIndex = GetColIndex(int.Parse(tItemColIndexTextEdit.Text));
                bool colsHeaders = colnamesCheckEdit.Checked;
                var apriori = new Apriori();
                var rules = apriori.Rules(
                    data, out int power,
                     transactionColumnIndex, itemColIndex,
                    min_support, max_support,
                    min_confidence, max_confidence,
                    colsHeaders
                    );
                FillResultsDataTable(rules);
                MessageBox.Show("Ассоциативные правила построены.\n" +
                                $"Количество правил = {rules.Count()}\n" +
                                $"Мощность часто встречающихся множеств = {power}\n" +
                                $"В условияъ и следствиях элементы перечисленны через запятую");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private int GetColIndex(int index)
        {
            foreach (var colIndex in _excludedColumns)
            {
                if (colIndex <= index)
                {
                    index--;
                }
            }
            while (index < 0)
            {
                index++;
            }
            return index;
        }

        private void FillResultsDataTable(IEnumerable<object[]> rules)
        {
            string[] colHeaders = new[]
            {
                "Условие",
                "Следствие",
                "Поддержка %",
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
                dataTable.Rows.Add(rule);
            }
            GridViewRefresh(resultsGridControl,resultsGridView,dataTable);
            resultsGridView.Columns[3].SortMode = ColumnSortMode.Custom;
        }

        private void InputDataValidate(int dataLength)
        {
            string incorrectErrorMessage = "Некорректно задано значение ";
            string noNegativeValueMessage = "Значение не может быть отрицательным.\n Имя значения - ";
            if (!double.TryParse(minSupportTextEdit.Text, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out double min_support))
            {
                throw new Exception(incorrectErrorMessage + "минимальной поддержки.");
            }
            if (!double.TryParse(maxSupportTextEdit.Text, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out double max_support))
            {
                throw new Exception(incorrectErrorMessage +"максимальной поддержки.");
            }
            if (!double.TryParse(minConfidenceTextEdit.Text, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out double min_confidence))
            {
                throw new Exception(incorrectErrorMessage + "минимального доверия");
            }
            if (!double.TryParse(maxConfidenceTextEdit.Text, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out double max_confidence))
            {
                throw new Exception(incorrectErrorMessage + "максимального доверия");
            }
            if (!int.TryParse(tranColIndexTextEdit.Text, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out int transactionIndex))
            {
                throw new Exception(incorrectErrorMessage + " столбца транзакции");
            }
            if (!int.TryParse(tItemColIndexTextEdit.Text, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out int tItemColIndex))
            {
                throw new Exception(incorrectErrorMessage + " столбец элемента транзакции");
            }
            if (min_support < 0)
            {
                throw new Exception(noNegativeValueMessage + "минимальная поддержка");
            }
            if (min_confidence < 0)
            {
                throw new Exception(noNegativeValueMessage + "минимальное доверие");
            }
            if (max_confidence < 0)
            {
                throw new Exception(noNegativeValueMessage + "максимальное доверие");
            }
            if (transactionIndex < 0 || transactionIndex > dataLength)
            {
                throw new Exception("Номер столбца транзакции должен быть в диапозоне [0, количество столбцов]");
            }
            if (tItemColIndex < 0 || tItemColIndex > dataLength || tItemColIndex == transactionIndex)
            {
                throw new Exception("Номер столбца элемента транзакции должен быть в диапозоне [0, количество столбцов]," +
                                    "и не совпадать со столбцом транзакции.");
            }
        }

        private IEnumerable<object[]> GetDataTableData()
        {
            var data = new List<object[]>();
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
                    var row = new List<object>();
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
                        row.Add(value);
                    }
                    data.Add(row.ToArray());
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
                openFileDialog.InitialDirectory = "C:\\Users\\gubarev.av\\Desktop\\datasets";
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

        private void FillData()
        {
            minSupportTextEdit.Text = "1";
            maxSupportTextEdit.Text = "90";
            minConfidenceTextEdit.Text = "1";
            maxConfidenceTextEdit.Text = "90";
            tranColIndexTextEdit.Text = "0";
            tItemColIndexTextEdit.Text = "1";
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

            //if (colIndex == _itemColIndex)
            //{
            //    e.Appearance.BackColor = Color.GreenYellow;
            //}

            //if (colIndex == _transactColIndex)
            //{
            //    e.Appearance.BackColor = Color.Aquamarine;
            //}
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

        private void tranColIndexTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(tranColIndexTextEdit.Text, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out int transactionIndex))
            {
                tranColIndexTextEdit.Text = _transactColIndex.ToString();
            }
            else
            {
                _transactColIndex = transactionIndex;
            }
            gridView.LayoutChanged();
        }

        private void tItemColIndexTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(tItemColIndexTextEdit.Text, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out int tItemColIndex))
            {
                tItemColIndexTextEdit.Text = _itemColIndex.ToString();
            }
            else
            {
                _itemColIndex = tItemColIndex;
            }
            gridView.LayoutChanged();
        }
    }
}
