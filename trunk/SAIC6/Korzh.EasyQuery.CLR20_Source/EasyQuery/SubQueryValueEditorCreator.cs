namespace Korzh.EasyQuery
{
    using System;

    internal class SubQueryValueEditorCreator : IValueEditorCreator
    {
        public ValueEditor Create()
        {
            return new SubQueryValueEditor();
        }
    }
}

