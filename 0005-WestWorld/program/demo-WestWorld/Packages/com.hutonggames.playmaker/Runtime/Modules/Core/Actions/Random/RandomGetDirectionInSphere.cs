using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomPosition)]
    [ActionDescription("Get a random direction vector in a sphere.")]
    public class RandomGetDirectionInSphere : BaseAction
    {
        [Tooltip("Radius of the sphere.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _radius;
        
        [Tooltip("Store the random direction in a Vector3 variable.")]
        [SerializeField]
        private Vector3Ref _storeDirection;

        public override bool CanExecute() => CheckParameters(_radius, _storeDirection);

        public override void Execute()
        {
            _storeDirection.Value = Random.onUnitSphere * _radius.Value;
        }
        
        public override string GetSummary() => "Get random direction in sphere r:{_radius} -> {_storeDirection}";
    }
}