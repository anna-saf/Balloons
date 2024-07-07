namespace Balloons.Features.Utilities
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Связь GameObject и типа окна 
    /// </summary>
    [Serializable]
    public class AnotherGameObjectWindowConnection
    {
        public WindowType window = default;
        public Canvas windowGO = default;
    }
}
