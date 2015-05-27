using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace VirtualRouter.Extensions
{
	public static class SystemExtension
	{
		/// <summary>
		/// 根据数组首地址枚举出所有元素
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="self"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static IEnumerable<T> AsEnumerable<T>(this IntPtr self, int length)
		{
			int size = Marshal.SizeOf(typeof(T));
			for (int i = 0; i < length; ++i) {
				yield return self.Dereference<T>();
				self += size;
			}
		}
        
		/// <summary>
		/// 获取指针指向的对象
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static T Dereference<T>(this IntPtr self)
		{
			return (T)Marshal.PtrToStructure(self, typeof(T));
		}
	}
}
