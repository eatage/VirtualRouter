/*
* Virtual Router v1.0 - http://virtualrouter.codeplex.com
* Wifi Hot Spot for Windows 8, 7 and 2008 R2
* Copyright (c) 2013 Chris Pietschmann (http://pietschsoft.com)
* Licensed under the Microsoft Public License (Ms-PL)
* http://virtualrouter.codeplex.com/license
*/
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using VirtualRouter.Wlan.WinAPI;
using VirtualRouter.Extensions;

namespace VirtualRouter.Wlan
{
	public class SoftAP : IDisposable
	{
		private IntPtr _WlanHandle;
		private uint _ServerVersion;

		private wlanapi.WLAN_NOTIFICATION_CALLBACK _notificationCallback;

		private WLAN_HOSTED_NETWORK_STATE _HostedNetworkState;

		protected Dictionary<string, WlanStation> _Stations = new Dictionary<string, WlanStation>();

		public SoftAP()
		{
			this._notificationCallback = new wlanapi.WLAN_NOTIFICATION_CALLBACK(this.OnNotification);
			this.Init();
		}

		private void Init()
		{
			try {
				WlanUtils.Throw_On_Win32_Error(wlanapi.WlanOpenHandle(wlanapi.WLAN_CLIENT_VERSION_VISTA, IntPtr.Zero, out this._ServerVersion, ref this._WlanHandle));


				WLAN_NOTIFICATION_SOURCE notifSource;
				WlanUtils.Throw_On_Win32_Error(wlanapi.WlanRegisterNotification(this._WlanHandle, WLAN_NOTIFICATION_SOURCE.All, true, this._notificationCallback, IntPtr.Zero, IntPtr.Zero, out notifSource));


				WLAN_HOSTED_NETWORK_REASON failReason = this.InitSettings();
				if (failReason != WLAN_HOSTED_NETWORK_REASON.wlan_hosted_network_reason_success) {
					throw new Exception("Init Error WlanHostedNetworkInitSettings: " + failReason.ToString());
				}

				//我加的
				var netStat = QueryStatus();
				_HostedNetworkState = netStat.HostedNetworkState;
				foreach (var i in netStat.PeerList) {
					WlanStation station = new WlanStation(i);
					_Stations[station.MacAddress] = station;
				}
			} catch {
				wlanapi.WlanCloseHandle(this._WlanHandle, IntPtr.Zero);
				throw;
			}
		}

		#region "Events"

		public event EventHandler HostedNetworkStarted;
		public event EventHandler HostedNetworkStopped;
		public event EventHandler HostedNetworkAvailable;

		public event EventHandler StationJoin;
		public event EventHandler StationLeave;
		public event EventHandler StationStateChange;

		#endregion

		#region "OnNotification"

		protected void onHostedNetworkStarted()
		{
			this._HostedNetworkState = WLAN_HOSTED_NETWORK_STATE.wlan_hosted_network_active;
			if (this.HostedNetworkStarted != null) {
				this.HostedNetworkStarted(this, EventArgs.Empty);
			}
		}

		protected void onHostedNetworkStopped()
		{
			this._HostedNetworkState = WLAN_HOSTED_NETWORK_STATE.wlan_hosted_network_idle;
			_Stations.Clear();//我加的

			if (this.HostedNetworkStopped != null) {
				this.HostedNetworkStopped(this, EventArgs.Empty);
			}
		}

		protected void onHostedNetworkAvailable()
		{
			this._HostedNetworkState = WLAN_HOSTED_NETWORK_STATE.wlan_hosted_network_idle;

			if (this.HostedNetworkAvailable != null) {
				this.HostedNetworkAvailable(this, EventArgs.Empty);
			}
		}

		protected void onStationJoin(WLAN_HOSTED_NETWORK_PEER_STATE stationState)
		{
			var pStation = new WlanStation(stationState);
			this._Stations[pStation.MacAddress] = pStation;

			if (this.StationJoin != null) {
				this.StationJoin(this, EventArgs.Empty);
			}
		}

		protected void onStationLeave(WLAN_HOSTED_NETWORK_PEER_STATE stationState)
		{
			this._Stations.Remove(stationState.PeerMacAddress.ConvertToString());

			if (this.StationLeave != null) {
				this.StationLeave(this, EventArgs.Empty);
			}
		}

