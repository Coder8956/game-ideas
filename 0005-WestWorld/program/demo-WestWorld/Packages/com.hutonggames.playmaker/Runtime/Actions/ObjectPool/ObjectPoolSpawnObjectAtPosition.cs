using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Pool)]
    [ConvertibleGroup(ConvertibleGroup.Instantiate)]
    [ActionDescription("Spawn a prefab from a pool. If the pool does not exist it is created." +
                       "\n\nUse ObjectPool Release Object to return it to the pool.")]
    public class ObjectPoolSpawnObjectAtPosition : BaseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The prefab to spawn.")]
        [SerializeField]
        private GameObjectVar _prefab;

        [Tooltip("The world position of the spawned object.")]
        [SerializeField]
        private Vector3Var _position;
        
        [Tooltip("The rotation of the spawned object.")]
        [SerializeField]
        private QuaternionVar _rotation;

        [OptionalField]
        [Tooltip("Store the created GameObject.")]
        [SerializeField, WriteOnly]
        private GameObjectRef _spawnedObject;

        [OptionalField]
        [Tooltip("Set the parent of the created Object.")]
        [SerializeField]
        public GameObjectVar _setParent;
        
        public override bool CanExecute() => CheckParameters(_prefab, _position, _rotation);
        
        public override void Execute()
        {
            var spawnedObject = ObjectPoolManager.SpawnObject(_prefab.Value, _position.Value, _rotation.Value);
            if (spawnedObject == null)
            {
                return;
            }

            spawnedObject.transform.SetPositionAndRotation(_position.Value, _rotation.Value);
            
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
        
        public override string GetSummary()
        {
            var summary = "Spawn {_prefab} at {_position}";
            if (_rotation.IsVariable || _rotation.Value != Quaternion.identity)
            {
                summary += " and {_rotation}";
            }
            summary += " {_spawnedObject:output}";
            return summary;
        }
    }
}
