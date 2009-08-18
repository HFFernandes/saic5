namespace Korzh.EasyQuery.ModelEditor
{
    using System;
    using System.Windows.Forms;

    public class XPStyle
    {
        public static void ApplyVisualStyles(Control control)
        {
            if (IsXPThemesPresent)
            {
                ChangeControlFlatStyleToSystem(control);
            }
        }

        private static void ChangeControlFlatStyleToSystem(Control control)
        {
            if (control.GetType().BaseType == typeof(ButtonBase))
            {
                ((ButtonBase) control).FlatStyle = FlatStyle.System;
            }
            for (int i = 0; i < control.Controls.Count; i++)
            {
                ChangeControlFlatStyleToSystem(control.Controls[i]);
            }
        }

        public static void EnableVisualStyles()
        {
            if (IsXPThemesPresent)
            {
                Application.EnableVisualStyles();
                Application.DoEvents();
            }
        }

        public static bool IsXPThemesPresent
        {
            get
            {
                return OSFeature.Feature.IsPresent(OSFeature.Themes);
            }
        }
    }
}

