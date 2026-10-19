using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionDescription("Gets a random Vector3 from a list of Vector3s.")]
    [ActionCategory(Category.RandomFromList)]
    public class GetRandomVector3 : BaseAction
    {
        [HideLabel]
        [Tooltip("A list of items to pick from. The weight determines how likely an item is to be chosen.")]
        public WeightedVector3VarList Vector3s;

        [Tooltip(Strings.NoRepeatWeightedTooltip)]
        public BoolVar NoRepeat;
        
        [Tooltip("Store the selected item in a variable.")]
        [WriteOnly]
        public Vector3Ref StoreResult;

        private Vector3Var _lastItem;

        public override bool CanExecute() => CheckParameters(Vector3s, NoRepeat, StoreResult);

        public override void Execute()
        {
            var item = Vector3s.GetRandomItem(_lastItem, NoRepeat.Value);
            StoreResult.Value = item.Value;
            _lastItem = item;
        }
        
        public override string GetSummary() => "Get Random Vector3 from {Vector3s} -> {StoreResult}";
    }
}

