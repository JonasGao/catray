using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp1
{
    public partial class HostingProfileBox : UserControl
    {
        public event EventHandler Cancel;
        public event EventHandler Ok;

        private int editIndex;

        private bool Editing
        {
            get { return resetButton.Visible; }
            set
            {
                resetButton.Visible = value;
                saveButton.Text = value ? "Save" : "Add";
            }
        }

        public HostingProfileBox()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string url = urlTextBox.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Profile name can not be null or empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Profile URL can not be null or empty.");
                return;
            }
            nameTextBox.Text = "";
            urlTextBox.Text = "";
            if (Editing)
            {
                ListViewItem item = profileListView.Items[editIndex];
                item.SubItems[0].Text = name;
                item.SubItems[1].Text = url;
                Editing = false;
            }
            else
            {
                foreach(ListViewItem item in profileListView.Items)
                {
                    if (item.Text == name)
                    {
                        MessageBox.Show("Profile name already exists.");
                        return;
                    }
                }
                profileListView.Items.Add(new ListViewItem(new string[] { name, url }));
            }
        }

        private void ProfileListView_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = profileListView.SelectedItems[0];
            editIndex = item.Index;
            nameTextBox.Text = item.SubItems[0].Text;
            urlTextBox.Text = item.SubItems[1].Text;
            Editing = true;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Editing = false;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in profileListView.CheckedItems)
            {
                profileListView.Items.Remove(item);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Cancel?.Invoke(this, EventArgs.Empty);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            HostingProfileOkEventArgs args = new();
            List<HostingProfile> profiles = args.profiles;
            foreach (ListViewItem item in profileListView.Items)
            {
                HostingProfile profile = new()
                {
                    Name = item.SubItems[0].Text,
                    URL = item.SubItems[1].Text,
                };
                profiles.Add(profile);
            }
            Ok?.Invoke(this, args);
        }

        internal void LoadProfiles(Config config)
        {
            foreach (var item in config.Profiles)
            {
                profileListView.Items.Add(new ListViewItem(new string[] { item.Name, item.URL}));
            }
        }
    }

    public class HostingProfileOkEventArgs: EventArgs
    {
        internal List<HostingProfile> profiles = new();
    }
}
