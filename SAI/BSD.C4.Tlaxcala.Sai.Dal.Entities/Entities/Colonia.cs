
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is ColoniaEntity.Auto.cs
// You can edit this file as your wish.
//------------------------------------------------------------------------------

using System;
using Cooperator.Framework.Core.Exceptions;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities
{
    /// <summary>
    /// This class represents the Colonia entity.
    /// </summary>
    [Serializable]
    public partial class Colonia
        // : IValidable
    {
        // /// <summary>
        // /// When IValidable is implemented, this method is invoked by Gateway before Insert or Update to validate Object.
        // /// </summary>
        // public void Validate()
        // {
        //     //Example:
        //     if (string.IsNullOrEmpty(this.Name)) throw new RuleValidationException("Name can't be null");
        // }
    }

    /// <summary>
    /// This class represents a collection of Colonia entity.
    /// </summary>
    public partial class ColoniaList
    {
         // /// <summary>
         // /// Returns a typed Dataset based on its content.
         // /// </summary>
         //public override System.Data.DataSet ToDataSet()
         //{
         //    YOUR_TYPED_DATASET MyDataSet = new YOUR_TYPED_DATASET();
         //    ObjectListHelper<Colonia, ColoniaList> Exporter = new ObjectListHelper<Colonia, ColoniaList>();
         //    Exporter.FillDataSet(MyDataSet, this);
         //    return MyDataSet;
         //}
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// This class represents a view of an collection of Colonia entities.
    /// </summary>
    public partial class ColoniaListView
    {
    }
}


