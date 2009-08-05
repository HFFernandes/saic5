using System;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Security.Principal;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    [PrincipalPermissionAttribute(SecurityAction.Demand,Name = "jbaez")]
    public partial class SAIFrmIncidenciasActivas : SAIFrmBase
    {
        public SAIFrmIncidenciasActivas()
        {
            InitializeComponent();
            Width = Screen.GetWorkingArea(this).Width;
        }

        private void SAIFrmIncidenciasActivas_Load(object sender, EventArgs e)
        {
        }
    }
}
