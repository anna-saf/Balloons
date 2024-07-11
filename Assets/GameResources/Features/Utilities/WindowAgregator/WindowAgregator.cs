namespace Balloons.Features.Utilities
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Общий контроллер для UI окон сцены
    /// </summary>
    public class WindowAgregator : MonoBehaviour
    {
        public event Action<WindowType> onWindowOpened = delegate { };

        [SerializeField]
        protected List<GameObjectWindowConnection> gameObjectWindowConnections = new List<GameObjectWindowConnection>();

        [SerializeField]
        protected WindowType startWindow = default;

        protected List<WindowType> activeWindows = new List<WindowType>();

        protected virtual void OnEnable() =>
            SetWindowActive(startWindow);

        /// <summary>
        /// Задать окно активным
        /// </summary>
        /// <param name="window"></param>
        public virtual void SetWindowActive(WindowType window, bool needClose = true)
        {
            if (needClose)
            {
                CloseWindows();
            }
            if(TryFindWindow(window, out GameObject windowGO))
            {
                activeWindows.Add(window);
                windowGO.SetActive(true);
                onWindowOpened(window);
            }
        }

        /// <summary>
        /// Отключить все окнa
        /// </summary>
        /// <param name="window"></param>
        public virtual void CloseWindows()
        {
            foreach (WindowType window in activeWindows)
            {
                if (TryFindWindow(window, out GameObject windowGO))
                {
                    windowGO.SetActive(false);
                }
            }
            activeWindows.Clear();
        }

        protected bool TryFindWindow(WindowType window, out GameObject windowGO)
        {
            GameObjectWindowConnection targetWindow = gameObjectWindowConnections.Find(x => x.window.Equals(window));
            if (targetWindow != null)
            {
                windowGO = targetWindow.windowGO;
                return true;
            }
            windowGO = null;
            return false;
        }
    }
}
