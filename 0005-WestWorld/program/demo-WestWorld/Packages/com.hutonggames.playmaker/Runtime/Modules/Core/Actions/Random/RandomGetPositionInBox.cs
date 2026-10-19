using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomPosition)]
    [ActionDescription("Get a random position inside a box. " +
                       "Optionally set the center of the box.")]
    public class RandomGetPositionInBox : BaseAction
    {
        [HideLabel]
        [SerializeReference] 
        [Tooltip("Set the dimensions of the box.")]
        public BaseScaleBlock Dimensions;
        
        //[OptionalField]
        [SerializeReference]
        [Tooltip("Set the center of the box.")]
        public BasePositionBlock CenterAt;

        [HideLabel, WriteOnly]
        [Tooltip("Store the random position in a Vector3 variable.")]
        public Vector3Ref StorePosition;

        public override bool CanExecute() =>
            Dimensions.IsValid 
            && StorePosition.HasValue() 
            && (CenterAt == null || CenterAt.IsValid);

        public override void Execute()
        {
            var ranges = Dimensions.GetScale()  * 0.5f;
            var x = Random.Range(-ranges.x, ranges.x);
            var y = Random.Range(-ranges.y, ranges.y);
            var z = Random.Range(-ranges.z, ranges.z);
            var randomPoint = new Vector3(x, y, z);
            
            if (CenterAt != null)
            {
                randomPoint += CenterAt.GetWorldPosition();
            }
            
            StorePosition.Value = randomPoint;
        }
        
        public override string GetSummary() => "Get Random Position in Box => {StorePosition}";
    }
}