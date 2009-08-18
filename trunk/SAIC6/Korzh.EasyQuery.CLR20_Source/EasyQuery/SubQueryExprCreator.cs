namespace Korzh.EasyQuery
{
    using System;

    internal class SubQueryExprCreator : IExpressionCreator
    {
        public Expression Create(DataModel model)
        {
            return new SubQueryExpr(model);
        }
    }
}

