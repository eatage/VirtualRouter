using System;
using System.Drawing;
using System.Windows.Forms;

namespace VirtualRouter.Extensions
{
	public static class WinFormExtension
	{
		/// <summary>
		/// 调整ComboBox下拉框的宽度以适应内容大小
		/// </summary>
		/// <param name="self"></param>
		public static void AdjustDropDownWidth(this ComboBox self)
		{
			Graphics g = null;
			Font font = null;
			try {
				var width = 0;
				g = self.CreateGraphics();
				font = self.Font;
				//checks if a scrollbar will be displayed.
				//If yes, then get its width to adjust the size of the drop down list.
				var vertScrollBarWidth =
					(self.Items.Count > self.MaxDropDownItems)
                  ? SystemInformation.VerticalScrollBarWidth : 0;
				int newWidth;
				foreach (var s in self.Items) { //Loop through list items and check size of each items.
					if (s != null) {
						newWidth = (int)g.MeasureString(self.GetItemText(s).Trim(), font).Width
						+ vertScrollBarWidth;
						if (width < newWidth)
							width = newWidth; //set the width of the drop down list to the width of the largest item.
					}
				}
				self.DropDownWidth = width + 20;
			} catch {
			} finally {
				if (g != null)
					g.Dispose();
			}
		}
		public static void Info(this Form self, string msg)
		{
			MessageBox.Show(msg, "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		public static void Info(string msg)
		{
			Info(null, msg);
		}
		public static bool Ask(this Form self, string msg)
		{
			return MessageBox.Show(msg, "确认操作", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}
		public static bool Ask(string msg)
		{
			return Ask(null, msg);
		}
		public static void Err(this Form self, string msg)
		{
			MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		public static void Err(string msg)
		{
			Err(null, msg);
		}
		public static void Warn(this Form self, string msg)
		{
			MessageBox.Show(msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
		public static void Warn(string msg)
		{
			Warn(null, msg);
		}
        
		public static void CatchError(this Form self, Action act)
		{
			try {
				act();
			} catch (Exception ex) {
				self.Err(ex.Message);
			}
		}
	}
}