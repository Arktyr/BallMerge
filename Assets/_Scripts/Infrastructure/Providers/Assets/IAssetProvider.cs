using _Scripts.Infrastructure.Singleton;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Infrastructure.Services.Providers.Assets
{
    public interface IAssetProvider : IService
    {
        public UniTask<T> Get<T>(string path) where T : Object;
    }
}