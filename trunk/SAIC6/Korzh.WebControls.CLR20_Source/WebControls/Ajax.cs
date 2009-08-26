namespace Korzh.WebControls
{
    using System;
    using System.Reflection;
    using System.Web.UI;

    public class Ajax
    {
        private static Assembly ajaxAssembly;

        private static object FindScriptManager(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (ObjectIsInheritedFrom(control, "System.Web.UI.ScriptManager"))
                {
                    return control;
                }
                object obj2 = FindScriptManager(control);
                if (obj2 != null)
                {
                    return obj2;
                }
            }
            return null;
        }

        private static Type GetScriptManagerType(object obj)
        {
            for (Type type = obj.GetType(); type != null; type = type.BaseType)
            {
                if (type.FullName.Equals("System.Web.UI.ScriptManager"))
                {
                    return type;
                }
            }
            return null;
        }

        private static Type GetTypeFromAjaxAssembly(string className)
        {
            LoadAjaxAssembly();
            if (ajaxAssembly != null)
            {
                return ajaxAssembly.GetType(className);
            }
            return null;
        }

        public static bool IsControlInPartialRendering(Control control)
        {
            for (Control control2 = control.Parent; control2 != null; control2 = control2.Parent)
            {
                if (control2.GetType().FullName.Equals("System.Web.UI.UpdatePanel"))
                {
                    PropertyInfo property = control2.GetType().GetProperty("IsInPartialRendering");
                    return ((property != null) && ((bool) property.GetValue(control2, null)));
                }
            }
            return false;
        }

        public static bool IsControlInsideUpdatePanel(Control control)
        {
            for (Control control2 = control.Parent; control2 != null; control2 = control2.Parent)
            {
                if (control2.GetType().FullName.Equals("System.Web.UI.UpdatePanel"))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsInAsyncPostBack(Page page)
        {
            object obj2 = FindScriptManager(page);
            if (obj2 == null)
            {
                return false;
            }
            PropertyInfo property = GetScriptManagerType(obj2).GetProperty("IsInAsyncPostBack");
            return ((property != null) && ((bool) property.GetValue(obj2, null)));
        }

        private static void LoadAjaxAssembly()
        {
            if (ajaxAssembly == null)
            {
                ajaxAssembly = Assembly.LoadFrom("System.Web.Extensions.dll");
            }
        }

        private static bool ObjectIsInheritedFrom(object obj, string fullTypeName)
        {
            for (Type type = obj.GetType(); type != null; type = type.BaseType)
            {
                if (type.FullName.Equals(fullTypeName))
                {
                    return true;
                }
            }
            return false;
        }

        public static void RegisterClientScriptBlock(Page page, Type type, string key, string script, bool addScriptTags)
        {
            object obj2 = FindScriptManager(page);
            if (obj2 != null)
            {
                Type scriptManagerType = GetScriptManagerType(obj2);
                if (scriptManagerType != null)
                {
                    object[] args = new object[] {page, type, key, script, addScriptTags};
                    scriptManagerType.InvokeMember("RegisterClientScriptBlock",
                                                   BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static,
                                                   null, null, args);
                }
            }
        }

        public static void RegisterClientScriptInclude(Page page, Type type, string key, string url)
        {
            object obj2 = FindScriptManager(page);
            if (obj2 != null)
            {
                Type scriptManagerType = GetScriptManagerType(obj2);
                if (scriptManagerType != null)
                {
                    object[] args = new object[] {page, type, key, url};
                    scriptManagerType.InvokeMember("RegisterClientScriptInclude",
                                                   BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static,
                                                   null, null, args);
                }
            }
        }

        public static void RegisterClientScriptResource(Page page, Type type, string resourceName)
        {
            object obj2 = FindScriptManager(page);
            if (obj2 != null)
            {
                Type scriptManagerType = GetScriptManagerType(obj2);
                if (scriptManagerType != null)
                {
                    object[] args = new object[] {page, type, resourceName};
                    scriptManagerType.InvokeMember("RegisterClientScriptResource",
                                                   BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static,
                                                   null, null, args);
                }
            }
        }
    }
}