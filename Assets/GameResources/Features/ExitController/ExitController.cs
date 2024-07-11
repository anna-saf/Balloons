namespace Balloons.Features.Exit
{
    using UnityEngine;

    /// <summary>
    /// Контроллер выхода из приложения
    /// </summary>
    public class ExitController
    {
        public void Exit()
        {
#if !UNITY_EDITOR
            Application.Quit();
#else
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
