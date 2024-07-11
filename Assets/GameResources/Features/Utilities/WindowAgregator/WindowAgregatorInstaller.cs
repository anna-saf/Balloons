namespace Balloons.Features.Utilities
{
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Инсталлер для WindowAgregator
    /// </summary>
    public class WindowAgregatorInstaller : MonoInstaller
    {
        [SerializeField]
        protected WindowAgregator windowAgregator = default;

        public override void InstallBindings() => 
            BindWindowAgregator();

        private void BindWindowAgregator() =>
            Container.BindInstance(windowAgregator);
    }
}
