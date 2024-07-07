namespace Balloons.Features.GlobalGameValues
{
    using Balloons.Features.Utilities;
    using Zenject;

    /// <summary>
    /// Инсталлер глобальных значений игры
    /// </summary>
    public class GlobalGameValueInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindScoreValue(); 
            BindLifesValue();
        }

        private void BindScoreValue() =>
            Container.Bind<GenericEventValue<int>>().WithId(GlobalGameValueType.Score).AsCached();

        private void BindLifesValue() =>
            Container.Bind<GenericEventValue<int>>().WithId(GlobalGameValueType.Lifes).AsCached();
    }
}
