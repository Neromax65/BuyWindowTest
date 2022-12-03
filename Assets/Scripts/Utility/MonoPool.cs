using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Utility
{
    public class MonoPool<T> : MonoBehaviour where T: MonoBehaviour
    {
        [SerializeField] private T gameObjectPrefab;
        [SerializeField] private Transform parent;
        [SerializeField] private int preSpawnCount = 5;

        private readonly List<T> _poolObjects = new List<T>();

        private void Start()
        {
            PreSpawn();
        }

        private void PreSpawn()
        {
            for (int i = 0; i < preSpawnCount; i++)
            {
                T pooledGameObject = Instantiate(gameObjectPrefab, parent);
                pooledGameObject.gameObject.SetActive(false);
                _poolObjects.Add(pooledGameObject);
            }
        }

        public T Spawn()
        {
            foreach (var poolObject in _poolObjects)
            {
                if (!poolObject.gameObject.activeInHierarchy)
                {
                    poolObject.gameObject.SetActive(true);
                    return poolObject;
                }
            }

            T newGameObject = Instantiate(gameObjectPrefab, parent);
            _poolObjects.Add(newGameObject);
            return newGameObject;
        }

        public void DeSpawn(T pooledGameObject)
        {
            if (_poolObjects.Contains(pooledGameObject))
                pooledGameObject.gameObject.SetActive(false);
        }

        public void DeSpawnAll()
        {
            foreach (var poolObject in _poolObjects)
            {
                DeSpawn(poolObject);
            }
        }
    }
}