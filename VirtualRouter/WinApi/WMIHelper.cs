using System;
using System.Management;

namespace VirtualRouter.WinApi
{
	public class WMIHelper
	{
		/// <summary>
		/// Returns the network card configuration of the specified NIC
		/// </summary>
		/// <PARAM name="settingId></PARAM>
		/// <PARAM name="ipAdresses">Array of IP</PARAM>
		/// <PARAM name="subnets">Array of subnet masks</PARAM>
		/// <PARAM name="gateways">Array of gateways</PARAM>
		/// <PARAM name="dnses">Array of DNS IP</PARAM>
		public static void GetIP(
			Guid settingId,
			out string[] ipAdresses,
			out string[] subnets,
			out string[] gateways,
			out string[] dnses)
		{
			ipAdresses = null;
			subnets = null;
			gateways = null;
			dnses = null;

			ManagementClass mc = new ManagementClass(
				"Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection moc = mc.GetInstances();

			foreach (ManagementObject mo in moc)
			{
				// Make sure this is a IP enabled device.
				// Not something like memory card or VM Ware
				//if ((bool)mo["ipEnabled"])
				{
					if (new Guid(mo["SettingId"].ToString()).Equals(settingId))
					{
						ipAdresses = (string[])mo["IPAddress"];
						subnets = (string[])mo["IPSubnet"];
						gateways = (string[])mo["DefaultIPGateway"];
						dnses = (string[])mo["DNSServerSearchOrder"];

						break;
					}
				}
			}
		}
		/// <summary>
		/// Set IP for the specified network card name
		/// </summary>
		/// <param name="IpAddresses">Comma delimited string
		///           containing one or more IP</param>
		/// <param name="SubnetMask">Subnet mask</param>
		/// <param name="Gateway">Gateway IP</param>
		/// <param name="DnsSearchOrder">Comma delimited DNS IP</param>
		public static void SetIP(
			Guid settingId,
			string IpAddresses,
			string SubnetMask,
			string Gateway,
			string DnsSearchOrder)
		{
			ManagementClass mc = new ManagementClass(
				"Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection moc = mc.GetInstances();

			foreach (ManagementObject mo in moc)
			{
				// Make sure this is a IP enabled device.
				// Not something like memory card or VM Ware
				//if ((bool)mo["IPEnabled"])
				{
					if (new Guid(mo["SettingId"].ToString()).Equals(settingId))
					{
						ManagementBaseObject newIP =
							mo.GetMethodParameters("EnableStatic");
						ManagementBaseObject newGate =
							mo.GetMethodParameters("SetGateways");
						ManagementBaseObject newDNS =
							mo.GetMethodParameters("SetDNSServerSearchOrder");

						newGate["DefaultIPGateway"] = new string[] { Gateway };
						newGate["GatewayCostMetric"] = new int[] { 1 };

						newIP["IPAddress"] = IpAddresses.Split(',');
						newIP["SubnetMask"] = new string[] { SubnetMask };

						newDNS["DNSServerSearchOrder"] = DnsSearchOrder.Split(',');

						ManagementBaseObject setIP = mo.InvokeMethod(
							"EnableStatic", newIP, null);
						ManagementBaseObject setGateways = mo.InvokeMethod(
							"SetGateways", newGate, null);
						ManagementBaseObject setDNS = mo.InvokeMethod(
							"SetDNSServerSearchOrder", newDNS, null);

						break;
					}
				}
			}
		}
	}
}
