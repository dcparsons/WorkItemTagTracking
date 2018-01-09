using System;

namespace ReleaseWITAlert.Lib
{
    interface IMaintainController
    {
        IMaintainView View { get; set; }
        void ShowView(EventHandler callback);
        void ShowEditView(ITfsProject project, EventHandler callback);
    }
}
