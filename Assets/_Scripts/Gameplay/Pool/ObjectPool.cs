﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

namespace _Scripts.Gameplay.Pool
{
  public class ObjectPool : IObjectPool
  {
    private readonly HashSet<GameObject> prefabs = new();
    private readonly Dictionary<GameObject, ObjectPool<GameObject>> pooledObjects = new();

    public T GetGameObject<T>(T prefab, Vector3 position, Quaternion rotation) where T : MonoBehaviour
    {
      if (pooledObjects.Keys.Contains(prefab.gameObject) == false) 
        RegisterPrefabInternal(prefab.gameObject, 3, null);

      var gameObject = pooledObjects[prefab.gameObject].Get();

      var noTransform = gameObject.transform;
      noTransform.position = position;
      noTransform.rotation = rotation;
      
      return gameObject.GetComponent<T>();
    }
    
    public T GetGameObject<T>(T prefab, Vector3 position, Quaternion rotation, Transform root) where T : MonoBehaviour
    {
      if (pooledObjects.Keys.Contains(prefab.gameObject) == false) 
        RegisterPrefabInternal(prefab.gameObject, 3, root);

      var gameObject = pooledObjects[prefab.gameObject].Get();

      var noTransform = gameObject.transform;
      noTransform.position = position;
      noTransform.rotation = rotation;
      
      return gameObject.GetComponent<T>();
    }

    public GameObject GetGameObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
      if (pooledObjects.Keys.Contains(prefab.gameObject) == false) 
        RegisterPrefabInternal(prefab.gameObject, 3, null);

      var gameObject = pooledObjects[prefab.gameObject].Get();

      var noTransform = gameObject.transform;
      noTransform.position = position;
      noTransform.rotation = rotation;

      gameObject.gameObject.SetActive(true);

      return gameObject;
    }

    public void ReturnGameObject<T>(GameObject tGameObject, T prefab) where T : MonoBehaviour
    {
      pooledObjects[prefab.gameObject].Release(tGameObject);
    }

    public void ReturnGameObject(GameObject tGameObject, GameObject mPrefab)
    {
      pooledObjects[mPrefab].Release(tGameObject);
    }

    void RegisterPrefabInternal(GameObject prefab, int prewarmCount, Transform root)
    {
      GameObject CreateFunc()
      {
        var instance = Object.Instantiate(prefab, root);
        return instance;
      }

      void ActionOnGet(GameObject tGameObject)
      {
        tGameObject.gameObject.SetActive(false);
      }

      void ActionOnRelease(GameObject tGameObject)
      {
        tGameObject.gameObject.SetActive(false);
      }

      void ActionOnDestroy(GameObject tGameObject)
      {
        Object.Destroy(tGameObject.gameObject);
      }

      prefabs.Add(prefab);

      pooledObjects[prefab] = new ObjectPool<GameObject>(CreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestroy,
        defaultCapacity: prewarmCount);

      var prewarmGameObjects = new List<GameObject>();
      
      for (var i = 0; i < prewarmCount; i++)
      {
        prewarmGameObjects.Add(pooledObjects[prefab].Get());
      }

      foreach (var networkObject in prewarmGameObjects)
      {
        pooledObjects[prefab].Release(networkObject);
      }
    }
  }
}