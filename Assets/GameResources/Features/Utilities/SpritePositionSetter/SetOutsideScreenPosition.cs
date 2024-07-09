namespace Balloons.Features.Utilities
{
    using UnityEngine;

    /// <summary>
    /// Задает рандомную позицию за границами экрана
    /// </summary>
    public class SetOutsideScreenPosition : ISpritePositionSetter
    {
        protected const int HALF_VALUE = 2;
        protected ScreenSide positionScreenSide = default;

        protected float minX = default;
        protected float maxX = default;
        protected float minY = default;
        protected float maxY = default;

        public SetOutsideScreenPosition(ScreenSide positionScreenSide) =>
            this.positionScreenSide = positionScreenSide;

        public void SetPosition(Transform targetObjectTransform, SpriteRenderer targetObjectSprite)
        {
            float spriteHalfWidth = targetObjectSprite.bounds.size.x/ HALF_VALUE;
            float spriteHalfHeight = targetObjectSprite.bounds.size.y/ HALF_VALUE;

            Vector3 minScreenCoord = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 maxScreenCoord = Camera.main.ViewportToWorldPoint(Vector3.one);


            switch (positionScreenSide)
            {
                case ScreenSide.Top:
                    minX = minScreenCoord.x + spriteHalfWidth;
                    maxX = maxScreenCoord.x - spriteHalfWidth;
                    maxY = minScreenCoord.y + spriteHalfHeight;
                    targetObjectTransform.transform.position = new Vector3(Random.Range(minX, maxX), maxY);
                    break;
                case ScreenSide.Bottom:
                    minX = minScreenCoord.x + spriteHalfWidth;
                    maxX = maxScreenCoord.x - spriteHalfWidth;
                    minY = minScreenCoord.y - spriteHalfHeight; 
                    targetObjectTransform.transform.position = new Vector3(Random.Range(minX, maxX), minY);
                    break;
                case ScreenSide.Left:
                    minX = minScreenCoord.x - spriteHalfWidth;
                    minY = minScreenCoord.y + spriteHalfHeight;
                    maxY = maxScreenCoord.y - spriteHalfHeight;
                    targetObjectTransform.transform.position = new Vector3(minX, Random.Range(minY, maxY));
                    break;
                case ScreenSide.Right:
                    maxX = maxScreenCoord.x + spriteHalfWidth;
                    minY = minScreenCoord.y + spriteHalfHeight;
                    maxY = maxScreenCoord.y - spriteHalfHeight;
                    targetObjectTransform.transform.position = new Vector3(maxX, Random.Range(minY, maxY));
                    break;
                default:
                    Debug.Log("Значение " + positionScreenSide + " не обработано");
                    break;
            }
        }
    }
}
