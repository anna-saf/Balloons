namespace Balloons.Features.GlobalGameValues
{
    using Ballons.Features.GameSettings;
    using Balloons.Features.GlobalGameEvents;
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
            BindSpeedValue();
        }

        private void BindScoreValue()
        {
            GenericEventValue<int> score = new GenericEventValue<int>();
            Container.BindInstance(score).WithId(GlobalGameValueType.Score).AsCached();
            Container.Bind<ResetValueOnMenu<int>>().AsCached().WithArguments(score).NonLazy();
        }

        private void BindLifesValue()
        {
            GenericEventValue<int> lifes = new GenericEventValue<int>(generalSetting.StartLifesCount);
            Container.BindInstance(lifes).WithId(GlobalGameValueType.Lifes).AsCached();
            Container.Bind<ResetValueOnMenu<int>>().AsCached().WithArguments(lifes).NonLazy();
        }

        private void BindSpeedValue()
        {
            GenericEventValue<float> speed = new GenericEventValue<float>(generalSetting.StartGameSpeed);
            Container.BindInstance(speed).WithId(GlobalGameValueType.Speed).AsCached();
            Container.Bind<ResetValueOnMenu<float>>().AsCached().WithArguments(speed).NonLazy();
        }
    }
}
