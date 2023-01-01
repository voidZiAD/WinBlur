![ipiccy_image (2)](https://user-images.githubusercontent.com/84229419/210152610-2e2dcac6-a9de-4b8d-97fd-c0b16340cf95.jpg)
# 🪟 WinBlur (Windows 10 & Above)
WinBlur is a C#, VB, C++ .NET Library that allows developers to use modern blur types on their forms, (and maybe) controls.

**Getting Started: __3 easy steps__ to use WinBlur.**

- **Step 1.** Install `WinBlur` from NuGET.

```
Install-Package WinBlur
```

- **Step 2.** Head over to your form, and import the packages needed.

```cs
using WinBlur;
using static WinBlur.UI;
```

- **Step 3.** If **you are not** using the `None` FormBorderStyle, then create the `Form_Load` event, or head over to the form constructor and add the following code:

```cs

// cntrl: The form/control you are targetting.
// blurType: The blur type for the form/control.
// designMode: The design mode (or style) for the form/control.

// this.BackColor = Color.Black;
// The code on top is recommended, but is not necessary.
// In case the code below doesn't work by itself, please change the control/form BackColor to Black/White.

SetBlurStyle(cntrl: this, blurType: BlurType.Acrylic, designMode: Mode.DarkMode);
```

- ⚠️**WARNING:** If **you are** using the `None` FormBorderStyle, then create the `Form_Shown` event instead, and add the same code that is shown on top of this text.

- 📝**NOTE:** Using **WinBlur on Controls** is currently most likely not going to work, so this mainly just supports **Forms** right now.

For `DarkMode`, please set your `Form.BackColor` to a Dark color, preferrably `Color.Black`.
For `LightMode`, please set your `Form.BackColor` to a Light color/White color, preferrably `Color.White`.

There you have it!
Your project now supports & uses **WinBlur**.

![image](https://user-images.githubusercontent.com/84229419/210150565-e05c47d0-7a63-4381-8cb2-5ba9ed278ffa.png)

## Open Source

This project is open-source, and free to use commercially & personally. I would not like any credit for this, enjoy using it.\
If you want to contribute, feel free to make a pull request and merge it.
