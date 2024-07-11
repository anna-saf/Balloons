namespace Balloons.Features.GameSpeed
{
    using Balloons.Features.GameSettings;
    using Balloons.Features.GlobalGameEvents;
    using Balloons.Features.GlobalGameValues;
    using Balloons.Features.Utilities;
    using Zenject;

    /// <summary>
    /// Контроллер скорости игры
    /// </summary>
    public class GameSpeedController: GlobalGameEventsProvider
    {
        protected GenericEventValue<int> score = default;
        protected GenericEventValue<float> speed = default;
        protected int scoreSpeedIncrease = default;
        protected float gameSpeedIncreaser = default;

        public GameSpeedController([Inject(Id = GlobalGameValueType.Score)] GenericEventValue<int> score,
                                   [Inject(Id = GlobalGameValueType.Speed)] GenericEventValue<float> speed,
                                    GeneralSetting generalSettings,
                                    GlobalGameEvents globalGameEvents) : base(globalGameEvents)
        {
            scoreSpeedIncrease = generalSettings.ScoreSpeedIncrease;
            gameSpeedIncreaser = generalSettings.GameSpeedIncreaser;
            this.score = score;
            this.speed = speed;
            score.onValueChanged += TryIncreaseSpeed;
        }

        protected override void OnStartGame() =>
            score.onValueChanged += TryIncreaseSpeed;

        protected override void OnEndGame() =>
            score.onValueChanged -= TryIncreaseSpeed;

        protected override void OnGoToMenu() =>
            score.onValueChanged -= TryIncreaseSpeed;

        public override void Dispose()
        {
            base.Dispose();
            if(score != null)
            {
                score.onValueChanged -= TryIncreaseSpeed;
            }
        }

        protected virtual void TryIncreaseSpeed()
        {
            if(score.Value % scoreSpeedIncrease == 0)
            {
                speed.Value += gameSpeedIncreaser;
            }
        }
    }
}
