namespace Korzh.EasyQuery
{
    using System;

    internal class CustomValueEditorCreator : IValueEditorCreator
    {
        public ValueEditor Create()
        {
            return new CustomValueEditor();
        }
    }
}

