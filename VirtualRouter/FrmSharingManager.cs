using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using VirtualRouter.Extensions;
using VirtualRouter.WinApi;

namespace VirtualRouter.Client
{
	public partial class FrmSharingManager : Form
	{
		private FileSharingHelper _shareHlp = new FileSharingHelper();
		
		public FrmSharingManager()
		{
			InitializeComponent();
			
			dgvSharedFolders.AutoGenerateColumns = false;
			_shareHlp.SharedFoldersChanged += (_s, _e) => RefreshSharedFolders();
		}
		
		private void RefreshSharedFolders()
		{
			var list = _shareHlp.SharedFolders().ToArray();
			dgvSharedFolders.DataSource = list;
			Text = String.Format(Tag.ToString(), list.Length);
			OpenToolStripMenuItem.Enabled =	StopSharingAllToolStripMenuItem.Enabled = StopSharingToolStripMenuItem.Enabled = list.Any();
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			if (fldbrwDlg.ShowDialog(this) == DialogResult.OK) {
				this.CatchError(() => _shareHlp.ShareFolder(txtPath.Text = fldbrwDlg.SelectedPath));
			}
		}
		
		void RefreshToolStripMenuItemClick(object sender, EventArgs e)
		{
			RefreshSharedFolders();
		}
		
		void FrmSharingManagerLoad(object sender, EventArgs e)
		{
			RefreshSharedFolders();
		}
		
		void BtnAddClick(object sender, EventArgs e)
		{
			this.CatchError(() => _shareHlp.ShareFolder(txtPath.Text));
		}
	
		void StopSharingToolStripMenuItemClick(object sender, EventArgs e)
		{
			var rows = dgvSharedFolders.SelectedRows;
			_shareHlp.StopShareMany(dgvSharedFolders.SelectedRows.Cast<DataGridViewRow>().Select(_ => ((SHARE_INFO_502)_.DataBoundItem).Name));
		}
		void StopSharingAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			_shareHlp.StopShareMany(((IEnumerable<SHARE_INFO_502>)dgvSharedFolders.DataSource).Select(_ => _.Name));
		}
		void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
			foreach (DataGridViewRow i in dgvSharedFolders.SelectedRows) {
				ThreadPool.QueueUserWorkItem(_ => {
					Process.Start(((SHARE_INFO_502)i.DataBoundItem).Path);
				});
			}
		}
	}
}
