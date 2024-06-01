using _Scripts.Gameplay.FX.Merge;
using _Scripts.Gameplay.Pool;
using _Scripts.Infrastructure.Providers.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Gameplay.Spawners.FX
{
    public class ParticleSpawner : IParticleSpawner
    {
        private readonly IObjectPool _objectPool;
        private readonly IAssetProvider _assetProvider;

        private MergeParticle _particleCachedPrefab;
        
        public ParticleSpawner(IObjectPool objectPool, 
            IAssetProvider assetProvider)
        {
            _objectPool = objectPool;
            _assetProvider = assetProvider;
        }

        public async UniTask WarmUp()
        {
            _particleCachedPrefab = await _assetProvider.Get<MergeParticle>(AssetsPath.MERGE_FX_PATH);
        }

        public void SpawnParticle(Vector3 position)
        {
            MergeParticle particleGameobject = 
                _objectPool.GetGameObject(_particleCachedPrefab, position, _particleCachedPrefab.transform.rotation);

            particleGameobject.Enable();
            particleGameobject.OnFXEnded += ReturnToPool;
        }

        private void ReturnToPool(MergeParticle mergeParticle)
        {
            mergeParticle.OnFXEnded -= ReturnToPool;
            _objectPool.ReturnGameObject(mergeParticle.gameObject, _particleCachedPrefab);
        }
    }
}