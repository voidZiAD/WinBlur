using System;
using System.Windows.Forms;

namespace WinBlur
{
    public class UI
    {
        public static void SetBlurStyle(Control cntrl, BlurType blurType, Mode designMode)
        {
            PInvoke.ParameterTypes.MARGINS bounds = default;

            IntPtr hwnd = cntrl.Handle;
            bounds.cxLeftWidth = 0;
            bounds.cxRightWidth = 0;
            bounds.cyTopHeight = cntrl.Height;
            bounds.cyBottomHeight = 0;

            PInvoke.Methods.DwmExtendFrameIntoClientArea(hwnd, ref bounds);

            int blurTypeValue = blurType == BlurType.None ? 1 :
                                blurType == BlurType.Mica ? 2 :
                                blurType == BlurType.Acrylic ? 3 :
                                blurType == BlurType.Tabbed ? 4 : 1;

            PInvoke.Methods.SetWindowAttribute(cntrl.Handle, PInvoke.ParameterTypes.DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE, blurTypeValue);
            PInvoke.Methods.SetWindowAttribute(cntrl.Handle, PInvoke.ParameterTypes.DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE, designMode == Mode.LightMode ? 0 : 1);
        }

        public enum BlurType
        {
            None,
            Acrylic,
            Mica,
            Tabbed
        }

        public enum Mode
        {
            LightMode,
            DarkMode
        }
    }
}
