namespace Korzh.EasyQuery
{
    using System;

    internal class ConstListValueEditorCreator : IValueEditorCreator
    {
        public ValueEditor Create()
        {
            return new ConstListValueEditor();
        }
    }
}

