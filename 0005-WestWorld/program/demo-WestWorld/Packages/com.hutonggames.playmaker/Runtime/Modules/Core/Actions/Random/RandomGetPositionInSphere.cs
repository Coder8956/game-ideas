using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomPosition)]
    [ActionDescription("Get a random position inside a sphere. " +
                       "Set the radius and optionally center of the sphere.")]
    public class RandomGetPositionInSphere : BaseAction
    {
        [SerializeReference] 
        [Tooltip("Set the dimensions of the sphere.")]
        public BaseScaleBlock Size;
        
        [OptionalField]
        [SerializeReference]
        [Tooltip("Set the center of the sphere.")]
        public BasePositionBlock CenterAt;

        [HideLabel, WriteOnly]
        [Tooltip("Store the random position in a Vector3 variable.")]
        public Vector3Ref StorePosition;

        public override bool CanExecute() =>
            (Size?.IsValid ?? false)
            && StorePosition.HasValue() 
            && (CenterAt == null || CenterAt.IsValid);

        public override void Execute()
        {
            var radius = Size.GetScale().x;
            
            var randomPoint = Random.insideUnitSphere * radius;
            
            if (CenterAt != null)
            {
                randomPoint += CenterAt.GetWorldPosition();
            }
            
            StorePosition.Value = randomPoint;
        }
        
        public override string GetSummary() => "Get Random Position in Sphere -> {StorePosition}";
    }
}