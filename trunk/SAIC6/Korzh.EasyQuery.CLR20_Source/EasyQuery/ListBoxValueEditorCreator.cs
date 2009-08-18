namespace Korzh.EasyQuery
{
    using System;

    internal class ListBoxValueEditorCreator : IValueEditorCreator
    {
        public ValueEditor Create()
        {
            ConstListValueEditor editor = new ConstListValueEditor();
            editor.ControlType = "LISTBOX";
            return editor;
        }
    }
}

