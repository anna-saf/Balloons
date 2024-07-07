namespace Balloons.Features.Utilities
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Связь GameObject и типа окна 
    /// </summary>
    [Serializable]
    public class GameObjectWindowConnection
    {
        public WindowType window = default;
        public GameObject windowGO = default;
    }
}
