using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup(ConvertibleGroup.Instantiate)]
    [ActionDescription("Instantiates multiple prefabs using a transform as the center " +
                       "and min/max angles to control the spread of the spawned objects.")]
    public abstract class BaseInstantiateObjectsAtTransformRadial2D : BaseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The prefab to spawn.")]
        [SerializeField]
        protected GameObjectVar _prefab;

        [Tooltip("The number of instances to spawn.")]
        [SerializeField]
        protected IntegerVar _count;
        
        [Tooltip("Set the position and rotation for the created object using a Transform in the scene.")]
        [SerializeField]
        [ConvertibleName("AtTransform")]
        protected TransformVar _transform;

        [FormerlySerializedAs("_offset")]
        [Vector2VarAsMinMax]
        [SerializeField]
        protected Vector2Var _angleRange;
        
        [FormerlySerializedAs("_offset")]
        [Vector2VarAsMinMax]
        [SerializeField]
        protected Vector2Var _radiusRange;
        
        [OptionalField]
        [Tooltip("Store the created GameObjects in a list")]
        [SerializeField, WriteOnly]
        protected GameObjectListRef _spawnedObjects;
        
        [OptionalField]
        [Tooltip("Set the parent of the created Object.")]
        [SerializeField]
        protected GameObjectVar _setParent;

        public override bool CanExecute() => CheckParameters(_prefab, _transform);

        public override void Execute()
        {
            var spawnedObjects = new List<GameObject>(_count.Value);

            for (var i = 0; i < _count.Value; i++)
            {
                var offset = Random.Range(_radiusRange.Value.x, _radiusRange.Value.y);

                // Calculate interpolation factor (0 to 1) based on current index
                var t = _count.Value > 1 ? (float)i / (_count.Value - 1) : 0f;

                // Interpolate between start and end rotation
                var angle = _transform.Value.eulerAngles.z;
                var interpolatedRotation = Mathf.LerpAngle(
                    angle + _angleRange.Value.x, angle + _angleRange.Value.y, t);
                var angleInRadians = interpolatedRotation * Mathf.Deg2Rad; // For 2D rotation around Z
                var direction = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0);
                
                var position = _transform.Value.position + direction * offset;
                var spawnedObject = Instantiate(_prefab.Value, position, Quaternion.AngleAxis(interpolatedRotation, Vector3.forward));
                if (spawnedObject == null)
                {
                    break;
                }

                spawnedObjects.Add(spawnedObject);

                if (_setParent.HasValue())
                {
                    spawnedObject.transform.SetParent(_setParent.Value.transform);
                }
            }

            if (_spawnedObjects.IsAssigned)
            {
                _spawnedObjects.Value = spawnedObjects;
            }
        }
        
        protected abstract GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation);
        
        public override string GetSummary() => 
            "Instantiate {_count} {_prefab} at {_transform} radial {_angleRange} {_spawnedObjects:output}";
    }
}

