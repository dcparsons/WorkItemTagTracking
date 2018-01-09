using Unity;

namespace ReleaseWITAlert.Lib
{
    internal class MainControllerFactory : IMainFactory
    {
        private readonly IUnityContainer _container;

        public MainControllerFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IMainController Create()
        {
            return _container.Resolve<IMainController>();
        }
    }
}
