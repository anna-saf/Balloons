namespace Balloons.Features.GameLifes
{
    using Balloons.Features.GlobalGameEvents;
    using Balloons.Features.GlobalGameValues;
    using Balloons.Features.Utilities;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Спавнер жизней на OnEnable
    /// </summary>
    public class LifesSpawner : AbstractLifeSpawner
    {
        protected virtual void OnEnable() => 
            StartSpawn();
    }
}
