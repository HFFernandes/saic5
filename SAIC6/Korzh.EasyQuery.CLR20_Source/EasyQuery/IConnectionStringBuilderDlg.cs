namespace Korzh.EasyQuery
{
    using System;

    public interface IConnectionStringBuilderDlg
    {
        bool RunDialog(DbGate dbGate);

        string ConnectionString { get; }
    }
}

