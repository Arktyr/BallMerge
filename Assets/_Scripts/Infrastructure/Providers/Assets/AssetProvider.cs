using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Infrastructure.Services.Providers.Assets
{
    public class AssetProvider : IAssetProvider
    {
        public async UniTask<T> Get<T>(string path) where T : Object
        {
            T obj = await Resources.LoadAsync<T>(path) as T;

            if (obj == null)
                Debug.LogError($"{typeof(T)} not found by <{path}> ");

            return obj;
        }

        public void UnloadAll() => 
            Resources.UnloadUnusedAssets();
    }
}