		protected void onStationStateChange(WLAN_HOSTED_NETWORK_PEER_STATE stationState)
		{
			if (this.StationStateChange != null) {
				this.StationStateChange(this, EventArgs.Empty);
			}
		}

		protected void OnNotification(ref WLAN_NOTIFICATION_DATA notifData, IntPtr context)
		{
			switch (notifData.notificationCode) {
				case (int)WLAN_HOSTED_NETWORK_NOTIFICATION_CODE.wlan_hosted_network_state_change:

					if (notifData.dataSize > 0 && notifData.dataPtr != IntPtr.Zero) {
						WLAN_HOSTED_NETWORK_STATE_CHANGE pStateChange = (WLAN_HOSTED_NETWORK_STATE_CHANGE)Marshal.PtrToStructure(notifData.dataPtr, typeof(WLAN_HOSTED_NETWORK_STATE_CHANGE));

						switch (pStateChange.NewState) {
							case WLAN_HOSTED_NETWORK_STATE.wlan_hosted_network_active:
								this.onHostedNetworkStarted();
								break;

							case WLAN_HOSTED_NETWORK_STATE.wlan_hosted_network_idle:
								if (pStateChange.OldState == WLAN_HOSTED_NETWORK_STATE.wlan_hosted_network_active) {
									this.onHostedNetworkStopped();
								} else {
									this.onHostedNetworkAvailable();
								}
								break;

							case WLAN_HOSTED_NETWORK_STATE.wlan_hosted_network_unavailable:
								if (pStateChange.OldState == WLAN_HOSTED_NETWORK_STATE.wlan_hosted_network_active) {
									this.onHostedNetworkStopped();
								}
								this.onHostedNetworkAvailable();
								break;
						}
					}

					break;

				case (int)WLAN_HOSTED_NETWORK_NOTIFICATION_CODE.wlan_hosted_network_peer_state_change:

					if (notifData.dataSize > 0 && notifData.dataPtr != IntPtr.Zero) {
						WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE pPeerStateChange = (WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE)Marshal.PtrToStructure(notifData.dataPtr, typeof(WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE));

						if (pPeerStateChange.NewState.PeerAuthState == WLAN_HOSTED_NETWORK_PEER_AUTH_STATE.wlan_hosted_network_peer_state_authenticated) {
							// Station joined the hosted network
							this.onStationJoin(pPeerStateChange.NewState);
						} else if (pPeerStateChange.NewState.PeerAuthState == WLAN_HOSTED_NETWORK_PEER_AUTH_STATE.wlan_hosted_network_peer_state_invalid) {
							// Station left the hosted network
							this.onStationLeave(pPeerStateChange.NewState);
						} else {
							// Authentication state changed
							this.onStationStateChange(pPeerStateChange.NewState);
						}
					}

					break;

				case (int)WLAN_HOSTED_NETWORK_NOTIFICATION_CODE.wlan_hosted_network_radio_state_change:
					if (notifData.dataSize > 0 && notifData.dataPtr != IntPtr.Zero) {
						//WLAN_HOSTED_NETWORK_RADIO_STATE pRadioState = (WLAN_HOSTED_NETWORK_RADIO_STATE)Marshal.PtrToStructure(notifData.dataPtr, typeof(WLAN_HOSTED_NETWORK_RADIO_STATE));
						// Do nothing for now
					}
                    //else
                    //{
                    //    // // Shall NOT happen
                    //    // _ASSERT(FAILSE);
                    //}
					break;
			}

		}

		#endregion
		
		#region 静态成员
				
		public static string Validate(string ssid, string key)
		{
			if (ssid == null || ssid.Trim().Length == 0)
				return "SSID不能为空";
			if (key == null || key.Trim().Length == 0)
				return "密码不能为空";

			int byteCount = Encoding.GetEncoding("ASCII").GetByteCount(key);
			if (byteCount < 8 || byteCount > 63)
				return "密码应该为8到63个ASCII字符";
			return null;
		}
		#endregion

		#region "Public Methods"

		public WLAN_HOSTED_NETWORK_REASON ForceStart()
		{
			WLAN_HOSTED_NETWORK_REASON failReason;
			WlanUtils.Throw_On_Win32_Error(wlanapi.WlanHostedNetworkForceStart(this._WlanHandle, out failReason, IntPtr.Zero));

			this._HostedNetworkState = WLAN_HOSTED_NETWORK_STATE.wlan_hosted_network_active;

			return failReason;
		}

