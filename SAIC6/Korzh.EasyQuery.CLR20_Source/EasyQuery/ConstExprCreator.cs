namespace Korzh.EasyQuery
{
    using System;

    internal class ConstExprCreator : IExpressionCreator
    {
        public Expression Create(DataModel model)
        {
            return new ConstExpr(DataType.String, DataKind.Scalar);
        }
    }
}

