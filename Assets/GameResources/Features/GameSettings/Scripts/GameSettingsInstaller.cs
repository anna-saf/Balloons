namespace Ballons.Features.GameSettings
{
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Конфиг приложения
    /// </summary>
    [CreateAssetMenu(fileName = nameof(GameSettingsInstaller), menuName = "Ballons/GameSettings/" + nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        protected MovementSettings movementSettings = default;

        public override void InstallBindings()
        {
            Container.BindInstance(movementSettings).AsSingle();
        }
    }
}
