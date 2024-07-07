namespace Balloons.Features.GameLifes
{
    /// <summary>
    /// Интерфейс фабрики по спавну жизней
    /// </summary>
    public interface ILifesFactory
    {
        /// <summary>
        /// Создание префаба
        /// </summary>
        /// <returns></returns>
        public LifeFacade CreateLife();
    }
}
