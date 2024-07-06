namespace Ballons.Features.GameSpeed
{
    using Ballons.Features.GameSettings;
    using System;

    /// <summary>
    /// Контроллер скорости игры
    /// </summary>
    public class GameSpeedController
    {
        public event Action onCurrentSpeedChanged = delegate { };

        /// <summary>
        /// Текущая скорость игры
        /// </summary>
        public float CurrentSpeed
        {
            get => currentSpeed;
            set
            {
                if (currentSpeed != value)
                {
                    currentSpeed = value;
                    onCurrentSpeedChanged();
                }
            }
        }
        protected float currentSpeed = default;

        public GameSpeedController(GeneralSetting generalSetting)
        {
            currentSpeed = generalSetting.StartGameSpeed;
        }
    }
}
