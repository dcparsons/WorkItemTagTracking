using Unity;

namespace ReleaseWITAlert.Lib
{
    internal class ConfigurationControllerFactory : IConfigurationFactory
    {
        private readonly IUnityContainer _container;

        public ConfigurationControllerFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IConfigurationController Create()
        {
            return _container.Resolve<IConfigurationController>();
        }
    }
}
