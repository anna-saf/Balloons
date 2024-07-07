namespace Balloons.Features.Utilities
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Общий контроллер для UI окон сцены
    /// </summary>
    public class AnotherWindowAgregator : MonoBehaviour
    {
        public event Action<WindowType> onWindowOpened = delegate { };

        [SerializeField]
        protected List<AnotherGameObjectWindowConnection> gameObjectWindowConnections = new List<AnotherGameObjectWindowConnection>();

        [SerializeField]
        protected WindowType startWindow = default;

        protected WindowType selectedWindow = default;
        protected Dictionary<WindowType, GameObject> spawnedWindows = default;

        protected virtual void OnEnable() =>
            SetWindowActive(startWindow);

        /// <summary>
        /// Задать окно активным
        /// </summary>
        /// <param name="window"></param>
        public virtual void SetWindowActive(WindowType window)
        {
            CloseWindow(selectedWindow);
            if (TryFindWindowInData(window, out Canvas windowGO))
            {
                if (spawnedWindows.ContainsKey(window))
                {
                    selectedWindow = window;
                    spawnedWindows[window].SetActive(true);
                }
                else
                {
                    GameObject spawnedWindow = SpawnWindow(windowGO.gameObject);
                    if (spawnedWindow)
                    {
                        spawnedWindows[window] = spawnedWindow;
                    }
                }
            }
        }

        /// <summary>
        /// Отключить окно
        /// </summary>
        /// <param name="window"></param>
        public virtual void CloseWindow(WindowType window)
        {
            if (TryFindWindowInData(window, out Canvas windowGO))
            {
                windowGO.gameObject.SetActive(false);
            }
        }

        protected bool TryFindWindowInData(WindowType window, out Canvas windowGO)
        {
            AnotherGameObjectWindowConnection targetWindow = gameObjectWindowConnections.Find(x => x.window.Equals(window));
            if (targetWindow != null)
            {
                windowGO = targetWindow.windowGO;
                return true;
            }
            windowGO = null;
            return false;
        }

        protected virtual GameObject SpawnWindow(GameObject windowPrefab) =>
            Instantiate(windowPrefab);
    }
}
