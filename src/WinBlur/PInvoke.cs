using System;
using System.Runtime.InteropServices;

namespace WinBlur
{
	public class PInvoke
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
			public static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref PInvoke.ParameterTypes.MARGINS pMarInset);

			[DllImport("dwmapi.dll")]
			public static extern int DwmSetWindowAttribute(IntPtr hwnd, PInvoke.ParameterTypes.DWMWINDOWATTRIBUTE dwAttribute, ref int pvAttribute, int cbAttribute);

			public static int ExtendFrame(IntPtr hwnd, PInvoke.ParameterTypes.MARGINS margins)
			{
				return PInvoke.Methods.DwmExtendFrameIntoClientArea(hwnd, ref margins);
			}

			public static int SetWindowAttribute(IntPtr hwnd, PInvoke.ParameterTypes.DWMWINDOWATTRIBUTE attribute, int parameter)
			{
				return PInvoke.Methods.DwmSetWindowAttribute(hwnd, attribute, ref parameter, Marshal.SizeOf<int>());
			}
		}
	}
}
