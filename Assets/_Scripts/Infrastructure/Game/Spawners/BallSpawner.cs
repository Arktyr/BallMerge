﻿using System.Collections.Generic;
using _Scripts.Data.Balls;
using _Scripts.Gameplay.Pool;
using _Scripts.Infrastructure.Game.Balls;
using _Scripts.Infrastructure.Providers;
using _Scripts.Infrastructure.Services.Providers.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Infrastructure.Game.Spawners
{
    public class BallSpawner : IBallSpawner
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IObjectPool _objectPool;
        
        private readonly List<BallConfig> _ballConfigs;
        
        private Ball _ballCachedPrefab;

        public BallSpawner(IAssetProvider assetProvider, 
            IDataProvider dataProvider, 
            IObjectPool objectPool)
        {
            _assetProvider = assetProvider;
            _objectPool = objectPool;

            _ballConfigs = dataProvider.BallData.BallConfigs;
        }

        public async UniTask WarmUp()
        {
            _ballCachedPrefab = await _assetProvider.Get<Ball>(AssetsPath.BALL_PATH);
        }
        
        public void SpawnBall(Vector3 position, Quaternion rotation)
        {
            BallConfig ballConfig = GetRandomBallConfig();

            Ball ball = _objectPool.GetGameObject(_ballCachedPrefab, position, rotation);
            ball.Construct(ballConfig.Color, ballConfig.Points);
            ball.gameObject.SetActive(true);

            ball.OnDestroyed += ReturnToPool;
        }

        private void ReturnToPool(Ball ball)
        {
            ball.OnDestroyed -= ReturnToPool;
            _objectPool.ReturnGameObject(ball.gameObject, _ballCachedPrefab);
        }

        private BallConfig GetRandomBallConfig()
        {
            int randomNumber = Random.Range(0, _ballConfigs.Count);

            return _ballConfigs[randomNumber];
        }

    }
}