using System.ComponentModel;

namespace ProjectManagementSystem
{
    partial class ProjectsListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectsListForm));
            this.projectGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.addProjectToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editProjectToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteProjectToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.projectGridView)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // projectGridView
            // 
            this.projectGridView.AllowUserToAddRows = false;
            this.projectGridView.AllowUserToDeleteRows = false;
            this.projectGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projectGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectGridView.Location = new System.Drawing.Point(0, 25);
            this.projectGridView.Name = "projectGridView";
            this.projectGridView.ReadOnly = true;
            this.projectGridView.RowTemplate.Height = 25;
            this.projectGridView.Size = new System.Drawing.Size(800, 425);
            this.projectGridView.TabIndex = 0;
            this.projectGridView.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.projectGridView_RowHeaderMouseDoubleClick);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProjectToolStripButton,
            this.editProjectToolStripButton,
            this.deleteProjectToolStripButton,
            this.refreshToolStripButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(800, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // addProjectToolStripButton
            // 
            this.addProjectToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addProjectToolStripButton.Image")));
            this.addProjectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addProjectToolStripButton.Name = "addProjectToolStripButton";
            this.addProjectToolStripButton.Size = new System.Drawing.Size(49, 22);
            this.addProjectToolStripButton.Text = "Add";
            this.addProjectToolStripButton.Click += new System.EventHandler(this.addProjectToolStripButton_Click);
            // 
            // editProjectToolStripButton
            // 
            this.editProjectToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editProjectToolStripButton.Image")));
            this.editProjectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editProjectToolStripButton.Name = "editProjectToolStripButton";
            this.editProjectToolStripButton.Size = new System.Drawing.Size(47, 22);
            this.editProjectToolStripButton.Text = "Edit";
            this.editProjectToolStripButton.Click += new System.EventHandler(this.editProjectToolStripButton_Click);
            // 
            // deleteProjectToolStripButton
            // 
            this.deleteProjectToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteProjectToolStripButton.Image")));
            this.deleteProjectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteProjectToolStripButton.Name = "deleteProjectToolStripButton";
            this.deleteProjectToolStripButton.Size = new System.Drawing.Size(60, 22);
            this.deleteProjectToolStripButton.Text = "Delete";
            this.deleteProjectToolStripButton.Click += new System.EventHandler(this.deleteProjectToolStripButton_Click);
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripButton.Image")));
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(66, 22);
            this.refreshToolStripButton.Text = "Refresh";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // ProjectsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.projectGridView);
            this.Controls.Add(this.toolStrip2);
            this.Name = "ProjectsListForm";
            this.Text = "Projects List";
            ((System.ComponentModel.ISupportInitialize)(this.projectGridView)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView projectGridView;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton addProjectToolStripButton;
        private System.Windows.Forms.ToolStripButton editProjectToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteProjectToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
    }
}