namespace Balloons.Features.EndGame
{
    using Balloons.Features.GlobalGameEvents;
    using Balloons.Features.GlobalGameValues;
    using Balloons.Features.Utilities;
    using System;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Закончить игру, если закончились жизни
    /// </summary>
    public class EndGameOnLifesEnd: IDisposable
    {
        protected GlobalGameEvents gameEvents = default;
        protected GenericEventValue<int> lifes = default;

        public EndGameOnLifesEnd(GlobalGameEvents gameEvents, [Inject(Id = GlobalGameValueType.Lifes)] GenericEventValue<int> lifes)
        {
            this.gameEvents = gameEvents;
            this.lifes = lifes;
            gameEvents.onStartGame += OnStartGame;
        }

        protected virtual void OnStartGame() =>
            lifes.onValueChanged += OnLifesCountChanged;

        public void Dispose()
        {
            lifes.onValueChanged -= OnLifesCountChanged;
            gameEvents.onStartGame -= OnStartGame;
        }

        protected virtual void OnLifesCountChanged()
        {
            if(lifes.Value <= 0)
            {
                lifes.onValueChanged -= OnLifesCountChanged;
                gameEvents.EndGame();
            }
        }
    }
}
