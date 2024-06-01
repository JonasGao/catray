namespace WinFormsApp1
{
    partial class HostingProfileBox
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
            nameTextBox = new TextBox();
            urlTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            okButton = new Button();
            cancelButton = new Button();
            label3 = new Label();
            profileListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            saveButton = new Button();
            resetButton = new Button();
            deleteButton = new Button();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nameTextBox.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point);
            nameTextBox.Location = new Point(3, 20);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(617, 21);
            nameTextBox.TabIndex = 0;
            // 
            // urlTextBox
            // 
            urlTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            urlTextBox.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point);
            urlTextBox.Location = new Point(3, 64);
            urlTextBox.Multiline = true;
            urlTextBox.Name = "urlTextBox";
            urlTextBox.ScrollBars = ScrollBars.Vertical;
            urlTextBox.Size = new Size(617, 62);
            urlTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(84, 17);
            label1.TabIndex = 2;
            label1.Text = "Profile Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 44);
            label2.Name = "label2";
            label2.Size = new Size(72, 17);
            label2.TabIndex = 3;
            label2.Text = "Profile URL";
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.Location = new Point(434, 425);
            okButton.Name = "okButton";
            okButton.Size = new Size(90, 33);
            okButton.TabIndex = 4;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += OkButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.Location = new Point(530, 425);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(90, 33);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 148);
            label3.Name = "label3";
            label3.Size = new Size(51, 17);
            label3.TabIndex = 6;
            label3.Text = "Profiles";
            // 
            // profileListView
            // 
            profileListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            profileListView.CheckBoxes = true;
            profileListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            profileListView.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point);
            profileListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            profileListView.Location = new Point(3, 171);
            profileListView.MultiSelect = false;
            profileListView.Name = "profileListView";
            profileListView.Size = new Size(617, 248);
            profileListView.TabIndex = 7;
            profileListView.UseCompatibleStateImageBehavior = false;
            profileListView.View = View.Details;
            profileListView.DoubleClick += ProfileListView_DoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "URL";
            columnHeader2.Width = 400;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            saveButton.Location = new Point(530, 132);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(90, 33);
            saveButton.TabIndex = 8;
            saveButton.Text = "Add";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // resetButton
            // 
            resetButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            resetButton.Location = new Point(434, 132);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(90, 33);
            resetButton.TabIndex = 10;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Visible = false;
            resetButton.Click += ResetButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            deleteButton.Location = new Point(3, 425);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(90, 33);
            deleteButton.TabIndex = 11;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += DeleteButton_Click;
            // 
            // HostingProfileBox
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(deleteButton);
            Controls.Add(resetButton);
            Controls.Add(saveButton);
            Controls.Add(profileListView);
            Controls.Add(label3);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(urlTextBox);
            Controls.Add(nameTextBox);
            Name = "HostingProfileBox";
            Size = new Size(623, 461);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private TextBox urlTextBox;
        private Label label1;
        private Label label2;
        private Button okButton;
        private Button cancelButton;
        private Label label3;
        private ListView profileListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button saveButton;
        private Button resetButton;
        private Button deleteButton;
    }
}
