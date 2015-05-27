/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 4/17/2015
 * Time: 9:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using NUnit.Framework;
using VirtualRouter.WinApi;

namespace UnitTest
{
	[TestFixture]
	public class FileSharingHelperTest
	{
		private FileSharingHelper _hlp = new FileSharingHelper();
		[Test]
		public void ShareFolderTest()
		{
			Assert.AreEqual("test", _hlp.ShareFolder(@"b:\test"));
		}
		[Test]
		public void StopShareTest()
		{
			_hlp.StopShare("test");
		}
		
		[Test]
		public void SharedFoldersTest()
		{
			var list = _hlp.SharedFolders();
		}
		
		[Test]
		public void IsSharedTest()
		{
			Assert.False(_hlp.IsShared(@"b:\test"));
			Assert.True(_hlp.IsShared(@"b:\test1"));
			Assert.False(_hlp.IsShared(@"b:\testa"));
		}
	}
}
