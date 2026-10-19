using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Instantiate)]
    [ConvertibleGroup(ConvertibleGroup.Instantiate)]
    [ActionDescription("Instantiates random prefabs inside a box volume.")]
    [HelpURL("actions/gameobject-actions/instantiate/instantiate-random-object-in-box/")]
    public class InstantiateRandomObjectInBox : BaseAction
    {
        [Tooltip("The prefabs to pick from.")]
        [SerializeField]
        private WeightedGameObjectVarList _prefabs;

        [SerializeField]
        private IntegerVar _count;
        
        [SerializeField]
        private TransformVar _center;
        
        [Tooltip("Size of the box in which objects will be spawned (X, Y, Z).")]
        [SerializeField]
        private Vector3Var _boxSize;

        [ActionHeader("Randomize")]
        
        [Tooltip("Maximum rotation per axis in degrees. Interpreted as ± value.")]
        [SerializeField]
        private RandomAxisValue _rotation;
        
        [Tooltip("Maximum scale delta per axis. 0.2 => scale in [0.8, 1.2].")]
        [SerializeField]
        private RandomAxisValue _scaleDelta;

        [Header("Output")]
        [SerializeField, OptionalField]
        [Tooltip("Set the parent of the created Object.")]
        private TransformVar _parent;
        
        [SerializeField, OptionalField]
        [Tooltip("Store the created GameObjects in a list")]
        private GameObjectListRef _created;
        
        public override bool CanExecute() => CheckParameters(_prefabs, _center, _boxSize);

        public override void Execute()
        {
            var parent = _parent.Value;
            _created.Value?.Clear();

            var count = Mathf.Max(0, _count.Value);
            var halfSize = _boxSize.Value * 0.5f;

            for (int i = 0; i < count; i++)
            {
                var prefab = _prefabs.GetRandomItem();
                if (prefab == null || prefab.Value == null)
                    continue;

                // Random point inside box
                var randomPoint = new Vector3(
                    Random.Range(-halfSize.x, halfSize.x),
                    Random.Range(-halfSize.y, halfSize.y),
                    Random.Range(-halfSize.z, halfSize.z)
                );
                var position = _center.Value.position + randomPoint;
                
                // Rotation
                var rotation = prefab.Transform.rotation;
                _rotation.ApplyRotationDegrees(ref rotation);
                
                var created = UnityEngine.Object.Instantiate(prefab.Value, position, rotation);
                _created.Value?.Add(created);

                if (_scaleDelta.IsEnabled)
                {
                    var scale = created.transform.localScale;
                    _scaleDelta.ApplyScaleDelta(ref scale);
                    created.transform.localScale = scale;
                }
                
                if (parent != null) created.transform.SetParent(parent);
            }
        }

        public override string GetSummary() =>
            "Spawn {_count} objects in box {_boxSize} @ {_center}";
    }
}
