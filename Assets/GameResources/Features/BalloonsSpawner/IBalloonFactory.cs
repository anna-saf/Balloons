namespace Balloons.Features.BallonsSpawner
{
    /// <summary>
    /// Абстрактная фабрика шаров
    /// </summary>
    public interface IBalloonFactory
    {
        /// <summary>
        /// Создать шар
        /// </summary>
        /// <returns></returns>
        public BalloonFacade CreateObject();
    }
}
