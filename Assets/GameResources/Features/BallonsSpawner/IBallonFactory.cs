namespace Ballons.Features.BallonsSpawner
{
    /// <summary>
    /// Абстрактная фабрика шаров
    /// </summary>
    public interface IBallonFactory
    {
        /// <summary>
        /// Создать шар
        /// </summary>
        /// <returns></returns>
        public BallonFacade CreateObject();
    }
}
