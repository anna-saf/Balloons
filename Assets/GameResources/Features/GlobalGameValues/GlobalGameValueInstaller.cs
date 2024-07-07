namespace Balloons.Features.GlobalGameValues
{
    using Ballons.Features.GameSettings;
    using Balloons.Features.Utilities;
    using Zenject;

    /// <summary>
    /// Инсталлер глобальных значений игры
    /// </summary>
    public class GlobalGameValueInstaller : MonoInstaller
    {
        protected GeneralSetting generalSetting = default;

        [Inject]
        protected virtual void Construct(GeneralSetting generalSetting) =>
            this.generalSetting = generalSetting;

        public override void InstallBindings()
        {
            BindScoreValue(); 
            BindLifesValue();
        }

        private void BindScoreValue()
        {
            Container.Bind<GenericEventValue<int>>().WithId(GlobalGameValueType.Score).AsCached();
        }

        private void BindLifesValue()
        {
            GenericEventValue<int> score = new GenericEventValue<int> { Value = generalSetting.StartLifesCount };
            Container.BindInstance(score).WithId(GlobalGameValueType.Lifes).AsCached();
        }
    }
}
