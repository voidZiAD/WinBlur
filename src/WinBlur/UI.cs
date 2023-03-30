using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBlur
{
    public class UI
    {

        public static void SetBlurStyle(Control cntrl, BlurType blurType, Mode designMode)
        {

            PInvoke.ParameterTypes.MARGINS bounds = default(PInvoke.ParameterTypes.MARGINS);
            IntPtr hwnd = cntrl.Handle;
            bounds.cxLeftWidth = 0;
            bounds.cxRightWidth = 0;
            checked
            {
                bounds.cyTopHeight = cntrl.Height + 10000000;
                bounds.cyBottomHeight = 0;
                int result = PInvoke.Methods.DwmExtendFrameIntoClientArea(hwnd, ref bounds);
                cntrl.BackColor = Color.Black;
            }


            if (blurType == BlurType.None)
            {

                PInvoke.Methods.SetWindowAttribute(cntrl.Handle, PInvoke.ParameterTypes.DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE, 1);

            }
            if (blurType == BlurType.Mica)
            {

                PInvoke.Methods.SetWindowAttribute(cntrl.Handle, PInvoke.ParameterTypes.DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE, 2);

            }
            if (blurType == BlurType.Acrylic)
            {

                PInvoke.Methods.SetWindowAttribute(cntrl.Handle, PInvoke.ParameterTypes.DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE, 3);

            }
            if (blurType == BlurType.Tabbed)
            {

                PInvoke.Methods.SetWindowAttribute(cntrl.Handle, PInvoke.ParameterTypes.DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE, 4);

            }

            if (designMode == Mode.LightMode)
            {
                PInvoke.Methods.SetWindowAttribute(cntrl.Handle, PInvoke.ParameterTypes.DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE, 0);


            }
            if (designMode == Mode.DarkMode)
            {

                PInvoke.Methods.SetWindowAttribute(cntrl.Handle, PInvoke.ParameterTypes.DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE, 1);

            }

            cntrl.Invalidate();

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
