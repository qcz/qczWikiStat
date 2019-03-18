namespace qczWikiStat
{
    partial class NamespacesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Fő");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Vita");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("");
            this.introLabel = new System.Windows.Forms.Label();
            this.namespacesListView = new System.Windows.Forms.ListView();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.selectAllLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.selectNoneLabel = new System.Windows.Forms.LinkLabel();
            this.invertLabel = new System.Windows.Forms.LinkLabel();
            this.contentLabel = new System.Windows.Forms.LinkLabel();
            this.discussionLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // introLabel
            // 
            this.introLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.introLabel.Location = new System.Drawing.Point(12, 9);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(316, 46);
            this.introLabel.TabIndex = 0;
            this.introLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // namespacesListView
            // 
            this.namespacesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.namespacesListView.CheckBoxes = true;
            listViewItem9.StateImageIndex = 0;
            listViewItem10.StateImageIndex = 0;
            listViewItem11.StateImageIndex = 0;
            listViewItem12.StateImageIndex = 0;
            listViewItem13.StateImageIndex = 0;
            listViewItem14.StateImageIndex = 0;
            listViewItem15.StateImageIndex = 0;
            listViewItem16.StateImageIndex = 0;
            this.namespacesListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16});
            this.namespacesListView.Location = new System.Drawing.Point(12, 58);
            this.namespacesListView.Name = "namespacesListView";
            this.namespacesListView.Size = new System.Drawing.Size(316, 232);
            this.namespacesListView.TabIndex = 9;
            this.namespacesListView.Tag = "";
            this.namespacesListView.UseCompatibleStateImageBehavior = false;
            this.namespacesListView.View = System.Windows.Forms.View.List;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(172, 320);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(253, 320);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Mégse";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // selectAllLabel
            // 
            this.selectAllLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectAllLabel.AutoSize = true;
            this.selectAllLabel.Location = new System.Drawing.Point(66, 293);
            this.selectAllLabel.Name = "selectAllLabel";
            this.selectAllLabel.Size = new System.Drawing.Size(39, 13);
            this.selectAllLabel.TabIndex = 12;
            this.selectAllLabel.TabStop = true;
            this.selectAllLabel.Text = "összes";
            this.selectAllLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.selectAllLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Kijelölés:";
            // 
            // selectNoneLabel
            // 
            this.selectNoneLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectNoneLabel.AutoSize = true;
            this.selectNoneLabel.Location = new System.Drawing.Point(111, 293);
            this.selectNoneLabel.Name = "selectNoneLabel";
            this.selectNoneLabel.Size = new System.Drawing.Size(47, 13);
            this.selectNoneLabel.TabIndex = 14;
            this.selectNoneLabel.TabStop = true;
            this.selectNoneLabel.Text = "semelyik";
            this.selectNoneLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.selectNoneLabel_LinkClicked);
            // 
            // invertLabel
            // 
            this.invertLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.invertLabel.AutoSize = true;
            this.invertLabel.Location = new System.Drawing.Point(164, 293);
            this.invertLabel.Name = "invertLabel";
            this.invertLabel.Size = new System.Drawing.Size(41, 13);
            this.invertLabel.TabIndex = 15;
            this.invertLabel.TabStop = true;
            this.invertLabel.Text = "invertál";
            this.invertLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.invertLabel_LinkClicked);
            // 
            // contentLabel
            // 
            this.contentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.contentLabel.AutoSize = true;
            this.contentLabel.Location = new System.Drawing.Point(211, 293);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(44, 13);
            this.contentLabel.TabIndex = 16;
            this.contentLabel.TabStop = true;
            this.contentLabel.Text = "tartalom";
            this.contentLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.contentLabel_LinkClicked);
            // 
            // discussionLabel
            // 
            this.discussionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.discussionLabel.AutoSize = true;
            this.discussionLabel.Location = new System.Drawing.Point(261, 293);
            this.discussionLabel.Name = "discussionLabel";
            this.discussionLabel.Size = new System.Drawing.Size(24, 13);
            this.discussionLabel.TabIndex = 17;
            this.discussionLabel.TabStop = true;
            this.discussionLabel.Text = "vita";
            this.discussionLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.discussionLabel_LinkClicked);
            // 
            // NamespacesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 355);
            this.Controls.Add(this.discussionLabel);
            this.Controls.Add(this.contentLabel);
            this.Controls.Add(this.invertLabel);
            this.Controls.Add(this.selectNoneLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectAllLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.namespacesListView);
            this.Controls.Add(this.introLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(356, 393);
            this.Name = "NamespacesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Névterek kiválasztása";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label introLabel;
        private System.Windows.Forms.ListView namespacesListView;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.LinkLabel selectAllLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel selectNoneLabel;
        private System.Windows.Forms.LinkLabel invertLabel;
        private System.Windows.Forms.LinkLabel contentLabel;
        private System.Windows.Forms.LinkLabel discussionLabel;
    }
}