﻿using System;
using Microsoft.Win32;

namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    internal class CReg
    {
        public CReg()
        {
        }

        public static void WReg(CDats cdat)
        {
            try
            {
                RegistryKey reg1 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\CReportes", true);
                reg1.SetValue("srv", cdat.Server);
                reg1.SetValue("usr", cdat.User);
                reg1.SetValue("pwd", cdat.Password);
                reg1.SetValue("cat", cdat.Catalog);
            }
            catch
            {
                RegistryKey reg1 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE", true);
                reg1.CreateSubKey("CReportes");
                reg1 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\CReportes", true);
                reg1.SetValue("srv", cdat.Server);
                reg1.SetValue("usr", cdat.User);
                reg1.SetValue("pwd", cdat.Password);
                reg1.SetValue("cat", cdat.Catalog);
            }
        }

        public static CDats RReg()
        {
            try
            {
                RegistryKey reg1 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\CReportes");
                CDats cdat = new CDats();
                cdat.Server = Convert.ToString(reg1.GetValue("srv"));
                cdat.User = Convert.ToString(reg1.GetValue("usr"));
                cdat.Password = Convert.ToString(reg1.GetValue("pwd"));
                cdat.Catalog = Convert.ToString(reg1.GetValue("cat"));
                return cdat;
            }
            catch
            {
                return null;
            }
        }
    }
}