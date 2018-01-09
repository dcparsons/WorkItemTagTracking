using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseWITAlert.Lib
{
    interface IMainController
    {
        IMainView View { get; set; }
    }
}
