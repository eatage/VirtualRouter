using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VirtualRouter.Extensions;
using VirtualRouter.ICS;
using VirtualRouter.Properties;
using VirtualRouter.WinApi;
using VirtualRouter.Wlan;

namespace VirtualRouter.Client
{
	public partial class FrmMain : Form
	{
		static Regex RegexIP = new Regex(@"^(\d|[01]?\d\d|2[0-4]\d|25[0-5])\.(\d|[01]?\d\d|2[0-4]\d|25[0-5])\.(\d|[01]?\d\d|2[0-4]\d|25[0-5])\.(\d|[01]?\d\d|2[0-4]\d|25[0-5])$", RegexOptions.Compiled);

		private WlanManager _wlnMgr;
		private IcsManager _icsMgr;
		private FrmSharingManager _frmSharing;
		public FrmMain()
		{
			InitializeComponent();

			dgvClients.AutoGenerateColumns = false;

			_wlnMgr = new WlanManager();
			_icsMgr = new IcsManager();
			_frmSharing = new FrmSharingManager();

			//监听虚拟路由状态的改变
			_wlnMgr.StationJoin += StationChanged;
			_wlnMgr.StationJoin += (_s, _e) => {
				ntfyDock.ShowBalloonTip(500, "", "发现客户端加入连接", ToolTipIcon.Info);
			};
			_wlnMgr.StationLeave += StationChanged;
			_wlnMgr.StationStateChange += StationChanged;
			_wlnMgr.HostedNetworkStarted += HostedNetworkStateChanged;
			_wlnMgr.HostedNetworkStarted += StationChanged;
			_wlnMgr.HostedNetworkStopped += HostedNetworkStateChanged;
			_wlnMgr.HostedNetworkStopped += StationChanged;
		}
		private void RefreshConnections()
		{
			var cons = _icsMgr.Connections.Where(_ => !_.IsMatch(_wlnMgr.HostedNetworkInterfaceGuid)).ToList();
			cmbSharings.DataSource = cons;
			cmbSharings.AdjustDropDownWidth();
			cmbSharings.SelectedItem = cons.FirstOrDefault(_ => _.SharingEnabled);
		}
		private void HostedNetworkStateChanged(object sender, EventArgs e)
		{
			this.Invoke(new Action(() => {
				var captions = ((string)btnSwitch.Tag).Split('|');
				if (_wlnMgr.IsHostedNetworkStarted) {
					btnSwitch.Text = captions[1];
					ntfyDock.Icon = Resources.VirtualRouterEnabled;
					ntfyDock.ShowBalloonTip(500, "", "虚拟路由已开启", ToolTipIcon.Info);
				} else {
					btnSwitch.Text = captions[0];
					ntfyDock.Icon = Resources.VirtualRouterDisabled;
					ntfyDock.ShowBalloonTip(500, "", "虚拟路由已停止", ToolTipIcon.Info);
				}
				StartToolStripMenuItem.Visible = !(StopToolStripMenuItem.Visible = _wlnMgr.IsHostedNetworkStarted);
			}));
		}

		private void StationChanged(object sender, EventArgs e)
		{
			RefreshClients();
		}

		private void RefreshClients()
		{
			this.Invoke(new Action(() => {
				var clients = _wlnMgr.Stations.Values.AsEnumerable().ToList();
				grpClients.Text = string.Format((string)grpClients.Tag, clients.Count);
				dgvClients.DataSource = clients;
			}));
		}

		void btnSet_Click(object sender, EventArgs e)
		{
			try {
				string err = WlanManager.Validate(txtSSID.Text, txtPwd.Text);
				if (err != null) {
					this.Err("错误");
					return;
				}

				_wlnMgr.SetConnectionSettings(txtSSID.Text, (int)numMaxClients.Value);
				_wlnMgr.SetSecondaryKey(txtPwd.Text);
				_wlnMgr.SetEnable(true);
				if (cmbSharings.SelectedValue != null) {
					if (!_wlnMgr.IsHostedNetworkStarted)
						_wlnMgr.StartHostedNetwork();
					_icsMgr.EnableIcs((Guid)cmbSharings.SelectedValue, _wlnMgr.HostedNetworkInterfaceGuid);
				}
				this.Info("设置已生效！");
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		void ChkShowPwdCheckedChanged(object sender, EventArgs e)
		{
			txtPwd.PasswordChar = ((CheckBox)sender).Checked ? '\0' : '*';
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			txtSSID.Text = _wlnMgr.SSID;
			txtPwd.Text = _wlnMgr.Key;
			numMaxClients.Value = _wlnMgr.NumberOfPeers;
			RefreshConnections();
			RefreshClients();
			HostedNetworkStateChanged(null, null);
		}
		private void btnRefreshSharings_Click(object sender, EventArgs e)
		{
			RefreshConnections();
		}

		private void btnSwitch_Click(object sender, EventArgs e)
		{
			if (_wlnMgr.IsHostedNetworkStarted) {
				_wlnMgr.StopHostedNetwork();
			} else {
				_wlnMgr.StartHostedNetwork();
			}
		}

		private void ntfyDock_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left) {
				if (!Visible) {
					Visible = true;
					WindowState = FormWindowState.Normal;
				} else {
					Hide();
				}
				Activate();
			}
		}

		private void FrmMain_SizeChanged(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized) {
				Hide();
			}
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void StartToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_wlnMgr.StartHostedNetwork();
		}

		private void StopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_wlnMgr.StopHostedNetwork();
		}

		private void btnIPSet_Click(object sender, EventArgs e)
		{
			string[] ipaddrs, masks, gateways, dns;
			string currentIps = null;
			WMIHelper.GetIP(_wlnMgr.HostedNetworkInterfaceGuid, out ipaddrs, out masks, out gateways, out dns);
			ipaddrs = (ipaddrs ?? Enumerable.Empty<String>()).Where(_ => RegexIP.IsMatch(_)).ToArray();
			if (ipaddrs.Any()) {
				currentIps = String.Join(" | ", ipaddrs);
			}
			bool ok = false;
			do {
				string ipAddr = Interaction.InputBox("输入IP地址：", currentIps == null ? "设置IP" : "当前IP：" + currentIps).Replace(" ", "");
				if (ipAddr.Length == 0) {
					ok = true;
				} else {
					if (!RegexIP.IsMatch(ipAddr)) {
						this.Warn("IP地址格式不正确！");
						ok = false;
					} else {
						WMIHelper.SetIP(_wlnMgr.HostedNetworkInterfaceGuid, ipAddr, "255.255.255.0", "", "");
						this.Info("设置成功！");
						ok = true;
					}
				}
			} while (!ok);
		}

		private void btnSharingMgr_Click(object sender, EventArgs e)
		{
			_frmSharing.ShowDialog(this);
		}
	}
}
