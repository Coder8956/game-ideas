using System;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Pool)]
    [ConvertibleGroup(ConvertibleGroup.Instantiate)]
    [ActionDescription("Spawn multiple prefabs from a pool with an offset between each instance. If the pool does not exist it will be created." +
                       "\n\nUse ObjectPool Release Object to return spawned instances to the pool.")]
    public class ObjectPoolSpawnObjectsWithOffsets : BaseAction
    {
        [Tooltip("The prefab to spawn.")]
        [SerializeField]
        private GameObjectVar _prefab;

        [Tooltip("The number of instances to spawn.")]
        [SerializeField]
        private IntegerVar _count;
        
        [Tooltip("The position of the first instance.")]
        [SerializeField]
        private Vector3Var _startPosition;
        
        [Tooltip("The rotation of the first instance.")]
        [SerializeField]
        private QuaternionVar _startRotation;

        [Tooltip("The position offset between each instance.")]
        [SerializeField]
        private Vector3Var _offsetPosition;
        
        [Tooltip("The rotation offset between each instance.")]
        [SerializeField]
        private QuaternionVar _offsetRotation;

        [OptionalField]
        [Tooltip("Store the created GameObjects in a list")]
        [SerializeField, WriteOnly]
        private GameObjectListRef _spawnedObjects;

        [OptionalField]
        [Tooltip("Set the parent of the created Objects.")]
        [SerializeField]
        public GameObjectVar _setParent;
        
        public override bool CanExecute() => CheckParameters(_prefab, _count, _startPosition, _startRotation, _offsetRotation, _offsetPosition);
        
        public override void Execute()
        {
            var spawnedObjects = new List<GameObject>(_count.Value);

            var nextPosition = _startPosition.Value;
            var nextRotation = _startRotation.Value;
            
            for (int i = 0; i < _count.Value; i++)
            {
                var spawnedObject = ObjectPoolManager.SpawnObject(_prefab.Value, _startPosition.Value, _startRotation.Value);
                if (spawnedObject == null)
                {
                    break;
                }

                spawnedObject.transform.SetPositionAndRotation(nextPosition, nextRotation);
                nextPosition += _offsetPosition.Value;
                nextRotation *= _offsetRotation.Value;
                
                spawnedObjects.Add(spawnedObject);
                
                if (_setParent.HasValue())
                {
                    spawnedObject.transform.SetParent(_setParent.Value.transform);
                }
                
                spawnedObject.SetActive(true);
            }
            
            if (_spawnedObjects.IsAssigned)
            {
                _spawnedObjects.Value = spawnedObjects;
            }
        }
        
        public override string GetSummary() => 
            "Spawn {_count} {_prefab} at {_startPosition} " + 
            (_startRotation.IsAssigned || _startRotation.Value.eulerAngles != Vector3.zero ? "{_startRotation} " : "") +
            " offset {_offsetPosition}" +
            (_offsetRotation.IsAssigned || _offsetRotation.Value != Quaternion.identity ? "{_offsetRotation} " : "") +
            "{_spawnedObjects:output}";
    }
}
