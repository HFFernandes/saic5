namespace Korzh.EasyQuery
{
    using System;

    internal class EntityAttrExprCreator : IExpressionCreator
    {
        public Expression Create(DataModel model)
        {
            return new EntityAttrExpr(model, model.GetDefaultUICAttribute());
        }
    }
}

