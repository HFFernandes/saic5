namespace Korzh.EasyQuery
{
    using System;

    public class CompoundExpr : Expression
    {
        private DataModel model;

        public CompoundExpr(DataModel model)
        {
            this.model = model;
        }

        public override void GetUsedTables(DataModel.TableList tables)
        {
            if (this.model.Tables.Count > 0)
            {
                tables.Add(this.model.Tables[0]);
            }
        }

        public static string STypeName
        {
            get
            {
                return "COMPOUND";
            }
        }

        public override string Text
        {
            get
            {
                return "";
            }
        }

        public override string TypeName
        {
            get
            {
                return STypeName;
            }
        }
    }
}

