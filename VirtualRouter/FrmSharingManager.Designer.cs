namespace VirtualRouter.Client
{
    partial class FrmSharingManager
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fldbrwDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvSharedFolders = new System.Windows.Forms.DataGridView();
            this.ctxmuFolders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopSharingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopSharingAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shi502_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSharedFolders)).BeginInit();
            this.ctxmuFolders.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.AutoSize = true;
            this.btnBrowse.Font = new System.Drawing.Font("SimSun", 11F);
            this.btnBrowse.Location = new System.Drawing.Point(327, 8);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(71, 25);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "浏览...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Font = new System.Drawing.Font("SimSun", 11F);
            this.txtPath.Location = new System.Drawing.Point(12, 8);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(311, 24);
            this.txtPath.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("SimSun", 11F);
            this.btnAdd.Location = new System.Drawing.Point(404, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
            // 
            // dgvSharedFolders
            // 
            this.dgvSharedFolders.AllowUserToAddRows = false;
            this.dgvSharedFolders.AllowUserToDeleteRows = false;
            this.dgvSharedFolders.AllowUserToResizeRows = false;
            this.dgvSharedFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSharedFolders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSharedFolders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSharedFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSharedFolders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.shi502_path});
            this.dgvSharedFolders.ContextMenuStrip = this.ctxmuFolders;
            this.dgvSharedFolders.Location = new System.Drawing.Point(12, 39);
            this.dgvSharedFolders.Name = "dgvSharedFolders";
            this.dgvSharedFolders.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("SimSun", 11F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSharedFolders.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSharedFolders.RowHeadersVisible = false;
            this.dgvSharedFolders.RowTemplate.Height = 23;
            this.dgvSharedFolders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSharedFolders.Size = new System.Drawing.Size(467, 218);
            this.dgvSharedFolders.TabIndex = 4;
            // 
            // ctxmuFolders
            // 
            this.ctxmuFolders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.StopSharingToolStripMenuItem,
            this.StopSharingAllToolStripMenuItem,
            this.RefreshToolStripMenuItem});
            this.ctxmuFolders.Name = "ctxmuFolders";
            this.ctxmuFolders.Size = new System.Drawing.Size(149, 92);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.OpenToolStripMenuItem.Text = "打开";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // StopSharingToolStripMenuItem
            // 
            this.StopSharingToolStripMenuItem.Name = "StopSharingToolStripMenuItem";
            this.StopSharingToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.StopSharingToolStripMenuItem.Text = "取消共享";
            this.StopSharingToolStripMenuItem.Click += new System.EventHandler(this.StopSharingToolStripMenuItemClick);
            // 
            // StopSharingAllToolStripMenuItem
            // 
            this.StopSharingAllToolStripMenuItem.Name = "StopSharingAllToolStripMenuItem";
            this.StopSharingAllToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.StopSharingAllToolStripMenuItem.Text = "全部取消共享";
            this.StopSharingAllToolStripMenuItem.Click += new System.EventHandler(this.StopSharingAllToolStripMenuItemClick);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.RefreshToolStripMenuItem.Text = "刷新";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItemClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "共享名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // shi502_path
            // 
            this.shi502_path.DataPropertyName = "Path";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shi502_path.DefaultCellStyle = dataGridViewCellStyle3;
            this.shi502_path.HeaderText = "路径";
            this.shi502_path.Name = "shi502_path";
            this.shi502_path.ReadOnly = true;
            // 
            // FrmSharingManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 269);
            this.Controls.Add(this.dgvSharedFolders);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnBrowse);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "FrmSharingManager";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "共享管理（{0}个共享）";
            this.Text = "共享管理";
            this.Load += new System.EventHandler(this.FrmSharingManagerLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSharedFolders)).EndInit();
            this.ctxmuFolders.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fldbrwDlg;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvSharedFolders;
        private System.Windows.Forms.ContextMenuStrip ctxmuFolders;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StopSharingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StopSharingAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn shi502_path;
    }
}