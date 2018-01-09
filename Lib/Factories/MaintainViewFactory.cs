using Unity;

namespace ReleaseWITAlert.Lib
{
    internal class MaintainViewFactory : IMaintainViewFactory
    {
        private readonly IUnityContainer _container;

        public MaintainViewFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IMaintainView Create()
        {
            return _container.Resolve<IMaintainView>();
        }
    }
}
