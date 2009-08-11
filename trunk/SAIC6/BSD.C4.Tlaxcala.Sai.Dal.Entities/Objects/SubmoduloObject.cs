
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 10/08/2009 - 08:53 p.m.
// This is a partial class file. The other one is SubmoduloObject.Auto.cs
// You can edit this file as your wish.
//------------------------------------------------------------------------------

using System;
using Cooperator.Framework.Core;
using Cooperator.Framework.Core.Exceptions;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// This class represents a Object of Submodulo table.
    /// </summary>
    [Serializable]
    public partial class SubmoduloObject
        // : IValidable
    {

        /// <summary>
        /// Called from class constructor.
        /// </summary>
        protected override void Initialize()
        {
        }

        // /// <summary>
        // /// Called after parameterized constructor. 
        // /// </summary>
        // protected override void Initialized()
        // {       
        // //Warnging: This method is only called by parameterized contructors.
        // }

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
    /// This class represents a record set of Submodulo table.
    /// </summary>
    public partial class SubmoduloObjectList
    {
         // /// <summary>
         // /// Returns a typed Dataset based on its content.
         // /// </summary>
         // public override System.Data.DataSet ToDataSet()
         // {
         //    YOUR_TYPED_DATASET MyDataSet = new YOUR_TYPED_DATASET();
         //    ObjectListHelper<SubmoduloObject, SubmoduloObjectList> Exporter = new ObjectListHelper<SubmoduloObject, SubmoduloObjectList>();
         //    Exporter.FillDataSet(MyDataSet, this);
         //    return MyDataSet;
         // }
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// This class represents a view of an collection of SubmoduloObjects.
    /// </summary>
    public partial class SubmoduloObjectListView
    {
    }
}


