using System;
using System.Windows.Forms;
using ReleaseWITAlert.Controllers;
using ReleaseWITAlert.Lib;
using ReleaseWITAlert.Models;
using Unity;

namespace ReleaseWITAlert
{
    static class Program
    {
        private static IUnityContainer _container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Bootstrap();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run((Form)_container.Resolve<IMainController>().View);
        }

        private static void Bootstrap()
        {
            _container = new UnityContainer();
            _container.RegisterType<IMainView, Main>();
            _container.RegisterType<IMainController, MainController>();
            _container.RegisterType<IMaintainView, MaintainView>();
            _container.RegisterType<IConfigurationView, ConfigurationView>();
            _container.RegisterType<IMaintainController, MaintainController>();
            _container.RegisterType<IConfigurationController, ConfigurationController>();
            _container.RegisterType<IMainFactory, MainControllerFactory>();
            _container.RegisterType<IMaintainFactory, MaintainControllerFactory>();
            _container.RegisterType<IConfigurationFactory, ConfigurationControllerFactory>();
            _container.RegisterType<ITfsTeamProjects, ProjectApis>();
            _container.RegisterType<ITfsTags, TagApis>();
            _container.RegisterType<ITFSWorkItems, WorkItemApis>();
            _container.RegisterType<IMaintainViewFactory, MaintainViewFactory>();
            _container.RegisterType<ITfsWitFactory, TfsWitFactory>();
            _container.RegisterType<ITfsTagFactory, TfsTagFactory>();
            _container.RegisterType<ITfsWit, TfsWit>();
            _container.RegisterType<ITfsTag, TfsTag>();
            _container.RegisterType<ITfsProjectFactory, TfsProjectFactory>();
            _container.RegisterType<ITfsProject, TfsProject>();
            _container.RegisterType<IProjectOperations, ProjectOperations>();
            _container.RegisterType<IEmailServer, EmailServer>();
        }
    }
}
