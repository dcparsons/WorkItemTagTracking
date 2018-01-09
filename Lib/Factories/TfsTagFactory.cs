using Unity;

namespace ReleaseWITAlert.Lib
{
    internal class TfsTagFactory : ITfsTagFactory
    {
        private readonly IUnityContainer _container;

        public TfsTagFactory(IUnityContainer container)
        {
            _container = container;
        }

        public ITfsTag Create()
        {
            return _container.Resolve<ITfsTag>();
        }
    }
}
