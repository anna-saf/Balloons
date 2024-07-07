namespace Balloons.Features.GlobalGameEvents
{
    using System;
    
    /// <summary>
    /// Провайдер глобальных игровых ивентов 
    /// </summary>
    public class GlobalGameEventsProvider : IDisposable
    {
        protected GlobalGameEvents globalGameEvents = default;

        protected GlobalGameEventsProvider(GlobalGameEvents globalGameEvents)
        {
            this.globalGameEvents = globalGameEvents;

            globalGameEvents.onStartGame += OnStartGame;
            globalGameEvents.onPauseGame += OnPauseGame;
            globalGameEvents.onContinueGame += OnContinueGame;
            globalGameEvents.onEndGame += OnEndGame;
            globalGameEvents.onGoToMenu += OnGoToMenu;
        }

        protected virtual void OnStartGame()
        {
            ///Переопределить при необходимости
        }

        protected virtual void OnPauseGame()
        {
            ///Переопределить при необходимости
        }
        protected virtual void OnContinueGame()
        {
            ///Переопределить при необходимости
        }

        protected virtual void OnEndGame()
        {
            ///Переопределить при необходимости
        }

        protected virtual void OnGoToMenu()
        {
            ///Переопределить при необходимости
        }

        public virtual void Dispose()
        {
            if (globalGameEvents != null)
            {
                globalGameEvents.onStartGame -= OnStartGame;
                globalGameEvents.onPauseGame -= OnPauseGame;
                globalGameEvents.onContinueGame -= OnContinueGame;
                globalGameEvents.onEndGame -= OnEndGame;
                globalGameEvents.onGoToMenu -= OnGoToMenu;
            }
        }
    }
}
