
        
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 08/08/2009 - 05:20 p.m.
// This is a partial class file. The other one is CorporacionMapper.Auto.cs
// You can edit this file as your wish.
//------------------------------------------------------------------------------

using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using Cooperator.Framework.Core;
using Cooperator.Framework.Data;
using Cooperator.Framework.Data.Exceptions;
using System.Data.Common;
using System.Reflection;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers
{

    /// <summary>
    /// Mapper for Corporacion entity
    /// This class provide persistence methods for this entity
    /// </summary>
    public  partial class CorporacionMapper
    {
        /// <summary>
        /// Enables GetObjectBySQLText and GetObjectListBySQLText methods.
        /// </summary>
        protected override bool SQLQueriesEnabled()
        {
            return true;
        }

        // /// <summary>
        // /// Checks for security ritghs
        // /// </summary>
        //protected override bool CheckForSecurityRights(SecurityRights action, CorporacionList ObjectListOrEntityList)
        //{
        //    switch (action)
        //    {
        //        case SecurityRights.Read:
        //            return true;
        //        case SecurityRights.Insert:
        //            return true;
        //        case SecurityRights.Update:
        //            return true;
        //        case SecurityRights.Delete:
        //            return true;
        //    }
        //    return false;
        //}

    }

}


namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Loaders
{

    /// <summary>
    /// Loader for Corporacion entity
    /// This class provide get methods for this entity
    /// </summary>
    public partial class CorporacionLoader
    {
    }

}



