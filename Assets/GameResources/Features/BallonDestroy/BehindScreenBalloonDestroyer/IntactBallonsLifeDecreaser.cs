namespace Balloons.Features.BalloonDestroy
{
    using Balloons.Features.GlobalGameValues;
    using Balloons.Features.Utilities;
    using System;
    using Zenject;

    /// <summary>
    /// Уменьшает жизни, если шар ушел за границу экрана
    /// </summary>
    public class IntactBallonsLifeDecreaser: IDisposable
    {
        protected BehindScreenBalloonsDestroyer behindScreenBalloonsDestroyer = default;
        protected GenericEventValue<int> lifesCount = default;

        public IntactBallonsLifeDecreaser(BehindScreenBalloonsDestroyer behindScreenBalloonsDestroyer, [Inject(Id = GlobalGameValueType.Lifes)] GenericEventValue<int> lifesCount)
        {
            this.behindScreenBalloonsDestroyer = behindScreenBalloonsDestroyer;
            this.lifesCount = lifesCount;
            behindScreenBalloonsDestroyer.onBehindScreenBalloon += OnBalloonDestroyed;
        }

        public void Dispose() =>
            behindScreenBalloonsDestroyer.onBehindScreenBalloon -= OnBalloonDestroyed;

        private void OnBalloonDestroyed() =>
            lifesCount.Value--;
    }
}
