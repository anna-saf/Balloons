namespace Balloons.Features.Utilities
{
    using System;
    using UnityEngine;

    /// <summary>
    /// ����� GameObject � ���� ���� 
    /// </summary>
    [Serializable]
    public class AnotherGameObjectWindowConnection
    {
        public WindowType window = default;
        public Canvas windowGO = default;
    }
}
