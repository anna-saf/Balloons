namespace Balloons.Features.GameLifes
{
    /// <summary>
    /// Спавнер жизней на OnEnable
    /// </summary>
    public class LifesSpawner : AbstractLifeSpawner
    {
        protected virtual void OnEnable()
        {
            if(spawnedLifes.Count > 0)
            {
                foreach(LifeFacade lifeFacade in spawnedLifes)
                {
                    Destroy(lifeFacade.gameObject);
                }
            }
            spawnedLifes.Clear();
            StartSpawn();
        }
    }
}
