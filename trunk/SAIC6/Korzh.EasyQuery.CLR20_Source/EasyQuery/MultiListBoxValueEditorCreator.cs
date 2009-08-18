namespace Korzh.EasyQuery
{
    using System;

    internal class MultiListBoxValueEditorCreator : IValueEditorCreator
    {
        public ValueEditor Create()
        {
            ConstListValueEditor editor = new ConstListValueEditor();
            editor.ControlType = "MULTILIST";
            return editor;
        }
    }
}

