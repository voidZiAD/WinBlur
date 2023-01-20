using System;
using System.Runtime.InteropServices;

namespace WinBlur
{
	internal class PInvoke
	{
		public class ParameterTypes
		{
			[Flags]
			public enum DWMWINDOWATTRIBUTE
			{
				DWMWA_USE_IMMERSIVE_DARK_MODE = 20,
				DWMWA_SYSTEMBACKDROP_TYPE = 38
			}

			public struct MARGINS
			{
				public int cxLeftWidth;
				public int cxRightWidth;
				public int cyTopHeight;
				public int cyBottomHeight;
			}
		}

		public class Methods
		{
			[DllImport("DwmApi.dll")]
			public static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref ParameterTypes.MARGINS pMarInset);

			[DllImport("dwmapi.dll")]
			public static extern int DwmSetWindowAttribute(IntPtr hwnd, ParameterTypes.DWMWINDOWATTRIBUTE dwAttribute, ref int pvAttribute, int cbAttribute);

			public static int ExtendFrame(IntPtr hwnd, ParameterTypes.MARGINS margins)
			{
				return DwmExtendFrameIntoClientArea(hwnd, ref margins);
			}

			public static int SetWindowAttribute(IntPtr hwnd, ParameterTypes.DWMWINDOWATTRIBUTE attribute, int parameter)
			{
				return DwmSetWindowAttribute(hwnd, attribute, ref parameter, Marshal.SizeOf<int>());
			}
		}
	}
}
