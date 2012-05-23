﻿using System; 
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AnkhMantisConnector.IssueTracker.Forms
{
    internal partial class IssuesView : UserControl
    {
        private const int PER_PAGE = 100;

        private int _currentPage = 1;
        private Dictionary<string, Color> _statusColorMapping;
        private ConnectorSettings _settings;

        public IssuesView()
        {
            InitializeComponent();
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
            using (var mantisConnector = new org.mantisbt.www.MantisConnect(_settings.RepositoryUri.ToString() + "/api/soap/mantisconnect.php"))
            {
                var issues = filterId == "-1" ? 
                    mantisConnector.mc_project_get_issues(_settings.UserName, _settings.Password, _settings.ProjectId, 
                    page.ToString(), PER_PAGE.ToString()) : 
                    mantisConnector.mc_filter_get_issues(_settings.UserName, _settings.Password, _settings.ProjectId,
                    filterId, page.ToString(), PER_PAGE.ToString());

                dgvIssues.SuspendDrawing();
                dgvIssues.Rows.Clear();
                foreach (var issue in issues)
                {
                    int newIndex = dgvIssues.Rows.Add(false, GetPriorityImage(issue.priority.id), issue.id, issue.category, 
                        issue.severity.name, issue.status.name + (issue.handler != null ? " (" + issue.handler.name + ")" : string.Empty),
                        issue.summary, issue.reporter.name, issue.last_updated.ToString());

                    dgvIssues.Rows[newIndex].DefaultCellStyle.BackColor = GetStatusColor(issue.status.id);
                }
                dgvIssues.ResumeDrawing();

                dgvIssues.AutoResizeColumns();

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

                tsbtnNext.Enabled = issues.Length == PER_PAGE;
            }
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

            using (var mantisConnector = new org.mantisbt.www.MantisConnect(settings.RepositoryUri.ToString() + "/api/soap/mantisconnect.php"))
            {
                var filters = mantisConnector.mc_filter_get(settings.UserName, settings.Password, settings.ProjectId);
                var filterData = new org.mantisbt.www.FilterData() {name = "[No filter]", id = "-1"};
                Array.Reverse(filters);
                Array.Resize(ref filters, filters.Length + 1);
                Array.Reverse(filters);
                filters[0] = filterData;
                tscbFilter.ComboBox.DataSource = filters;
                tscbFilter.ComboBox.DisplayMember = "name";
            }
        }

        public void LoadData2(Uri repositoryUri, IDictionary<string, object> properties)
        {
            using (var mantisConnector = new org.mantisbt.www.MantisConnect(repositoryUri.ToString() + "/api/soap/mantisconnect.php"))
            {
                // Would prefer to get issue headers and cached versions of the users, priorities, etc.
                // However, there are documented issues when there are a lot of registered users.
                var issueHeaders = mantisConnector.mc_project_get_issue_headers(_settings.UserName, _settings.Password, _settings.ProjectId, "1", "100");
                var filters = mantisConnector.mc_filter_get(_settings.UserName, _settings.Password, _settings.ProjectId);
                var users = mantisConnector.mc_project_get_users(_settings.UserName, _settings.Password, _settings.ProjectId, "10").ToDictionary(x => x.id, x => x);
/*                lvIssues.BeginUpdate();
                for (int i = 0, count = issueHeaders.Length; i < count; i++)
                {
                    var issueHeader = issueHeaders[i];
                    var item = new ListViewItem(new[] {issueHeader.priority, issueHeader.id, issueHeader.category, 
                        issueHeader.summary, issueHeader.status + "(" + users[issueHeader.handler].name + ")", users[issueHeader.reporter].name, issueHeader.last_updated.ToString()});
                    lvIssues.Items.Add(item);
                }
                lvIssues.EndUpdate();*/
            }
        }

        private void tscbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayIssues(((org.mantisbt.www.FilterData)tscbFilter.SelectedItem).id, _currentPage);
        }

        private void tsbtnNext_Click(object sender, EventArgs e)
        {
            DisplayIssues(((org.mantisbt.www.FilterData)tscbFilter.SelectedItem).id, _currentPage + 1);
        }

        private void tsbtnPrev_Click(object sender, EventArgs e)
        {
            DisplayIssues(((org.mantisbt.www.FilterData)tscbFilter.SelectedItem).id, _currentPage - 1);
        }

        private void tsbtnFirst_Click(object sender, EventArgs e)
        {
            DisplayIssues(((org.mantisbt.www.FilterData)tscbFilter.SelectedItem).id, 1);
        }

        private void tstxtPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int newPage;

                if (int.TryParse(tstxtPage.Text, out newPage))
                    DisplayIssues(((org.mantisbt.www.FilterData)tscbFilter.SelectedItem).id, newPage);
                else
                    System.Media.SystemSounds.Beep.Play();
            }
        }

    }
}