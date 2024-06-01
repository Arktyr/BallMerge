using _Scripts.Infrastructure.Singleton;
using UnityEngine;

namespace _Scripts.Gameplay.Pool
{
    public interface IObjectPool : IService
    {
        T GetGameObject<T>(T prefab, Vector3 position, Quaternion rotation) where T : MonoBehaviour;
        T GetGameObject<T>(T prefab, Vector3 position, Quaternion rotation, Transform root) where T : MonoBehaviour;
        GameObject GetGameObject(GameObject prefab, Vector3 position, Quaternion rotation);
        void ReturnGameObject<T>(GameObject tGameObject, T prefab) where T : MonoBehaviour;
        void ReturnGameObject(GameObject tGameObject, GameObject mPrefab);
    }
}