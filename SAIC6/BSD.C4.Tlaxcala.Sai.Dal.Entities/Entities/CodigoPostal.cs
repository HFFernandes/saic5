
        
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 05/08/2009 - 03:37 p.m.
// This is a partial class file. The other one is CodigoPostalEntity.Auto.cs
// You can edit this file as your wish.
//------------------------------------------------------------------------------

using System;
using Cooperator.Framework.Core.Exceptions;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities
{
    /// <summary>
    /// This class represents the CodigoPostal entity.
    /// </summary>
    [Serializable]
    public partial class CodigoPostal
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
    /// This class represents a collection of CodigoPostal entity.
    /// </summary>
    public partial class CodigoPostalList
    {
         // /// <summary>
         // /// Returns a typed Dataset based on its content.
         // /// </summary>
         //public override System.Data.DataSet ToDataSet()
         //{
         //    YOUR_TYPED_DATASET MyDataSet = new YOUR_TYPED_DATASET();
         //    ObjectListHelper<CodigoPostal, CodigoPostalList> Exporter = new ObjectListHelper<CodigoPostal, CodigoPostalList>();
         //    Exporter.FillDataSet(MyDataSet, this);
         //    return MyDataSet;
         //}
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// This class represents a view of an collection of CodigoPostal entities.
    /// </summary>
    public partial class CodigoPostalListView
    {
    }
}


