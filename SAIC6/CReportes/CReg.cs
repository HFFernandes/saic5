using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace CReportes
{
    class CReg
    {
        public CReg()
        {
        }
        static public void WReg(CDats cdat)
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
                reg1.SetValue("pwd",cdat.Password);
                reg1.SetValue("cat", cdat.Catalog);            
            }
        }
        static public CDats RReg()
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
