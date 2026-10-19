using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Pool)]
    [ConvertibleGroup(ConvertibleGroup.Instantiate)]
    [ActionDescription("Spawn multiple prefabs from a pool. If the pool does not exist it will be created. " +
                       "Use a transform as the center and min/max angles to control the spread of the spawned objects." +
                       "\n\nUse ReleaseObject to return it to the pool.")]
    public class ObjectPoolSpawnObjectsAtTransformRadial2D : BaseInstantiateObjectsAtTransformRadial2D
    {
        protected override GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            var instance = ObjectPoolManager.SpawnObject(prefab, position, rotation);
            if (instance == null)
            {
                return null;
            }

            instance.SetActive(true);
            return instance;
        }
    }
}

