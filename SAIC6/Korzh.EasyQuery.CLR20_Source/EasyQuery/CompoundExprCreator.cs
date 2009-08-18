namespace Korzh.EasyQuery
{
    using System;

    internal class CompoundExprCreator : IExpressionCreator
    {
        public Expression Create(DataModel model)
        {
            return new CompoundExpr(model);
        }
    }
}

