namespace Korzh.EasyQuery
{
    using System;

    internal class DateValueEditorCreator : IValueEditorCreator
    {
        public ValueEditor Create()
        {
            DateTimeValueEditor editor = new DateTimeValueEditor();
            editor.SubType = DataType.Date;
            return editor;
        }
    }
}

