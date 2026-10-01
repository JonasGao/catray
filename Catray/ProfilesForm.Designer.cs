namespace Catray
{
    partial class ProfilesForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            hostingProfile = new HostingProfileBox();
            SuspendLayout();
            // 
            // hostingProfile
            // 
            hostingProfile.Dock = DockStyle.Fill;
            hostingProfile.Location = new Point(0, 0);
            hostingProfile.Margin = new Padding(8, 6, 8, 6);
            hostingProfile.Name = "hostingProfile";
            hostingProfile.Size = new Size(919, 641);
            hostingProfile.TabIndex = 0;
            hostingProfile.Cancel += HostingProfile_Cancel;
            hostingProfile.Ok += HostingProfile_Ok;
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 641);
            Controls.Add(hostingProfile);
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfigForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private HostingProfileBox hostingProfile;
    }
}