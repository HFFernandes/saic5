namespace Korzh.EasyQuery
{
    using System;

    internal class AggrFuncExprCreator : IExpressionCreator
    {
        public Expression Create(DataModel model)
        {
            return new AggrFuncExpr(model);
        }
    }
}

