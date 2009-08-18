namespace Korzh.EasyQuery
{
    public interface IExpressionCreator
    {
        Expression Create(DataModel model);
    }
}

