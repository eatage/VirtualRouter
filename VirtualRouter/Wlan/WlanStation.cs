/*
* Virtual Router v1.0 - http://virtualrouter.codeplex.com
* Wifi Hot Spot for Windows 8, 7 and 2008 R2
* Copyright (c) 2013 Chris Pietschmann (http://pietschsoft.com)
* Licensed under the Microsoft Public License (Ms-PL)
* http://virtualrouter.codeplex.com/license
*/
using VirtualRouter.Wlan.WinAPI;

namespace VirtualRouter.Wlan
{
	public class WlanStation
	{
		public WlanStation(WLAN_HOSTED_NETWORK_PEER_STATE state)
		{
			this.State = state;
		}

		public WLAN_HOSTED_NETWORK_PEER_STATE State { get; set; }
        
		public string StateDesc {
			get {
				switch (State.PeerAuthState) {
					case WLAN_HOSTED_NETWORK_PEER_AUTH_STATE.wlan_hosted_network_peer_state_authenticated:
						return "已通过验证";
					case WLAN_HOSTED_NETWORK_PEER_AUTH_STATE.wlan_hosted_network_peer_state_invalid:
						return "无效状态";
					default:
						return "未知状态";
				}
			}
		}

		public string MacAddress {
			get {
				return this.State.PeerMacAddress.ConvertToString();
			}
		}
	}
}
