namespace association_rules.core
{
    partial class association_rules_user_control
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
            this.otherTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.lbOther = new DevExpress.XtraEditors.LabelControl();
            this.semicolonCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.spaceCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.commaCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.tabCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.colnamesCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.openFileButton = new DevExpress.XtraEditors.SimpleButton();
            this.runButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.minConfidenceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.minSupportTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.resultsGridControl = new DevExpress.XtraGrid.GridControl();
            this.resultsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxDelimiters)).BeginInit();
            this.groupboxDelimiters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.otherTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.semicolonCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spaceCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commaCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colnamesCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minConfidenceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSupportTextEdit.Properties)).BeginInit();
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
            this.gridControl.Size = new System.Drawing.Size(492, 418);
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
            this.groupboxDelimiters.Controls.Add(this.otherTextEdit);
            this.groupboxDelimiters.Controls.Add(this.lbOther);
            this.groupboxDelimiters.Controls.Add(this.semicolonCheckEdit);
            this.groupboxDelimiters.Controls.Add(this.spaceCheckEdit);
            this.groupboxDelimiters.Controls.Add(this.commaCheckEdit);
            this.groupboxDelimiters.Controls.Add(this.tabCheckEdit);
            this.groupboxDelimiters.Location = new System.Drawing.Point(3, 3);
            this.groupboxDelimiters.Name = "groupboxDelimiters";
            this.groupboxDelimiters.Size = new System.Drawing.Size(244, 107);
            this.groupboxDelimiters.TabIndex = 14;
            this.groupboxDelimiters.Text = "Разделители";
            // 
            // otherTextEdit
            // 
            this.otherTextEdit.Location = new System.Drawing.Point(48, 75);
            this.otherTextEdit.Name = "otherTextEdit";
            this.otherTextEdit.Properties.AllowFocused = false;
            this.otherTextEdit.Size = new System.Drawing.Size(57, 20);
            this.otherTextEdit.TabIndex = 3;
            this.otherTextEdit.EditValueChanged += new System.EventHandler(this.delimitersCheckEdit_CheckedChanged);
            // 
            // lbOther
            // 
            this.lbOther.Location = new System.Drawing.Point(5, 78);
            this.lbOther.Name = "lbOther";
            this.lbOther.Size = new System.Drawing.Size(37, 13);
            this.lbOther.TabIndex = 5;
            this.lbOther.Text = "Другой";
            // 
            // semicolonCheckEdit
            // 
            this.semicolonCheckEdit.Location = new System.Drawing.Point(86, 52);
            this.semicolonCheckEdit.Name = "semicolonCheckEdit";
            this.semicolonCheckEdit.Properties.AllowFocused = false;
            this.semicolonCheckEdit.Properties.Caption = "Точка с запятой";
            this.semicolonCheckEdit.Size = new System.Drawing.Size(107, 20);
            this.semicolonCheckEdit.TabIndex = 6;
            this.semicolonCheckEdit.CheckedChanged += new System.EventHandler(this.delimitersCheckEdit_CheckedChanged);
            // 
            // spaceCheckEdit
            // 
            this.spaceCheckEdit.Location = new System.Drawing.Point(86, 26);
            this.spaceCheckEdit.Name = "spaceCheckEdit";
            this.spaceCheckEdit.Properties.AllowFocused = false;
            this.spaceCheckEdit.Properties.Caption = "Пробел";
            this.spaceCheckEdit.Size = new System.Drawing.Size(75, 20);
            this.spaceCheckEdit.TabIndex = 5;
            this.spaceCheckEdit.CheckedChanged += new System.EventHandler(this.delimitersCheckEdit_CheckedChanged);
            // 
            // commaCheckEdit
            // 
            this.commaCheckEdit.Location = new System.Drawing.Point(5, 52);
            this.commaCheckEdit.Name = "commaCheckEdit";
            this.commaCheckEdit.Properties.AllowFocused = false;
            this.commaCheckEdit.Properties.Caption = "Запятая";
            this.commaCheckEdit.Size = new System.Drawing.Size(75, 20);
            this.commaCheckEdit.TabIndex = 4;
            this.commaCheckEdit.CheckedChanged += new System.EventHandler(this.delimitersCheckEdit_CheckedChanged);
            // 
            // tabCheckEdit
            // 
            this.tabCheckEdit.Location = new System.Drawing.Point(5, 26);
            this.tabCheckEdit.Name = "tabCheckEdit";
            this.tabCheckEdit.Properties.AllowFocused = false;
            this.tabCheckEdit.Properties.Caption = "Табуляция";
            this.tabCheckEdit.Size = new System.Drawing.Size(75, 20);
            this.tabCheckEdit.TabIndex = 3;
            this.tabCheckEdit.CheckedChanged += new System.EventHandler(this.delimitersCheckEdit_CheckedChanged);
            // 
            // colnamesCheckEdit
            // 
            this.colnamesCheckEdit.Location = new System.Drawing.Point(5, 78);
            this.colnamesCheckEdit.Name = "colnamesCheckEdit";
            this.colnamesCheckEdit.Properties.AllowFocused = false;
            this.colnamesCheckEdit.Properties.Caption = "Использовать имена столбцов";
            this.colnamesCheckEdit.Size = new System.Drawing.Size(183, 20);
            this.colnamesCheckEdit.TabIndex = 7;
            // 
            // openFileButton
            // 
            this.openFileButton.AllowFocus = false;
            this.openFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.openFileButton.Location = new System.Drawing.Point(155, 394);
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
            this.runButton.Location = new System.Drawing.Point(3, 394);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(87, 27);
            this.runButton.TabIndex = 16;
            this.runButton.Text = "Запуск";
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.colnamesCheckEdit);
            this.groupControl1.Controls.Add(this.minConfidenceTextEdit);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.minSupportTextEdit);
            this.groupControl1.Location = new System.Drawing.Point(3, 116);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(244, 107);
            this.groupControl1.TabIndex = 15;
            this.groupControl1.Text = "Параметры";
            // 
            // minConfidenceTextEdit
            // 
            this.minConfidenceTextEdit.Location = new System.Drawing.Point(140, 52);
            this.minConfidenceTextEdit.Name = "minConfidenceTextEdit";
            this.minConfidenceTextEdit.Properties.AllowFocused = false;
            this.minConfidenceTextEdit.Size = new System.Drawing.Size(99, 20);
            this.minConfidenceTextEdit.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(114, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Минимальное доверие";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(129, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Минимальная поддержка";
            // 
            // minSupportTextEdit
            // 
            this.minSupportTextEdit.Location = new System.Drawing.Point(140, 26);
            this.minSupportTextEdit.Name = "minSupportTextEdit";
            this.minSupportTextEdit.Properties.AllowFocused = false;
            this.minSupportTextEdit.Size = new System.Drawing.Size(99, 20);
            this.minSupportTextEdit.TabIndex = 4;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(750, 449);
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
            this.xtraTabPage1.Size = new System.Drawing.Size(748, 424);
            this.xtraTabPage1.Text = "Ввод данных";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.resultsGridControl);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(748, 424);
            this.xtraTabPage2.Text = "Результаты";
            // 
            // resultsGridControl
            // 
            this.resultsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsGridControl.Location = new System.Drawing.Point(0, 0);
            this.resultsGridControl.MainView = this.resultsGridView;
            this.resultsGridControl.Name = "resultsGridControl";
            this.resultsGridControl.Size = new System.Drawing.Size(748, 424);
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
            this.Size = new System.Drawing.Size(750, 449);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxDelimiters)).EndInit();
            this.groupboxDelimiters.ResumeLayout(false);
            this.groupboxDelimiters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.otherTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.semicolonCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spaceCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commaCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colnamesCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minConfidenceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSupportTextEdit.Properties)).EndInit();
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
    }
}
