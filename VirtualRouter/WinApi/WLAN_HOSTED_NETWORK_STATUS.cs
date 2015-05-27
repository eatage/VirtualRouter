using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using VirtualRouter.Extensions;

namespace VirtualRouter.Wlan.WinAPI
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WLAN_HOSTED_NETWORK_STATUS
	{
		public WLAN_HOSTED_NETWORK_STATE HostedNetworkState;
		public Guid IPDeviceID;
		public DOT11_MAC_ADDRESS wlanHostedNetworkBSSID;
		public DOT11_PHY_TYPE dot11PhyType;
		public uint ulChannelFrequency;
		public uint dwNumberOfPeers;

		//public WLAN_HOSTED_NETWORK_PEER_STATE[] PeerList;
		public IntPtr PeerList;
        		
		public void FixPeerListAddr(IntPtr ptr)
		{
			//将指向WLAN_HOSTED_NETWORK_STATUS首地址的指针偏移到PeerList成员的地方
			IntPtr offset = Marshal.OffsetOf(typeof(WLAN_HOSTED_NETWORK_STATUS), "PeerList");
			PeerList = ptr + offset.ToInt32();
		}
	}
}
