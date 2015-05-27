namespace VirtualRouter.Client
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	this.txtPwd = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.txtSSID = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.numMaxClients = new System.Windows.Forms.NumericUpDown();
        	this.grpClients = new System.Windows.Forms.GroupBox();
        	this.dgvClients = new System.Windows.Forms.DataGridView();
        	this.btnSet = new System.Windows.Forms.Button();
        	this.cmbSharings = new System.Windows.Forms.ComboBox();
        	this.label4 = new System.Windows.Forms.Label();
        	this.chkShowPwd = new System.Windows.Forms.CheckBox();
        	this.btnRefreshSharings = new System.Windows.Forms.Button();
        	this.btnSwitch = new System.Windows.Forms.Button();
        	this.ntfyDock = new System.Windows.Forms.NotifyIcon(this.components);
        	this.ctxmuDock = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.StartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.StopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.btnIPSet = new System.Windows.Forms.Button();
        	this.btnSharingMgr = new System.Windows.Forms.Button();
        	this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	((System.ComponentModel.ISupportInitialize)(this.numMaxClients)).BeginInit();
        	this.grpClients.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
        	this.ctxmuDock.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// txtPwd
        	// 
        	this.txtPwd.Font = new System.Drawing.Font("宋体", 11F);
        	this.txtPwd.Location = new System.Drawing.Point(114, 50);
        	this.txtPwd.Margin = new System.Windows.Forms.Padding(4);
        	this.txtPwd.Name = "txtPwd";
        	this.txtPwd.PasswordChar = '*';
        	this.txtPwd.Size = new System.Drawing.Size(127, 24);
        	this.txtPwd.TabIndex = 2;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Font = new System.Drawing.Font("宋体", 11F);
        	this.label1.Location = new System.Drawing.Point(58, 55);
        	this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(37, 15);
        	this.label1.TabIndex = 3;
        	this.label1.Text = "密码";
        	// 
        	// txtSSID
        	// 
        	this.txtSSID.Font = new System.Drawing.Font("宋体", 11F);
        	this.txtSSID.Location = new System.Drawing.Point(114, 15);
        	this.txtSSID.Margin = new System.Windows.Forms.Padding(4);
        	this.txtSSID.Name = "txtSSID";
        	this.txtSSID.Size = new System.Drawing.Size(191, 24);
        	this.txtSSID.TabIndex = 2;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Font = new System.Drawing.Font("宋体", 11F);
        	this.label2.Location = new System.Drawing.Point(56, 18);
        	this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(39, 15);
        	this.label2.TabIndex = 3;
        	this.label2.Text = "SSID";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Font = new System.Drawing.Font("宋体", 11F);
        	this.label3.Location = new System.Drawing.Point(13, 87);
        	this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(82, 15);
        	this.label3.TabIndex = 3;
        	this.label3.Text = "客户端上限";
        	// 
        	// numMaxClients
        	// 
        	this.numMaxClients.Font = new System.Drawing.Font("宋体", 11F);
        	this.numMaxClients.Location = new System.Drawing.Point(114, 85);
        	this.numMaxClients.Margin = new System.Windows.Forms.Padding(4);
        	this.numMaxClients.Name = "numMaxClients";
        	this.numMaxClients.Size = new System.Drawing.Size(65, 24);
        	this.numMaxClients.TabIndex = 6;
        	this.numMaxClients.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
        	// 
        	// grpClients
        	// 
        	this.grpClients.Controls.Add(this.dgvClients);
        	this.grpClients.Font = new System.Drawing.Font("宋体", 11F);
        	this.grpClients.Location = new System.Drawing.Point(341, 13);
        	this.grpClients.Margin = new System.Windows.Forms.Padding(4);
        	this.grpClients.Name = "grpClients";
        	this.grpClients.Padding = new System.Windows.Forms.Padding(4);
        	this.grpClients.Size = new System.Drawing.Size(369, 187);
        	this.grpClients.TabIndex = 8;
        	this.grpClients.TabStop = false;
        	this.grpClients.Tag = "客户端列表（{0}）";
        	this.grpClients.Text = "客户端列表（0）";
        	// 
        	// dgvClients
        	// 
        	this.dgvClients.AllowUserToAddRows = false;
        	this.dgvClients.AllowUserToDeleteRows = false;
        	this.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        	this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Column1,
			this.Column2});
        	this.dgvClients.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvClients.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
        	this.dgvClients.Location = new System.Drawing.Point(4, 21);
        	this.dgvClients.Margin = new System.Windows.Forms.Padding(4);
        	this.dgvClients.MultiSelect = false;
        	this.dgvClients.Name = "dgvClients";
        	this.dgvClients.ReadOnly = true;
        	this.dgvClients.RowHeadersVisible = false;
        	this.dgvClients.RowTemplate.Height = 23;
        	this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgvClients.Size = new System.Drawing.Size(361, 162);
        	this.dgvClients.TabIndex = 0;
        	// 
        	// btnSet
        	// 
        	this.btnSet.AutoSize = true;
        	this.btnSet.Font = new System.Drawing.Font("宋体", 11F);
        	this.btnSet.Location = new System.Drawing.Point(202, 175);
        	this.btnSet.Margin = new System.Windows.Forms.Padding(4);
        	this.btnSet.Name = "btnSet";
        	this.btnSet.Size = new System.Drawing.Size(47, 25);
        	this.btnSet.TabIndex = 10;
        	this.btnSet.Text = "设置";
        	this.btnSet.UseVisualStyleBackColor = true;
        	this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
        	// 
        	// cmbSharings
        	// 
        	this.cmbSharings.DisplayMember = "Name";
        	this.cmbSharings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.cmbSharings.Font = new System.Drawing.Font("宋体", 11F);
        	this.cmbSharings.FormattingEnabled = true;
        	this.cmbSharings.Location = new System.Drawing.Point(114, 120);
        	this.cmbSharings.Margin = new System.Windows.Forms.Padding(4);
        	this.cmbSharings.Name = "cmbSharings";
        	this.cmbSharings.Size = new System.Drawing.Size(127, 23);
        	this.cmbSharings.TabIndex = 11;
        	this.cmbSharings.ValueMember = "Guid";
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Font = new System.Drawing.Font("宋体", 11F);
        	this.label4.Location = new System.Drawing.Point(28, 125);
        	this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(67, 15);
        	this.label4.TabIndex = 12;
        	this.label4.Text = "共享连接";
        	// 
        	// chkShowPwd
        	// 
        	this.chkShowPwd.AutoSize = true;
        	this.chkShowPwd.Font = new System.Drawing.Font("宋体", 11F);
        	this.chkShowPwd.Location = new System.Drawing.Point(256, 54);
        	this.chkShowPwd.Margin = new System.Windows.Forms.Padding(4);
        	this.chkShowPwd.Name = "chkShowPwd";
        	this.chkShowPwd.Size = new System.Drawing.Size(56, 19);
        	this.chkShowPwd.TabIndex = 13;
        	this.chkShowPwd.Text = "显示";
        	this.chkShowPwd.UseVisualStyleBackColor = true;
        	this.chkShowPwd.CheckedChanged += new System.EventHandler(this.ChkShowPwdCheckedChanged);
        	// 
        	// btnRefreshSharings
        	// 
        	this.btnRefreshSharings.AutoSize = true;
        	this.btnRefreshSharings.BackColor = System.Drawing.Color.Transparent;
        	this.btnRefreshSharings.FlatAppearance.BorderSize = 0;
        	this.btnRefreshSharings.Font = new System.Drawing.Font("宋体", 11F);
        	this.btnRefreshSharings.Location = new System.Drawing.Point(258, 119);
        	this.btnRefreshSharings.Margin = new System.Windows.Forms.Padding(4);
        	this.btnRefreshSharings.Name = "btnRefreshSharings";
        	this.btnRefreshSharings.Size = new System.Drawing.Size(47, 25);
        	this.btnRefreshSharings.TabIndex = 18;
        	this.btnRefreshSharings.Text = "刷新";
        	this.btnRefreshSharings.UseVisualStyleBackColor = false;
        	this.btnRefreshSharings.Click += new System.EventHandler(this.btnRefreshSharings_Click);
        	// 
        	// btnSwitch
        	// 
        	this.btnSwitch.AutoSize = true;
        	this.btnSwitch.Font = new System.Drawing.Font("宋体", 11F);
        	this.btnSwitch.Location = new System.Drawing.Point(258, 175);
        	this.btnSwitch.Margin = new System.Windows.Forms.Padding(4);
        	this.btnSwitch.Name = "btnSwitch";
        	this.btnSwitch.Size = new System.Drawing.Size(47, 25);
        	this.btnSwitch.TabIndex = 19;
        	this.btnSwitch.Tag = "开|关";
        	this.btnSwitch.Text = "开";
        	this.btnSwitch.UseVisualStyleBackColor = true;
        	this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
        	// 
        	// ntfyDock
        	// 
        	this.ntfyDock.ContextMenuStrip = this.ctxmuDock;
        	this.ntfyDock.Text = "虚拟路由助手";
        	this.ntfyDock.Visible = true;
        	this.ntfyDock.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ntfyDock_MouseClick);
        	// 
        	// ctxmuDock
        	// 
        	this.ctxmuDock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.StartToolStripMenuItem,
			this.StopToolStripMenuItem,
			this.toolStripSeparator1,
			this.ExitToolStripMenuItem});
        	this.ctxmuDock.Name = "ctxmuDock";
        	this.ctxmuDock.Size = new System.Drawing.Size(101, 76);
        	// 
        	// StartToolStripMenuItem
        	// 
        	this.StartToolStripMenuItem.Name = "StartToolStripMenuItem";
        	this.StartToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
        	this.StartToolStripMenuItem.Text = "开启";
        	this.StartToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
        	// 
        	// StopToolStripMenuItem
        	// 
        	this.StopToolStripMenuItem.Name = "StopToolStripMenuItem";
        	this.StopToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
        	this.StopToolStripMenuItem.Text = "停止";
        	this.StopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
        	// 
        	// toolStripSeparator1
        	// 
        	this.toolStripSeparator1.Name = "toolStripSeparator1";
        	this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
        	// 
        	// ExitToolStripMenuItem
        	// 
        	this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
        	this.ExitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
        	this.ExitToolStripMenuItem.Text = "退出";
        	this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
        	// 
        	// btnIPSet
        	// 
        	this.btnIPSet.AutoSize = true;
        	this.btnIPSet.Location = new System.Drawing.Point(131, 175);
        	this.btnIPSet.Name = "btnIPSet";
        	this.btnIPSet.Size = new System.Drawing.Size(63, 25);
        	this.btnIPSet.TabIndex = 20;
        	this.btnIPSet.Text = "IP设置";
        	this.btnIPSet.UseVisualStyleBackColor = true;
        	this.btnIPSet.Click += new System.EventHandler(this.btnIPSet_Click);
        	// 
        	// btnSharingMgr
        	// 
        	this.btnSharingMgr.AutoSize = true;
        	this.btnSharingMgr.Location = new System.Drawing.Point(28, 175);
        	this.btnSharingMgr.Name = "btnSharingMgr";
        	this.btnSharingMgr.Size = new System.Drawing.Size(92, 25);
        	this.btnSharingMgr.TabIndex = 21;
        	this.btnSharingMgr.Text = "共享文件夹";
        	this.btnSharingMgr.UseVisualStyleBackColor = true;
        	this.btnSharingMgr.Click += new System.EventHandler(this.btnSharingMgr_Click);
        	// 
        	// Column1
        	// 
        	this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.Column1.DataPropertyName = "MacAddress";
        	this.Column1.HeaderText = "MAC地址";
        	this.Column1.Name = "Column1";
        	this.Column1.ReadOnly = true;
        	this.Column1.Width = 86;
        	// 
        	// Column2
        	// 
        	this.Column2.DataPropertyName = "StateDesc";
        	this.Column2.HeaderText = "状态";
        	this.Column2.Name = "Column2";
        	this.Column2.ReadOnly = true;
        	// 
        	// FrmMain
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(723, 208);
        	this.Controls.Add(this.btnSharingMgr);
        	this.Controls.Add(this.btnIPSet);
        	this.Controls.Add(this.btnSwitch);
        	this.Controls.Add(this.btnRefreshSharings);
        	this.Controls.Add(this.chkShowPwd);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.cmbSharings);
        	this.Controls.Add(this.btnSet);
        	this.Controls.Add(this.grpClients);
        	this.Controls.Add(this.numMaxClients);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.txtSSID);
        	this.Controls.Add(this.txtPwd);
        	this.Font = new System.Drawing.Font("宋体", 11F);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.MaximizeBox = false;
        	this.Name = "FrmMain";
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "虚拟路由助手";
        	this.Load += new System.EventHandler(this.FrmMain_Load);
        	this.SizeChanged += new System.EventHandler(this.FrmMain_SizeChanged);
        	((System.ComponentModel.ISupportInitialize)(this.numMaxClients)).EndInit();
        	this.grpClients.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
        	this.ctxmuDock.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
        private System.Windows.Forms.CheckBox chkShowPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSharings;
        private System.Windows.Forms.Button btnSet;

        #endregion

        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSSID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numMaxClients;
        private System.Windows.Forms.GroupBox grpClients;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnRefreshSharings;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.NotifyIcon ntfyDock;
        private System.Windows.Forms.ContextMenuStrip ctxmuDock;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnIPSet;
        private System.Windows.Forms.Button btnSharingMgr;
    }
}