		public WLAN_HOSTED_NETWORK_REASON ForceStop()
		{
			WLAN_HOSTED_NETWORK_REASON failReason;
			WlanUtils.Throw_On_Win32_Error(wlanapi.WlanHostedNetworkForceStop(this._WlanHandle, out failReason, IntPtr.Zero));

			this._HostedNetworkState = WLAN_HOSTED_NETWORK_STATE.wlan_hosted_network_idle;

			return failReason;
		}

		public WLAN_HOSTED_NETWORK_REASON StartUsing()
		{
			WLAN_HOSTED_NETWORK_REASON failReason;
			WlanUtils.Throw_On_Win32_Error(wlanapi.WlanHostedNetworkStartUsing(this._WlanHandle, out failReason, IntPtr.Zero));

			this._HostedNetworkState = WLAN_HOSTED_NETWORK_STATE.wlan_hosted_network_active;

			return failReason;
		}

		public WLAN_HOSTED_NETWORK_REASON StopUsing()
		{
			WLAN_HOSTED_NETWORK_REASON failReason;
			WlanUtils.Throw_On_Win32_Error(wlanapi.WlanHostedNetworkStopUsing(this._WlanHandle, out failReason, IntPtr.Zero));

			this._HostedNetworkState = WLAN_HOSTED_NETWORK_STATE.wlan_hosted_network_idle;

			return failReason;
		}

		public WLAN_HOSTED_NETWORK_REASON InitSettings()
		{
			WLAN_HOSTED_NETWORK_REASON failReason;
			WlanUtils.Throw_On_Win32_Error(wlanapi.WlanHostedNetworkInitSettings(this._WlanHandle, out failReason, IntPtr.Zero));
			return failReason;
		}

		public WLAN_HOSTED_NETWORK_REASON QuerySecondaryKey(out string passKey, out bool isPassPhrase, out bool isPersistent)
		{
			WLAN_HOSTED_NETWORK_REASON failReason;
			uint keyLen;
			WlanUtils.Throw_On_Win32_Error(wlanapi.WlanHostedNetworkQuerySecondaryKey(this._WlanHandle, out keyLen, out passKey, out isPassPhrase, out isPersistent, out failReason, IntPtr.Zero));
			return failReason;
		}

		public WLAN_HOSTED_NETWORK_REASON SetSecondaryKey(string passKey)
		{
			WLAN_HOSTED_NETWORK_REASON failReason;
			WlanUtils.Throw_On_Win32_Error(wlanapi.WlanHostedNetworkSetSecondaryKey(this._WlanHandle, (uint)(passKey.Length + 1), passKey, true, true, out failReason, IntPtr.Zero));
			return failReason;
		}

		public WLAN_HOSTED_NETWORK_STATUS_Wrapper QueryStatus()
		{
			WLAN_HOSTED_NETWORK_STATUS status;
			IntPtr ptr = new IntPtr();
			var error = wlanapi.WlanHostedNetworkQueryStatus(this._WlanHandle, out ptr, IntPtr.Zero);
			status = ptr.Dereference<WLAN_HOSTED_NETWORK_STATUS>();
			WlanUtils.Throw_On_Win32_Error(error);
			var wrapper = new WLAN_HOSTED_NETWORK_STATUS_Wrapper(status);
			int structSize = Marshal.SizeOf(typeof(WLAN_HOSTED_NETWORK_PEER_STATE));
			//将指向WLAN_HOSTED_NETWORK_STATUS的指针偏移到PeerList成员的地方
			IntPtr offset = Marshal.OffsetOf(typeof(WLAN_HOSTED_NETWORK_STATUS), "PeerList");
         
			IntPtr peerListPtr = ptr + offset.ToInt32();
			wrapper.PeerList.AddRange(peerListPtr.ToEnumerable<WLAN_HOSTED_NETWORK_PEER_STATE>((int)status.dwNumberOfPeers));
			return wrapper;
		}

