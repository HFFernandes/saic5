namespace Korzh.EasyQuery
{
    using System;

    public interface IMacroValue
    {
        string GetValue(int index);

        int Count { get; }

        string ID { get; }

        string Value { get; }
    }
}

