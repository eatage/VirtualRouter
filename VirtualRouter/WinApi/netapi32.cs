using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using VirtualRouter.Extensions;

namespace VirtualRouter.WinApi
{
	/// <summary>
	/// 共享操作类。对win32共享函数做了下简单封装
	/// </summary>
	public class FileSharingHelper
	{
		public event EventHandler SharedFoldersChanged = (_s, _e) => {
		};
		
		/// <summary>
		/// 共享某个文件夹
		/// </summary>
		/// <param name="path">路径</param>
		/// <returns>生成的共享名（目前实现是取目录名，会有重名问题）</returns>
		public string ShareFolder(
			string path)
		{
			if(!Directory.Exists(path))
				throw new Exception("目录不存在");
			if (IsShared(path))
				throw new Exception("路径已被共享");
			
			SHARE_INFO_502 info = new SHARE_INFO_502();
			info.shi502_netname = Path.GetFileNameWithoutExtension(path);
			info.shi502_type = (uint)SHARE_TYPE.STYPE_DISKTREE;
			info.shi502_remark = "";
			info.shi502_permissions = (int)SHARE_PERMISSIONS.ACCESS_ALL;
			info.shi502_max_uses = -1;
			info.shi502_current_uses = 0;
			info.shi502_path = path;
			info.shi502_passwd = IntPtr.Zero;
			info.shi502_reserved = 0;
			info.shi502_security_descriptor = IntPtr.Zero;
			uint err;
			var result = netapi32.NetShareAdd(null, 502, ref info, out err);
			if (result != 0) {
				string errMsg = null;
				if (Enum.IsDefined(typeof(NetError), result)) {
					errMsg = "。描述：" + ((NetError)result).ToString();
				}
				throw new Exception(String.Format("共享失败，错误码：{0},{1}{2}", result, err, errMsg));
			}
			SharedFoldersChanged(this, EventArgs.Empty);
			return info.shi502_netname;
		}
		
		public void StopShare(string name)
		{
			var result = netapi32.NetShareDel(null, name, 0);
			if (result != (uint)NetError.NERR_Success) {
				throw new Exception(((NetError)result).ToString());
			}
			SharedFoldersChanged(this, EventArgs.Empty);
		}
		
		public void StopShareMany(IEnumerable<String> names)
		{
			foreach (var i in names)
				StopShare(i);
		}

		/// <summary>
		/// 判断某个路径是否已被共享
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public bool IsShared(string path)
		{
			/*
				NetShareCheck这个函数返回的结果不对
				比如，已经共享了b:\test1，传入b:\test居然也返回0
				所以使用下面的方式
			*/
			return SharedFolders().Any(_ => _.Path.Trim('\\').ToLower() == path.Trim('\\').ToLower());
		}

		/// <summary>
		/// 列出所有被共享的文件夹
		/// </summary>
		/// <returns></returns>
		public IEnumerable<SHARE_INFO_502> SharedFolders()
		{
			IntPtr ptrArr = IntPtr.Zero;
			int entriesread, totalentries, resume_handle;
			netapi32.NetShareEnum(null, 502, out ptrArr, -1, out entriesread, out totalentries, out resume_handle);
			return ptrArr.AsEnumerable<SHARE_INFO_502>(entriesread).Where(_ => _.shi502_type == (uint)SHARE_TYPE.STYPE_DISKTREE);
		}
	}
	public enum NetError : uint
	{
		NERR_Success = 0,
		NERR_BASE = 2100,
		NERR_UnknownDevDir = (NERR_BASE + 16),
		NERR_DuplicateShare = (NERR_BASE + 18),
		NERR_BufTooSmall = (NERR_BASE + 23),
		ERROR_NOT_ENOUGH_MEMORY = 8,
		NERR_DeviceNotShared = 2311,
		NERR_NetNameNotFound = NERR_BASE + 210,
		ERROR_ACCESS_DENIED = 5,
		ERROR_INVALID_PARAMETER = 87,
	}

	public enum SHARE_TYPE : uint
	{
		STYPE_DISKTREE = 0,
		STYPE_PRINTQ = 1,
		STYPE_DEVICE = 2,
		STYPE_IPC = 3,
		STYPE_TEMPORARY = 0x40000000,
		STYPE_SPECIAL = 0x80000000,
	}
	public enum SHARE_PERMISSIONS : uint
	{
		ACCESS_NONE = 0,
		ACCESS_READ = 1,
		ACCESS_WRITE = 2,
		ACCESS_CREATE = 4,
		ACCESS_EXEC = 8,
		ACCESS_DELETE = 0x10,
		ACCESS_ATRIB = 0x20,
		ACCESS_PERM = 0x40,
		ACCESS_ALL = ACCESS_READ
		| ACCESS_WRITE
		| ACCESS_CREATE
		| ACCESS_EXEC
		| ACCESS_DELETE
		| ACCESS_ATRIB
		| ACCESS_PERM,
		ACCESS_GROUP = 0x8000
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SHARE_INFO_502
	{
		[MarshalAs(UnmanagedType.LPWStr)]
		public string shi502_netname;
		public uint shi502_type;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string shi502_remark;
		public Int32 shi502_permissions;
		public Int32 shi502_max_uses;
		public Int32 shi502_current_uses;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string shi502_path;
		public IntPtr shi502_passwd;
		public Int32 shi502_reserved;
		public IntPtr shi502_security_descriptor;
		
		public string Name{ get { return shi502_netname; } }
		public string Path{ get { return shi502_path; } }
	}

	public static class netapi32
	{
		[DllImport("Netapi32.dll")]
		public static extern uint NetShareAdd(
			[MarshalAs(UnmanagedType.LPWStr)] string strServer,
			Int32 dwLevel,
			ref SHARE_INFO_502 buf,
			out uint parm_err
		);
		[DllImport("netapi32.dll", SetLastError = true)]
		public static extern uint NetShareCheck(
			[MarshalAs(UnmanagedType.LPWStr)] string servername,
			[MarshalAs(UnmanagedType.LPWStr)] string device,
			out SHARE_TYPE type
		);
		
		[DllImport("Netapi32.dll", CharSet = CharSet.Unicode)]
		public static extern int NetShareEnum(
			StringBuilder ServerName,
			int level,
			out IntPtr bufPtr,
			int prefmaxlen,
			out int entriesread,
			out int totalentries,
			out int resume_handle
		);
		
		[DllImport("netapi32.dll", SetLastError = true)]
		public static extern uint NetShareDel(
			[MarshalAs(UnmanagedType.LPWStr)] string strServer,
			[MarshalAs(UnmanagedType.LPWStr)] string strNetName,
			Int32 reserved //must be 0
		);
	}
}
