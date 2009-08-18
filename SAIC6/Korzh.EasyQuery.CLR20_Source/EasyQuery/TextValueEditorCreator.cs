namespace Korzh.EasyQuery
{
    using System;

    internal class TextValueEditorCreator : IValueEditorCreator
    {
        public ValueEditor Create()
        {
            return new TextValueEditor();
        }
    }
}

