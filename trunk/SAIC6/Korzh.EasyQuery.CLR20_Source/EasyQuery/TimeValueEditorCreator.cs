namespace Korzh.EasyQuery
{
    using System;

    internal class TimeValueEditorCreator : IValueEditorCreator
    {
        public ValueEditor Create()
        {
            DateTimeValueEditor editor = new DateTimeValueEditor();
            editor.SubType = DataType.Time;
            return editor;
        }
    }
}

