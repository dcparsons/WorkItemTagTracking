using Unity;

namespace ReleaseWITAlert.Lib
{
    internal class TfsProjectFactory : ITfsProjectFactory
    {
        private readonly IUnityContainer _container;

        public TfsProjectFactory(IUnityContainer container)
        {
            _container = container;
        }

        public ITfsProject Create()
        {
            return _container.Resolve<ITfsProject>();
        }
    }
}
