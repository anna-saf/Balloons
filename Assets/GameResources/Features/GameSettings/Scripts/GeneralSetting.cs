namespace Balloons.Features.GameSettings
{
    using System;

    /// <summary>
    /// Основные настройки игры
    /// </summary>
    [Serializable]
    public class GeneralSetting
    {
        public float StartGameSpeed = default;
        public int StartLifesCount = default;
        /// <summary>
        /// Сколько очков надо набрать, чтобы скорость увеличилась
        /// </summary>
        public int ScoreSpeedIncrease = default;
        public float GameSpeedIncreaser = default;
    }
}
