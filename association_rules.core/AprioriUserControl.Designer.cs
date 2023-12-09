namespace association_rules.core
{
    partial class AprioriUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupboxDelimiters = new DevExpress.XtraEditors.GroupControl();
            this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            this.otherTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tabCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.lbOther = new DevExpress.XtraEditors.LabelControl();
            this.spaceCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.semicolonCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.commaCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.colnamesCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.openFileButton = new DevExpress.XtraEditors.SimpleButton();
            this.runButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.tItemColIndexTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.tranColIndexTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.maxConfidenceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.minSupportTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.maxSupportTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.minConfidenceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.resultsGridControl = new DevExpress.XtraGrid.GridControl();
            this.resultsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxDelimiters)).BeginInit();
            this.groupboxDelimiters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
            this.tablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.otherTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spaceCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.semicolonCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commaCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colnamesCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tItemColIndexTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tranColIndexTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxConfidenceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSupportTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSupportTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minConfidenceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl.Location = new System.Drawing.Point(253, 3);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(492, 469);
            this.gridControl.TabIndex = 13;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsDetail.ShowDetailTabs = false;
            this.gridView.OptionsHint.ShowColumnHeaderHints = false;
            this.gridView.OptionsView.ShowColumnHeaders = false;
            this.gridView.OptionsView.ShowDetailButtons = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView_RowCellStyle);
            this.gridView.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView_CustomRowCellEdit);
            this.gridView.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanging);
            // 
            // groupboxDelimiters
            // 
            this.groupboxDelimiters.Controls.Add(this.tablePanel2);
            this.groupboxDelimiters.Location = new System.Drawing.Point(3, 3);
            this.groupboxDelimiters.Name = "groupboxDelimiters";
            this.groupboxDelimiters.Size = new System.Drawing.Size(244, 107);
            this.groupboxDelimiters.TabIndex = 14;
            this.groupboxDelimiters.Text = "Разделители";
            // 
            // tablePanel2
            // 
            this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 60F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 60F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 60F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 60F)});
            this.tablePanel2.Controls.Add(this.otherTextEdit);
            this.tablePanel2.Controls.Add(this.tabCheckEdit);
            this.tablePanel2.Controls.Add(this.lbOther);
            this.tablePanel2.Controls.Add(this.spaceCheckEdit);
            this.tablePanel2.Controls.Add(this.semicolonCheckEdit);
            this.tablePanel2.Controls.Add(this.commaCheckEdit);
            this.tablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel2.Location = new System.Drawing.Point(2, 23);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 25F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel2.Size = new System.Drawing.Size(240, 82);
            this.tablePanel2.TabIndex = 17;
            // 
            // otherTextEdit
            // 
            this.tablePanel2.SetColumn(this.otherTextEdit, 1);
            this.otherTextEdit.Location = new System.Drawing.Point(63, 56);
            this.otherTextEdit.Name = "otherTextEdit";
            this.otherTextEdit.Properties.AllowFocused = false;
            this.tablePanel2.SetRow(this.otherTextEdit, 2);
            this.otherTextEdit.Size = new System.Drawing.Size(54, 20);
            this.otherTextEdit.TabIndex = 3;
            this.otherTextEdit.EditValueChanged += new System.EventHandler(this.delimitersCheckEdit_CheckedChanged);
            // 
            // tabCheckEdit
            // 
            this.tablePanel2.SetColumn(this.tabCheckEdit, 0);
            this.tablePanel2.SetColumnSpan(this.tabCheckEdit, 2);
            this.tabCheckEdit.Location = new System.Drawing.Point(3, 3);
            this.tabCheckEdit.Name = "tabCheckEdit";
            this.tabCheckEdit.Properties.AllowFocused = false;
            this.tabCheckEdit.Properties.Caption = "Табуляция";
            this.tablePanel2.SetRow(this.tabCheckEdit, 0);
            this.tabCheckEdit.Size = new System.Drawing.Size(114, 20);
            this.tabCheckEdit.TabIndex = 3;
            this.tabCheckEdit.CheckedChanged += new System.EventHandler(this.delimitersCheckEdit_CheckedChanged);
            // 
            // lbOther
            // 
            this.tablePanel2.SetColumn(this.lbOther, 0);
            this.lbOther.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbOther.Location = new System.Drawing.Point(13, 54);
            this.lbOther.Name = "lbOther";
            this.tablePanel2.SetRow(this.lbOther, 2);
            this.lbOther.Size = new System.Drawing.Size(44, 25);
            this.lbOther.TabIndex = 5;
            this.lbOther.Text = "Другой :";
            // 
            // spaceCheckEdit
            // 
            this.tablePanel2.SetColumn(this.spaceCheckEdit, 2);
            this.tablePanel2.SetColumnSpan(this.spaceCheckEdit, 2);
            this.spaceCheckEdit.Location = new System.Drawing.Point(123, 3);
            this.spaceCheckEdit.Name = "spaceCheckEdit";
            this.spaceCheckEdit.Properties.AllowFocused = false;
            this.spaceCheckEdit.Properties.Caption = "Пробел";
            this.tablePanel2.SetRow(this.spaceCheckEdit, 0);
            this.spaceCheckEdit.Size = new System.Drawing.Size(114, 20);
            this.spaceCheckEdit.TabIndex = 5;
            this.spaceCheckEdit.CheckedChanged += new System.EventHandler(this.delimitersCheckEdit_CheckedChanged);
            // 
            // semicolonCheckEdit
            // 
            this.tablePanel2.SetColumn(this.semicolonCheckEdit, 2);
            this.tablePanel2.SetColumnSpan(this.semicolonCheckEdit, 2);
            this.semicolonCheckEdit.Location = new System.Drawing.Point(123, 28);
            this.semicolonCheckEdit.Name = "semicolonCheckEdit";
            this.semicolonCheckEdit.Properties.AllowFocused = false;
            this.semicolonCheckEdit.Properties.Caption = "Точка с запятой";
            this.tablePanel2.SetRow(this.semicolonCheckEdit, 1);
            this.semicolonCheckEdit.Size = new System.Drawing.Size(114, 20);
            this.semicolonCheckEdit.TabIndex = 6;
            this.semicolonCheckEdit.CheckedChanged += new System.EventHandler(this.delimitersCheckEdit_CheckedChanged);
            // 
            // commaCheckEdit
            // 
            this.tablePanel2.SetColumn(this.commaCheckEdit, 0);
            this.tablePanel2.SetColumnSpan(this.commaCheckEdit, 2);
            this.commaCheckEdit.Location = new System.Drawing.Point(3, 28);
            this.commaCheckEdit.Name = "commaCheckEdit";
            this.commaCheckEdit.Properties.AllowFocused = false;
            this.commaCheckEdit.Properties.Caption = "Запятая";
            this.tablePanel2.SetRow(this.commaCheckEdit, 1);
            this.commaCheckEdit.Size = new System.Drawing.Size(114, 20);
            this.commaCheckEdit.TabIndex = 4;
            this.commaCheckEdit.CheckedChanged += new System.EventHandler(this.delimitersCheckEdit_CheckedChanged);
            // 
            // colnamesCheckEdit
            // 
            this.colnamesCheckEdit.Location = new System.Drawing.Point(3, 108);
            this.colnamesCheckEdit.Name = "colnamesCheckEdit";
            this.colnamesCheckEdit.Properties.AllowFocused = false;
            this.colnamesCheckEdit.Properties.Caption = "Использовать имена столбцов";
            this.colnamesCheckEdit.Size = new System.Drawing.Size(234, 20);
            this.colnamesCheckEdit.TabIndex = 7;
            // 
            // openFileButton
            // 
            this.openFileButton.AllowFocus = false;
            this.openFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.openFileButton.Location = new System.Drawing.Point(155, 445);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(87, 27);
            this.openFileButton.TabIndex = 15;
            this.openFileButton.Text = "Открыть файл";
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // runButton
            // 
            this.runButton.AllowFocus = false;
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.runButton.Enabled = false;
            this.runButton.Location = new System.Drawing.Point(3, 445);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(87, 27);
            this.runButton.TabIndex = 16;
            this.runButton.Text = "Запуск";
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tablePanel1);
            this.groupControl1.Location = new System.Drawing.Point(3, 116);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(244, 209);
            this.groupControl1.TabIndex = 15;
            this.groupControl1.Text = "Параметры";
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 41.42F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 18.58F)});
            this.tablePanel1.Controls.Add(this.tItemColIndexTextEdit);
            this.tablePanel1.Controls.Add(this.labelControl6);
            this.tablePanel1.Controls.Add(this.tranColIndexTextEdit);
            this.tablePanel1.Controls.Add(this.labelControl5);
            this.tablePanel1.Controls.Add(this.colnamesCheckEdit);
            this.tablePanel1.Controls.Add(this.maxConfidenceTextEdit);
            this.tablePanel1.Controls.Add(this.labelControl1);
            this.tablePanel1.Controls.Add(this.labelControl4);
            this.tablePanel1.Controls.Add(this.minSupportTextEdit);
            this.tablePanel1.Controls.Add(this.maxSupportTextEdit);
            this.tablePanel1.Controls.Add(this.minConfidenceTextEdit);
            this.tablePanel1.Controls.Add(this.labelControl3);
            this.tablePanel1.Controls.Add(this.labelControl2);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(2, 23);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 29F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(240, 184);
            this.tablePanel1.TabIndex = 17;
            // 
            // tItemColIndexTextEdit
            // 
            this.tablePanel1.SetColumn(this.tItemColIndexTextEdit, 1);
            this.tItemColIndexTextEdit.Location = new System.Drawing.Point(169, 162);
            this.tItemColIndexTextEdit.Name = "tItemColIndexTextEdit";
            this.tablePanel1.SetRow(this.tItemColIndexTextEdit, 6);
            this.tItemColIndexTextEdit.Size = new System.Drawing.Size(68, 20);
            this.tItemColIndexTextEdit.TabIndex = 18;
            // 
            // labelControl6
            // 
            this.tablePanel1.SetColumn(this.labelControl6, 0);
            this.labelControl6.Location = new System.Drawing.Point(3, 165);
            this.labelControl6.Name = "labelControl6";
            this.tablePanel1.SetRow(this.labelControl6, 6);
            this.labelControl6.Size = new System.Drawing.Size(159, 13);
            this.labelControl6.TabIndex = 18;
            this.labelControl6.Text = "Столбец элемента транзакции:";
            // 
            // tranColIndexTextEdit
            // 
            this.tablePanel1.SetColumn(this.tranColIndexTextEdit, 1);
            this.tranColIndexTextEdit.Location = new System.Drawing.Point(169, 136);
            this.tranColIndexTextEdit.Name = "tranColIndexTextEdit";
            this.tablePanel1.SetRow(this.tranColIndexTextEdit, 5);
            this.tranColIndexTextEdit.Size = new System.Drawing.Size(68, 20);
            this.tranColIndexTextEdit.TabIndex = 17;
            // 
            // labelControl5
            // 
            this.tablePanel1.SetColumn(this.labelControl5, 0);
            this.labelControl5.Location = new System.Drawing.Point(3, 139);
            this.labelControl5.Name = "labelControl5";
            this.tablePanel1.SetRow(this.labelControl5, 5);
            this.labelControl5.Size = new System.Drawing.Size(109, 13);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "Столбец транзакции:";
            // 
            // maxConfidenceTextEdit
            // 
            this.tablePanel1.SetColumn(this.maxConfidenceTextEdit, 1);
            this.maxConfidenceTextEdit.Location = new System.Drawing.Point(169, 81);
            this.maxConfidenceTextEdit.Name = "maxConfidenceTextEdit";
            this.maxConfidenceTextEdit.Properties.AllowFocused = false;
            this.tablePanel1.SetRow(this.maxConfidenceTextEdit, 3);
            this.maxConfidenceTextEdit.Size = new System.Drawing.Size(68, 20);
            this.maxConfidenceTextEdit.TabIndex = 14;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(129, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Минимальная поддержка";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(3, 84);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(119, 13);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "Максимальное доверие";
            // 
            // minSupportTextEdit
            // 
            this.tablePanel1.SetColumn(this.minSupportTextEdit, 1);
            this.minSupportTextEdit.Location = new System.Drawing.Point(169, 3);
            this.minSupportTextEdit.Name = "minSupportTextEdit";
            this.minSupportTextEdit.Properties.AllowFocused = false;
            this.tablePanel1.SetRow(this.minSupportTextEdit, 0);
            this.minSupportTextEdit.Size = new System.Drawing.Size(68, 20);
            this.minSupportTextEdit.TabIndex = 4;
            // 
            // maxSupportTextEdit
            // 
            this.tablePanel1.SetColumn(this.maxSupportTextEdit, 1);
            this.maxSupportTextEdit.Location = new System.Drawing.Point(169, 29);
            this.maxSupportTextEdit.Name = "maxSupportTextEdit";
            this.maxSupportTextEdit.Properties.AllowFocused = false;
            this.tablePanel1.SetRow(this.maxSupportTextEdit, 1);
            this.maxSupportTextEdit.Size = new System.Drawing.Size(68, 20);
            this.maxSupportTextEdit.TabIndex = 12;
            // 
            // minConfidenceTextEdit
            // 
            this.tablePanel1.SetColumn(this.minConfidenceTextEdit, 1);
            this.minConfidenceTextEdit.Location = new System.Drawing.Point(169, 55);
            this.minConfidenceTextEdit.Name = "minConfidenceTextEdit";
            this.minConfidenceTextEdit.Properties.AllowFocused = false;
            this.tablePanel1.SetRow(this.minConfidenceTextEdit, 2);
            this.minConfidenceTextEdit.Size = new System.Drawing.Size(68, 20);
            this.minConfidenceTextEdit.TabIndex = 10;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(3, 32);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(134, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Максимальная поддержка";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(114, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Минимальное доверие";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(750, 500);
            this.xtraTabControl1.TabIndex = 17;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupboxDelimiters);
            this.xtraTabPage1.Controls.Add(this.gridControl);
            this.xtraTabPage1.Controls.Add(this.openFileButton);
            this.xtraTabPage1.Controls.Add(this.runButton);
            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(748, 475);
            this.xtraTabPage1.Text = "Ввод данных";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.resultsGridControl);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(748, 475);
            this.xtraTabPage2.Text = "Результаты";
            // 
            // resultsGridControl
            // 
            this.resultsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsGridControl.Location = new System.Drawing.Point(0, 0);
            this.resultsGridControl.MainView = this.resultsGridView;
            this.resultsGridControl.Name = "resultsGridControl";
            this.resultsGridControl.Size = new System.Drawing.Size(748, 475);
            this.resultsGridControl.TabIndex = 14;
            this.resultsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.resultsGridView});
            // 
            // resultsGridView
            // 
            this.resultsGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.resultsGridView.GridControl = this.resultsGridControl;
            this.resultsGridView.Name = "resultsGridView";
            this.resultsGridView.OptionsDetail.ShowDetailTabs = false;
            this.resultsGridView.OptionsHint.ShowColumnHeaderHints = false;
            this.resultsGridView.OptionsView.ShowDetailButtons = false;
            this.resultsGridView.OptionsView.ShowGroupPanel = false;
            this.resultsGridView.OptionsView.ShowIndicator = false;
            // 
            // association_rules_user_control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "association_rules_user_control";
            this.Size = new System.Drawing.Size(750, 500);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxDelimiters)).EndInit();
            this.groupboxDelimiters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
            this.tablePanel2.ResumeLayout(false);
            this.tablePanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.otherTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spaceCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.semicolonCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commaCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colnamesCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tItemColIndexTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tranColIndexTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxConfidenceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSupportTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSupportTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minConfidenceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.GroupControl groupboxDelimiters;
        private DevExpress.XtraEditors.TextEdit otherTextEdit;
        private DevExpress.XtraEditors.LabelControl lbOther;
        private DevExpress.XtraEditors.CheckEdit semicolonCheckEdit;
        private DevExpress.XtraEditors.CheckEdit spaceCheckEdit;
        private DevExpress.XtraEditors.CheckEdit commaCheckEdit;
        private DevExpress.XtraEditors.CheckEdit tabCheckEdit;
        private DevExpress.XtraEditors.SimpleButton openFileButton;
        private DevExpress.XtraEditors.SimpleButton runButton;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit colnamesCheckEdit;
        private DevExpress.XtraEditors.TextEdit minConfidenceTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit minSupportTextEdit;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl resultsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView resultsGridView;
        private DevExpress.XtraEditors.TextEdit maxSupportTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit maxConfidenceTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private DevExpress.XtraEditors.TextEdit tranColIndexTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit tItemColIndexTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}
