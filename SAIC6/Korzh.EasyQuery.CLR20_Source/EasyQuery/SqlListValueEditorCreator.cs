namespace Korzh.EasyQuery
{
    using System;

    internal class SqlListValueEditorCreator : IValueEditorCreator
    {
        public ValueEditor Create()
        {
            SqlListValueEditor editor = new SqlListValueEditor();
            editor.ControlType = "LISTBOX";
            return editor;
        }
    }
}

