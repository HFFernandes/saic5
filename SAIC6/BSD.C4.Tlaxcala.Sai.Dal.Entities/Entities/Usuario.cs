
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 29/07/2009 - 02:18 p.m.
// This is a partial class file. The other one is UsuarioEntity.Auto.cs
// You can edit this file as your wish.
//------------------------------------------------------------------------------

using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities
{
    /// <summary>
    /// This class represents the Usuario entity.
    /// </summary>
    [Serializable]
    public partial class Usuario
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
    /// This class represents a collection of Usuario entity.
    /// </summary>
    public partial class UsuarioList
    {
         // /// <summary>
         // /// Returns a typed Dataset based on its content.
         // /// </summary>
         //public override System.Data.DataSet ToDataSet()
         //{
         //    YOUR_TYPED_DATASET MyDataSet = new YOUR_TYPED_DATASET();
         //    ObjectListHelper<Usuario, UsuarioList> Exporter = new ObjectListHelper<Usuario, UsuarioList>();
         //    Exporter.FillDataSet(MyDataSet, this);
         //    return MyDataSet;
         //}
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// This class represents a view of an collection of Usuario entities.
    /// </summary>
    public partial class UsuarioListView
    {
    }
}


