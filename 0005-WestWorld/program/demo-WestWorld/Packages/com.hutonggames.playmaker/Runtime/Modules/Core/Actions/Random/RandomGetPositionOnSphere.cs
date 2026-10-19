using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomPosition)]
    [ActionDescription("Get a random position on a sphere.")]
    public class RandomGetPositionOnSphere : BaseAction
    {
        [Tooltip("The center of the sphere.")]
        [SerializeField]
        private Vector3Var _center;
        
        [Tooltip("Radius of the sphere.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _radius;
        
        [Tooltip("Store the random position in a Vector3 variable.")]
        [SerializeField, WriteOnly]
        private Vector3Ref _storePosition;

        public override bool CanExecute() => CheckParameters(_radius, _storePosition);

        public override void Execute()
        {
            _storePosition.Value = Random.onUnitSphere * _radius.Value + _center.Value;
        }
        
        public override string GetSummary() => "Get random position on sphere {_radius} @{_center} -> {_storePosition}";
    }
}