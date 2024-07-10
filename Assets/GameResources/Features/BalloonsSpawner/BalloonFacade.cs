﻿namespace Balloons.Features.BallonsSpawner
{
    using Balloons.Features.BalloonDestroy;
    using System;
    using UnityEngine;

    /// <summary>
    /// Фасад объекта шара
    /// </summary>
    public class BalloonFacade : MonoBehaviour
    {
        /// <summary>
        /// Вызывается, когда на шар кликнули
        /// </summary>
        public event Action<BalloonFacade> onBalloonClicked = delegate { };
        ///Получить SpriteRenderer шара
        public SpriteRenderer BallonSpriteRenderer => ballonSpriteRenderer;

        [SerializeField]
        protected SpriteRenderer ballonSpriteRenderer = default;
        [SerializeField]
        protected BalloonClickHandler balloonClickHandler = default;

        protected virtual void OnEnable() =>
            balloonClickHandler.onBallonClicked += OnBalloonClicked;

        protected virtual void OnDisable() =>
            balloonClickHandler.onBallonClicked -= OnBalloonClicked;

        protected virtual void OnBalloonClicked() =>
            onBalloonClicked(this);
    }
}