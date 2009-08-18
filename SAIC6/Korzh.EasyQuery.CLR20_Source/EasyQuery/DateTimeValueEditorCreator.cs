namespace Korzh.EasyQuery
{
    using System;

    internal class DateTimeValueEditorCreator : IValueEditorCreator
    {
        public ValueEditor Create()
        {
            return new DateTimeValueEditor();
        }
    }
}

