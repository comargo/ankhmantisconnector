﻿namespace AnkhMantisConnector.IssueTracker.Forms
{
    partial class IssuesView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssuesView));
            this.dgvIssues = new System.Windows.Forms.DataGridView();
            this.issueDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tscbFilter = new System.Windows.Forms.ToolStripComboBox();
            this.tslbPage = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnFirst = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPrev = new System.Windows.Forms.ToolStripButton();
            this.tstxtPage = new System.Windows.Forms.ToolStripTextBox();
            this.tsbtnNext = new System.Windows.Forms.ToolStripButton();
            this.tsbtnNew = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.pbBusyLoader = new System.Windows.Forms.PictureBox();
            this.pnlBusyIndicator = new System.Windows.Forms.Panel();
            this.lbCurrentAction = new System.Windows.Forms.Label();
            this.lbLoading = new System.Windows.Forms.Label();
            this.colAssociation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.priorityDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastupdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.severityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reporterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handlerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resolutionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.issueDataBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBusyLoader)).BeginInit();
            this.pnlBusyIndicator.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIssues
            // 
            this.dgvIssues.AllowUserToAddRows = false;
            this.dgvIssues.AllowUserToDeleteRows = false;
            this.dgvIssues.AllowUserToResizeRows = false;
            this.dgvIssues.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIssues.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvIssues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAssociation,
            this.priorityDataGridViewImageColumn,
            this.idDataGridViewTextBoxColumn,
            this.lastupdatedDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn,
            this.severityDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.reporterDataGridViewTextBoxColumn,
            this.handlerDataGridViewTextBoxColumn,
            this.resolutionDataGridViewTextBoxColumn});
            this.dgvIssues.DataSource = this.issueDataBindingSource;
            this.dgvIssues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIssues.Location = new System.Drawing.Point(0, 25);
            this.dgvIssues.Name = "dgvIssues";
            this.dgvIssues.RowHeadersVisible = false;
            this.dgvIssues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIssues.Size = new System.Drawing.Size(519, 121);
            this.dgvIssues.TabIndex = 2;
            this.dgvIssues.Visible = false;
            this.dgvIssues.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvIssues_SortCompare);
            this.dgvIssues.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIssues_CellContentClick);
            // 
            // issueDataBindingSource
            // 
            this.issueDataBindingSource.DataSource = typeof(AnkhMantisConnector.IssueTracker.Forms.IssuesView.IssueData);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbFilter,
            this.tslbPage,
            this.tsbtnFirst,
            this.tsbtnPrev,
            this.tstxtPage,
            this.tsbtnNext,
            this.tsbtnNew,
            this.tsbtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(519, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tscbFilter
            // 
            this.tscbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbFilter.Name = "tscbFilter";
            this.tscbFilter.Size = new System.Drawing.Size(171, 25);
            this.tscbFilter.SelectedIndexChanged += new System.EventHandler(this.tscbFilter_SelectedIndexChanged);
            // 
            // tslbPage
            // 
            this.tslbPage.Name = "tslbPage";
            this.tslbPage.Size = new System.Drawing.Size(36, 22);
            this.tslbPage.Text = "Page:";
            // 
            // tsbtnFirst
            // 
            this.tsbtnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFirst.Enabled = false;
            this.tsbtnFirst.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFirst.Image")));
            this.tsbtnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFirst.Name = "tsbtnFirst";
            this.tsbtnFirst.Size = new System.Drawing.Size(23, 22);
            this.tsbtnFirst.Text = "First";
            this.tsbtnFirst.Click += new System.EventHandler(this.tsbtnFirst_Click);
            // 
            // tsbtnPrev
            // 
            this.tsbtnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPrev.Enabled = false;
            this.tsbtnPrev.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPrev.Image")));
            this.tsbtnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPrev.Name = "tsbtnPrev";
            this.tsbtnPrev.Size = new System.Drawing.Size(23, 22);
            this.tsbtnPrev.Text = "Previous";
            this.tsbtnPrev.Click += new System.EventHandler(this.tsbtnPrev_Click);
            // 
            // tstxtPage
            // 
            this.tstxtPage.Name = "tstxtPage";
            this.tstxtPage.Size = new System.Drawing.Size(30, 25);
            this.tstxtPage.Text = "1";
            this.tstxtPage.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tstxtPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tstxtPage_KeyDown);
            // 
            // tsbtnNext
            // 
            this.tsbtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnNext.Enabled = false;
            this.tsbtnNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNext.Image")));
            this.tsbtnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNext.Name = "tsbtnNext";
            this.tsbtnNext.Size = new System.Drawing.Size(23, 22);
            this.tsbtnNext.Text = "Next";
            this.tsbtnNext.Click += new System.EventHandler(this.tsbtnNext_Click);
            // 
            // tsbtnNew
            // 
            this.tsbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNew.Image")));
            this.tsbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNew.Name = "tsbtnNew";
            this.tsbtnNew.Size = new System.Drawing.Size(23, 22);
            this.tsbtnNew.Text = "New Issue";
            this.tsbtnNew.Click += new System.EventHandler(this.tsbtnNew_Click);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefresh.Image")));
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRefresh.Text = "Refresh";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // pbBusyLoader
            // 
            this.pbBusyLoader.Image = global::AnkhMantisConnector.Properties.Resources.busy_loader;
            this.pbBusyLoader.Location = new System.Drawing.Point(3, 3);
            this.pbBusyLoader.Name = "pbBusyLoader";
            this.pbBusyLoader.Size = new System.Drawing.Size(32, 32);
            this.pbBusyLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbBusyLoader.TabIndex = 9;
            this.pbBusyLoader.TabStop = false;
            // 
            // pnlBusyIndicator
            // 
            this.pnlBusyIndicator.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlBusyIndicator.Controls.Add(this.lbCurrentAction);
            this.pnlBusyIndicator.Controls.Add(this.lbLoading);
            this.pnlBusyIndicator.Controls.Add(this.pbBusyLoader);
            this.pnlBusyIndicator.Location = new System.Drawing.Point(159, 60);
            this.pnlBusyIndicator.Name = "pnlBusyIndicator";
            this.pnlBusyIndicator.Size = new System.Drawing.Size(200, 44);
            this.pnlBusyIndicator.TabIndex = 10;
            // 
            // lbCurrentAction
            // 
            this.lbCurrentAction.AutoSize = true;
            this.lbCurrentAction.Location = new System.Drawing.Point(41, 22);
            this.lbCurrentAction.Name = "lbCurrentAction";
            this.lbCurrentAction.Size = new System.Drawing.Size(0, 13);
            this.lbCurrentAction.TabIndex = 11;
            // 
            // lbLoading
            // 
            this.lbLoading.AutoSize = true;
            this.lbLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoading.Location = new System.Drawing.Point(41, 3);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Size = new System.Drawing.Size(76, 16);
            this.lbLoading.TabIndex = 10;
            this.lbLoading.Text = "Loading...";
            // 
            // colAssociation
            // 
            this.colAssociation.HeaderText = "";
            this.colAssociation.Name = "colAssociation";
            // 
            // priorityDataGridViewImageColumn
            // 
            this.priorityDataGridViewImageColumn.DataPropertyName = "priorityImage";
            this.priorityDataGridViewImageColumn.HeaderText = "priority";
            this.priorityDataGridViewImageColumn.Name = "priorityDataGridViewImageColumn";
            this.priorityDataGridViewImageColumn.ReadOnly = true;
            this.priorityDataGridViewImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.priorityDataGridViewImageColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // lastupdatedDataGridViewTextBoxColumn
            // 
            this.lastupdatedDataGridViewTextBoxColumn.DataPropertyName = "last_updated";
            this.lastupdatedDataGridViewTextBoxColumn.HeaderText = "last_updated";
            this.lastupdatedDataGridViewTextBoxColumn.Name = "lastupdatedDataGridViewTextBoxColumn";
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            // 
            // severityDataGridViewTextBoxColumn
            // 
            this.severityDataGridViewTextBoxColumn.DataPropertyName = "severity";
            this.severityDataGridViewTextBoxColumn.HeaderText = "severity";
            this.severityDataGridViewTextBoxColumn.Name = "severityDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // reporterDataGridViewTextBoxColumn
            // 
            this.reporterDataGridViewTextBoxColumn.DataPropertyName = "reporter";
            this.reporterDataGridViewTextBoxColumn.HeaderText = "reporter";
            this.reporterDataGridViewTextBoxColumn.Name = "reporterDataGridViewTextBoxColumn";
            // 
            // handlerDataGridViewTextBoxColumn
            // 
            this.handlerDataGridViewTextBoxColumn.DataPropertyName = "handler";
            this.handlerDataGridViewTextBoxColumn.HeaderText = "handler";
            this.handlerDataGridViewTextBoxColumn.Name = "handlerDataGridViewTextBoxColumn";
            // 
            // resolutionDataGridViewTextBoxColumn
            // 
            this.resolutionDataGridViewTextBoxColumn.DataPropertyName = "resolution";
            this.resolutionDataGridViewTextBoxColumn.HeaderText = "resolution";
            this.resolutionDataGridViewTextBoxColumn.Name = "resolutionDataGridViewTextBoxColumn";
            // 
            // IssuesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBusyIndicator);
            this.Controls.Add(this.dgvIssues);
            this.Controls.Add(this.toolStrip1);
            this.Name = "IssuesView";
            this.Size = new System.Drawing.Size(519, 146);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.issueDataBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBusyLoader)).EndInit();
            this.pnlBusyIndicator.ResumeLayout(false);
            this.pnlBusyIndicator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIssues;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox tscbFilter;
        private System.Windows.Forms.ToolStripLabel tslbPage;
        private System.Windows.Forms.ToolStripButton tsbtnFirst;
        private System.Windows.Forms.ToolStripButton tsbtnPrev;
        private System.Windows.Forms.ToolStripTextBox tstxtPage;
        private System.Windows.Forms.ToolStripButton tsbtnNext;
        private System.Windows.Forms.PictureBox pbBusyLoader;
        private System.Windows.Forms.Panel pnlBusyIndicator;
        private System.Windows.Forms.Label lbCurrentAction;
        private System.Windows.Forms.Label lbLoading;
        private System.Windows.Forms.ToolStripButton tsbtnNew;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.BindingSource issueDataBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAssociation;
        private System.Windows.Forms.DataGridViewImageColumn priorityDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastupdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn severityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reporterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn handlerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resolutionDataGridViewTextBoxColumn;
    }
}
