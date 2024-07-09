namespace ProjectManagementSystem.View
{
    partial class ProjectViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectViewForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bugsGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addBugToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editBugToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteBugToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshBugsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tasksGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addTaskToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editTaskToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteTaskToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshTasksToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bugsGridView)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bugsGridView);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tasksGridView);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(948, 559);
            this.splitContainer1.SplitterDistance = 473;
            this.splitContainer1.TabIndex = 0;
            // 
            // bugsGridView
            // 
            this.bugsGridView.AllowUserToAddRows = false;
            this.bugsGridView.AllowUserToDeleteRows = false;
            this.bugsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.bugsGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.bugsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bugsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bugsGridView.Location = new System.Drawing.Point(0, 25);
            this.bugsGridView.Name = "bugsGridView";
            this.bugsGridView.ReadOnly = true;
            this.bugsGridView.RowTemplate.Height = 25;
            this.bugsGridView.Size = new System.Drawing.Size(473, 534);
            this.bugsGridView.TabIndex = 0;
            this.bugsGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.bugsGridView_CellMouseDoubleClick);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripSeparator2,
            this.addBugToolStripButton,
            this.editBugToolStripButton,
            this.deleteBugToolStripButton,
            this.refreshBugsToolStripButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(473, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(54, 22);
            this.toolStripLabel2.Text = "Bugs List";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // addBugToolStripButton
            // 
            this.addBugToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addBugToolStripButton.Image")));
            this.addBugToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addBugToolStripButton.Name = "addBugToolStripButton";
            this.addBugToolStripButton.Size = new System.Drawing.Size(49, 22);
            this.addBugToolStripButton.Text = "Add";
            this.addBugToolStripButton.Click += new System.EventHandler(this.addBugToolStripButton_Click);
            // 
            // editBugToolStripButton
            // 
            this.editBugToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editBugToolStripButton.Image")));
            this.editBugToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editBugToolStripButton.Name = "editBugToolStripButton";
            this.editBugToolStripButton.Size = new System.Drawing.Size(47, 22);
            this.editBugToolStripButton.Text = "Edit";
            this.editBugToolStripButton.Click += new System.EventHandler(this.editBugToolStripButton_Click);
            // 
            // deleteBugToolStripButton
            // 
            this.deleteBugToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteBugToolStripButton.Image")));
            this.deleteBugToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteBugToolStripButton.Name = "deleteBugToolStripButton";
            this.deleteBugToolStripButton.Size = new System.Drawing.Size(60, 22);
            this.deleteBugToolStripButton.Text = "Delete";
            this.deleteBugToolStripButton.Click += new System.EventHandler(this.deleteBugToolStripButton_Click);
            // 
            // refreshBugsToolStripButton
            // 
            this.refreshBugsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshBugsToolStripButton.Image")));
            this.refreshBugsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshBugsToolStripButton.Name = "refreshBugsToolStripButton";
            this.refreshBugsToolStripButton.Size = new System.Drawing.Size(66, 22);
            this.refreshBugsToolStripButton.Text = "Refresh";
            this.refreshBugsToolStripButton.Click += new System.EventHandler(this.refreshBugsToolStripButton_Click);
            // 
            // tasksGridView
            // 
            this.tasksGridView.AllowUserToAddRows = false;
            this.tasksGridView.AllowUserToDeleteRows = false;
            this.tasksGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tasksGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tasksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tasksGridView.Location = new System.Drawing.Point(0, 25);
            this.tasksGridView.Name = "tasksGridView";
            this.tasksGridView.ReadOnly = true;
            this.tasksGridView.RowTemplate.Height = 25;
            this.tasksGridView.Size = new System.Drawing.Size(471, 534);
            this.tasksGridView.TabIndex = 0;
            this.tasksGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tasksGridView_CellMouseDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.addTaskToolStripButton,
            this.editTaskToolStripButton,
            this.deleteTaskToolStripButton,
            this.refreshTasksToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(471, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "Tasks List";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // addTaskToolStripButton
            // 
            this.addTaskToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addTaskToolStripButton.Image")));
            this.addTaskToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addTaskToolStripButton.Name = "addTaskToolStripButton";
            this.addTaskToolStripButton.Size = new System.Drawing.Size(49, 22);
            this.addTaskToolStripButton.Text = "Add";
            this.addTaskToolStripButton.Click += new System.EventHandler(this.addTaskToolStripButton_Click);
            // 
            // editTaskToolStripButton
            // 
            this.editTaskToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editTaskToolStripButton.Image")));
            this.editTaskToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editTaskToolStripButton.Name = "editTaskToolStripButton";
            this.editTaskToolStripButton.Size = new System.Drawing.Size(47, 22);
            this.editTaskToolStripButton.Text = "Edit";
            this.editTaskToolStripButton.Click += new System.EventHandler(this.editTaskToolStripButton_Click);
            // 
            // deleteTaskToolStripButton
            // 
            this.deleteTaskToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteTaskToolStripButton.Image")));
            this.deleteTaskToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteTaskToolStripButton.Name = "deleteTaskToolStripButton";
            this.deleteTaskToolStripButton.Size = new System.Drawing.Size(60, 22);
            this.deleteTaskToolStripButton.Text = "Delete";
            this.deleteTaskToolStripButton.Click += new System.EventHandler(this.deleteTaskToolStripButton_Click);
            // 
            // refreshTasksToolStripButton
            // 
            this.refreshTasksToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshTasksToolStripButton.Image")));
            this.refreshTasksToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshTasksToolStripButton.Name = "refreshTasksToolStripButton";
            this.refreshTasksToolStripButton.Size = new System.Drawing.Size(66, 22);
            this.refreshTasksToolStripButton.Text = "Refresh";
            this.refreshTasksToolStripButton.Click += new System.EventHandler(this.refreshTasksToolStripButton_Click);
            // 
            // ProjectViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 559);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ProjectViewForm";
            this.Text = "Project View";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bugsGridView)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView bugsGridView;
        private System.Windows.Forms.DataGridView tasksGridView;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton addBugToolStripButton;
        private System.Windows.Forms.ToolStripButton editBugToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteBugToolStripButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton addTaskToolStripButton;
        private System.Windows.Forms.ToolStripButton editTaskToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteTaskToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshBugsToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshTasksToolStripButton;
    }
}