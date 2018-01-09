using Unity;

namespace ReleaseWITAlert.Lib { 
    internal class TfsWitFactory : ITfsWitFactory
    {
        private readonly IUnityContainer _container;

        public TfsWitFactory(IUnityContainer container)
        {
            _container = container;
        }

        public ITfsWit Create()
        {
            return _container.Resolve<ITfsWit>();
        }
    }
}
