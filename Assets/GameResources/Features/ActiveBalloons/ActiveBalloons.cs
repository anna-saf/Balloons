namespace Balloons.Features.ActiveBalloons
{
    using Ballons.Features.BallonsSpawner;
    using Ballons.Features.Utilities;

    /// <summary>
    /// Лист шаров, которые в данный момент активны
    /// </summary>
    public class ActiveBalloons : GenericEventList<BallonFacade> { }
}
