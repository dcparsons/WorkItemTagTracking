using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseWITAlert.Lib
{
    interface IConfigurationController
    {
        IConfigurationView View { get; set; }
        void Show();
    }
}
