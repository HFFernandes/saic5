namespace Korzh.EasyQuery.WebControls
{
    using Korzh.EasyQuery;
    using System;

    public interface IColumnRowCreator
    {
        ColumnRow Create(QueryColumnsPanel panel, Query.Column column, bool useCheckBox);
        string GetCaption(QueryColumnsPanel panel);
    }
}