		public WLAN_HOSTED_NETWORK_REASON SetConnectionSettings(string hostedNetworkSSID, int maxNumberOfPeers)
		{
			WLAN_HOSTED_NETWORK_REASON failReason;

			WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS settings = new WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS();
			settings.hostedNetworkSSID = WlanUtils.ConvertStringToDOT11_SSID(hostedNetworkSSID);
			settings.dwMaxNumberOfPeers = (uint)maxNumberOfPeers;

			IntPtr settingsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(settings));
			try {
				Marshal.StructureToPtr(settings, settingsPtr, false);

				WlanUtils.Throw_On_Win32_Error(
					wlanapi.WlanHostedNetworkSetProperty(
						this._WlanHandle,
						WLAN_HOSTED_NETWORK_OPCODE.wlan_hosted_network_opcode_connection_settings,
						(uint)Marshal.SizeOf(settings), settingsPtr, out failReason, IntPtr.Zero
					)
				);
			} finally {
				Marshal.FreeHGlobal(settingsPtr);
			}


			return failReason;
		}

		/// <summary>
		/// 设置启用状态
		/// </summary>
		/// <param name="enable"></param>
		public void SetEnable(bool enable)
		{
			WLAN_HOSTED_NETWORK_REASON failReason;
			int value = enable ? 1 : 0;
			IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(value));
			try {
				Marshal.StructureToPtr(value, ptr, false);
				wlanapi.WlanHostedNetworkSetProperty(this._WlanHandle, WLAN_HOSTED_NETWORK_OPCODE.wlan_hosted_network_opcode_enable, (uint)Marshal.SizeOf(value), ptr, out failReason, IntPtr.Zero);
			} finally {
				Marshal.FreeHGlobal(ptr);
			}
		}

		public WLAN_OPCODE_VALUE_TYPE QueryConnectionSettings(out string hostedNetworkSSID, out int maxNumberOfPeers)
		{
			uint dataSize;
			IntPtr dataPtr;
			WLAN_OPCODE_VALUE_TYPE opcode;

			WlanUtils.Throw_On_Win32_Error(
				wlanapi.WlanHostedNetworkQueryProperty(
					this._WlanHandle,
					WLAN_HOSTED_NETWORK_OPCODE.wlan_hosted_network_opcode_connection_settings,
					out dataSize, out dataPtr, out opcode, IntPtr.Zero
				)
			);

			var settings = dataPtr.Dereference<WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS>();

			hostedNetworkSSID = settings.hostedNetworkSSID.ConvertToString();

			maxNumberOfPeers = (int)settings.dwMaxNumberOfPeers;

			return opcode;
		}

		public void StartHostedNetwork()
		{
			try {
				this.ForceStop();

				var failReason = this.StartUsing();
				if (failReason != WLAN_HOSTED_NETWORK_REASON.wlan_hosted_network_reason_success) {
					throw new Exception("Could Not Start Hosted Network!\n\n" + failReason.ToString());
				}
			} catch {
				this.ForceStop();
				throw;
			}
		}

		public void StopHostedNetwork()
		{
			this.ForceStop();
		}

		#endregion

		#region "Properties"

		public Guid HostedNetworkInterfaceGuid {
			get {
				var status = this.QueryStatus();
				return status.IPDeviceID;
			}
		}

		public WLAN_HOSTED_NETWORK_STATE HostedNetworkState {
			get {
				return this._HostedNetworkState;
			}
		}

		public Dictionary<string, WlanStation> Stations {
			get {
				return this._Stations;
			}
		}

		public bool IsHostedNetworkStarted {
			get {
				return (this._HostedNetworkState == WLAN_HOSTED_NETWORK_STATE.wlan_hosted_network_active);
			}
		}
        
		public string SSID {
			get {
				string ssid;
				int clientNum;
				QueryConnectionSettings(out ssid, out clientNum);
				return ssid;
			}
		}
		
		public int NumberOfPeers {
			get {
				string ssid;
				int clientNum;
				QueryConnectionSettings(out ssid, out clientNum);
				return clientNum;
			}
		}
		
		public string Key {
			get {
				string key;
				bool temp;
				QuerySecondaryKey(out key, out temp, out temp);
				return key;
			}
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			this.ForceStop();

			if (this._WlanHandle != IntPtr.Zero) {
				wlanapi.WlanCloseHandle(this._WlanHandle, IntPtr.Zero);
			}
		}

		#endregion
	}
}
