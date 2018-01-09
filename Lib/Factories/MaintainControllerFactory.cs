using Unity;

namespace ReleaseWITAlert.Lib
{
    internal class MaintainControllerFactory : IMaintainFactory
    {
        private readonly IUnityContainer _container;

        public MaintainControllerFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IMaintainController Create()
        {
            return _container.Resolve<IMaintainController>();
        }
    }
}
