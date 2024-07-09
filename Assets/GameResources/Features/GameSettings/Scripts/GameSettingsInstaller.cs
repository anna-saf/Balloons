namespace Balloons.Features.GameSettings
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
        private GeneralSetting _generalSettings = default;
        [SerializeField]
        private MovementSettings _movementSettings = default;
        [SerializeField]
        private BalloonSpawnSettings _ballonSpawnSettings = default;

        public override void InstallBindings()
        {
            BindGeneralSettings();
            BindMovementSettings();
            BindSpawnSettings();
        }

        private void BindGeneralSettings() =>
            Container.BindInstance(_generalSettings).AsSingle();

        private void BindMovementSettings() =>
            Container.BindInstance(_movementSettings).AsSingle();

        private void BindSpawnSettings() =>
            Container.BindInstance(_ballonSpawnSettings).AsSingle();
    }
}
