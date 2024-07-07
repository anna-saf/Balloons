namespace Ballons.Features.GameSettings
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Основные настройки игры
    /// </summary>
    [Serializable]
    public class GeneralSetting
    {
        public float StartGameSpeed = default;
        public int StartLifesCount= default;
    }
}
