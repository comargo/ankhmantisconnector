﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AnkhMantisConnector.IssueTracker.Forms
{
    internal partial class IssuesView : UserControl
    {
        class IssueData : org.mantisbt.www.IssueData
        {
            public IssueData(org.mantisbt.www.IssueData data)
            {
                foreach (var prop in data.GetType().GetProperties())
                {
                    prop.SetValue(this, prop.GetValue(data, null), null);
                }
            }

            public Image priorityImage
            {
                get
                {
                    switch (priority.id)
                    {
                        case "10":
                            return Properties.Resources.priority_none;

                        case "20":
                            return Properties.Resources.priority_low_1;

                        case "30":
                            return Properties.Resources.priority_normal;

                        case "40":
                            return Properties.Resources.priority_1;

                        case "50":
                            return Properties.Resources.priority_2;

                        case "60":
                            return Properties.Resources.priority_3;

                        default:
                            return Properties.Resources.priority_none;
                    }
                }
            }
        }
        private int _currentPage = 1;
        private string _currentFilter;
        private Dictionary<string, Color> _statusColorMapping;
        private ConnectorSettings _settings;

        private List<org.mantisbt.www.IssueData> _selectedIssues;
        public IEnumerable<org.mantisbt.www.IssueData> SelectedIssues
        {
            get { return _selectedIssues.AsEnumerable(); }
        }

        public IssuesView()
        {
            InitializeComponent();

            priorityDataGridViewImageColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            _selectedIssues = new List<org.mantisbt.www.IssueData>();
        }

        private void InitializeStatusColorMapping()
        {
            _statusColorMapping = new Dictionary<string, Color>()
                                      {
                                          {"10", Color.FromArgb(0xfc, 0xbd, 0xbd)},
                                          {"20", Color.FromArgb(0xe3, 0xb7, 0xeb)},
                                          {"30", Color.FromArgb(0xff, 0xcd, 0x85)},
                                          {"40", Color.FromArgb(0xff, 0xf4, 0x94)},
                                          {"50", Color.FromArgb(0xc2, 0xdf, 0xff)},
                                          {"80", Color.FromArgb(0xd2, 0xf5, 0xb0)},
                                          {"90", Color.FromArgb(0xc9, 0xcc, 0xc4)}
                                      };
        }

        private void DisplayIssues(string filterId, int page)
        {
            lbCurrentAction.Text = "Getting issues...";
            var mantisConnector =
                new org.mantisbt.www.MantisConnect(_settings.RepositoryUri.ToString() + _settings.WebServicePath);

            mantisConnector.mc_project_get_issuesCompleted += (s, e) =>
                {
                    if (e.Error != null || e.Cancelled)
                    {
                        if (e.Error != null)
                        {
                            MessageBox.Show("Couldn't get issues: " + e.Error.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        mantisConnector.ConfirmUserCredential(false);
                    }
                    else
                    {
                        mantisConnector.ConfirmUserCredential(true);
                        DisplayIssues(page, e.Result, e.Error, e.Cancelled);
                        _currentFilter = filterId;
                    }
                    mantisConnector.Dispose();
                };

            mantisConnector.mc_filter_get_issuesCompleted += (s, e) =>
            {
                if (e.Error != null || e.Cancelled)
                {
                    if (e.Error != null)
                    {
                        MessageBox.Show("Couldn't get issues: " + e.Error.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    mantisConnector.ConfirmUserCredential(false);
                }
                else
                {
                    mantisConnector.ConfirmUserCredential(true);
                    DisplayIssues(page, e.Result, e.Error, e.Cancelled);
                    _currentFilter = filterId;
                }
                mantisConnector.Dispose();
            };

            var cred = mantisConnector.GetUserCredential();
            if (cred != null)
            {

                if (filterId == "-1")
                    mantisConnector.mc_project_get_issuesAsync(cred.UserName, cred.Password, _settings.ProjectId.ToString(),
                                                          page.ToString(), _settings.IssuesPerPage.ToString());
                else
                    mantisConnector.mc_filter_get_issuesAsync(cred.UserName, cred.Password, _settings.ProjectId.ToString(),
                                                              filterId, page.ToString(), _settings.IssuesPerPage.ToString());
            }
        }

        private void DisplayIssues(int page, org.mantisbt.www.IssueData[] issues, Exception error, bool cancelled)
        {
            issueDataBindingSource.DataSource = (from issue in issues select new IssueData(issue)); ;

            //dgvIssues.SuspendDrawing();
            //dgvIssues.Rows.Clear();
            //foreach (var issue in issues)
            //{
            //    int newIndex = dgvIssues.Rows.Add(false, GetPriorityImage(issue.priority.id), issue.id, issue.category,
            //        issue.severity.name, issue.status.name + (issue.handler != null ? " (" + issue.handler.name + ")" : string.Empty),
            //        issue.summary, issue.reporter.name, issue.last_updated.ToString());

            //    dgvIssues.Rows[newIndex].DefaultCellStyle.BackColor = GetStatusColor(issue.status.id);
            //    dgvIssues.Rows[newIndex].Tag = issue;
            //}

            dgvIssues.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            pnlBusyIndicator.Visible = false;
            dgvIssues.Visible = true;
            //dgvIssues.ResumeDrawing();

            _currentPage = page;
            tstxtPage.Text = _currentPage.ToString();
            if (_currentPage > 1)
            {
                tsbtnFirst.Enabled = true;
                tsbtnPrev.Enabled = true;
            }
            else
            {
                tsbtnFirst.Enabled = false;
                tsbtnPrev.Enabled = false;
            }

            tsbtnNext.Enabled = issues.Length == _settings.IssuesPerPage;
        }

        private Image GetPriorityImage(string priority)
        {
            switch (priority)
            {
                case "10":
                    return Properties.Resources.priority_none;

                case "20":
                    return Properties.Resources.priority_low_1;

                case "30":
                    return Properties.Resources.priority_normal;

                case "40":
                    return Properties.Resources.priority_1;

                case "50":
                    return Properties.Resources.priority_2;

                case "60":
                    return Properties.Resources.priority_3;

                default:
                    return Properties.Resources.priority_none;
            }
        }

        private Color GetStatusColor(string status)
        {
            Color retVal;
            if (!_statusColorMapping.TryGetValue(status, out retVal))
                retVal = Color.White;

            return retVal;
        }

        public void LoadData(ConnectorSettings settings)
        {
            _settings = settings;

            InitializeStatusColorMapping();

            var mantisConnector = new org.mantisbt.www.MantisConnect(settings.RepositoryUri.ToString() + settings.WebServicePath);
            var cred = mantisConnector.GetUserCredential();

            mantisConnector.mc_filter_getCompleted += (s, e) =>
              {
                  if (e.Error != null || e.Cancelled)
                  {
                      if (e.Error != null)
                      {
                          MessageBox.Show("Couldn't get issue filters: " + e.Error.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      }
                      mantisConnector.ConfirmUserCredential(false);
                  }
                  else
                  {
                      mantisConnector.ConfirmUserCredential(true);
                      var filters = e.Result;
                      var filterData = new org.mantisbt.www.FilterData() { name = "[No filter]", id = "-1" };
                      Array.Reverse(filters);
                      Array.Resize(ref filters, filters.Length + 1);
                      Array.Reverse(filters);
                      filters[0] = filterData;
                      tscbFilter.ComboBox.DataSource = filters;
                      tscbFilter.ComboBox.DisplayMember = "name";
                  }

                  mantisConnector.Dispose();
              };

            lbCurrentAction.Text = "Getting filters...";

            mantisConnector.mc_filter_getAsync(cred.UserName, cred.Password, settings.ProjectId.ToString());
        }

        private void tscbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBusyIndicator.Visible = true;
            DisplayIssues(((org.mantisbt.www.FilterData)tscbFilter.SelectedItem).id, _currentPage);
        }

        private void tsbtnNext_Click(object sender, EventArgs e)
        {
            pnlBusyIndicator.Visible = true;
            DisplayIssues(((org.mantisbt.www.FilterData)tscbFilter.SelectedItem).id, _currentPage + 1);
        }

        private void tsbtnPrev_Click(object sender, EventArgs e)
        {
            pnlBusyIndicator.Visible = true;
            DisplayIssues(((org.mantisbt.www.FilterData)tscbFilter.SelectedItem).id, _currentPage - 1);
        }

        private void tsbtnFirst_Click(object sender, EventArgs e)
        {
            pnlBusyIndicator.Visible = true;
            DisplayIssues(((org.mantisbt.www.FilterData)tscbFilter.SelectedItem).id, 1);
        }

        private void tstxtPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int newPage;

                if (int.TryParse(tstxtPage.Text, out newPage))
                {
                    pnlBusyIndicator.Visible = true;
                    DisplayIssues(((org.mantisbt.www.FilterData)tscbFilter.SelectedItem).id, newPage);
                }
                else
                    System.Media.SystemSounds.Beep.Play();
            }
        }

        private void dgvIssues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var row = dgvIssues.Rows[e.RowIndex];

                if ((bool)row.Cells[0].EditedFormattedValue)
                    _selectedIssues.Add(((org.mantisbt.www.IssueData)row.Tag));
                else
                    _selectedIssues.Remove(((org.mantisbt.www.IssueData)row.Tag));
            }
        }

        private void dgvIssues_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column == priorityDataGridViewImageColumn)
            {
                var issueA = ((org.mantisbt.www.IssueData)dgvIssues.Rows[e.RowIndex1].Tag);
                var issueB = ((org.mantisbt.www.IssueData)dgvIssues.Rows[e.RowIndex2].Tag);

                e.SortResult = int.Parse(issueA.priority.id).CompareTo(int.Parse(issueB.priority.id));

                e.Handled = true;
            }
        }

        private void tsbtnNew_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not implemented yet", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            pnlBusyIndicator.Visible = true;
            DisplayIssues(_currentFilter, _currentPage);
        }

    }
}
