namespace Korzh.EasyQuery
{
    using System;

    internal class CustomListValueEditorCreator : IValueEditorCreator
    {
        public ValueEditor Create()
        {
            return new CustomListValueEditor();
        }
    }
}

