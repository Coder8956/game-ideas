using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Pool)]
    [ConvertibleGroup(ConvertibleGroup.Instantiate)]
    [ActionDescription("Spawn a prefab from a pool. If the pool does not exist it will be created. " +
                       "Use a transform to position and rotate the created object." +
                       "\n\nUse ReleaseObject to return it to the pool.")]
    public class ObjectPoolSpawnObjectAtTransform : BaseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The prefab to spawn.")]
        [SerializeField]
        private GameObjectVar _prefab;

        [Tooltip("Set the position and rotation for the created object using a Transform in the scene.")]
        [SerializeField]
        [ConvertibleName("AtTransform")]
        private TransformVar _transform;

        [OptionalField]
        [Tooltip("Store the created GameObject")]
        [ConvertibleName("StoreCreatedObject")]
        [SerializeField, WriteOnly]
        private GameObjectRef _spawnedObject;
        
        [OptionalField]
        [Tooltip("Set the parent of the created Object.")]
        [SerializeField]
        public GameObjectVar _setParent;

        public override bool CanExecute() => CheckParameters(_prefab, _transform);
        
        public override void Execute()
        {
            var spawnedObject = ObjectPoolManager.SpawnObject(_prefab.Value, _transform.Value);
            if (spawnedObject == null)
            {
                return;
            }
            
            if (_spawnedObject.IsAssigned)
            {
                _spawnedObject.Value = spawnedObject;
            }
            
            if (_setParent.HasValue())
            {
                spawnedObject.transform.SetParent(_setParent.Value.transform);
            }
            
            spawnedObject.SetActive(true);
        }
        
        public override string GetSummary() => 
            "Spawn {_prefab} at {_transform} {_spawnedObject:output}";
    }
}
