using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionDescription("Gets a random Vector2 from a list of Vector2s.")] 
    [ActionCategory(Category.RandomFromList)]
    public class GetRandomVector2 : BaseAction
    {
        [HideLabel]
        [Tooltip("A list of items to pick from. The weight determines how likely an item is to be chosen.")]
        public WeightedVector2VarList Vector2s;

        [Tooltip(Strings.NoRepeatWeightedTooltip)]
        public BoolVar NoRepeat;
        
        [Tooltip("Store the selected item in a variable.")]
        [WriteOnly]
        public Vector2Ref StoreResult;

        private Vector2Var _lastItem;

        public override bool CanExecute() => CheckParameters(Vector2s, NoRepeat, StoreResult);

        public override void Execute()
        {
            var item = Vector2s.GetRandomItem(_lastItem, NoRepeat.Value);
            StoreResult.Value = item.Value;
            _lastItem = item;
        }
        
        public override string GetSummary() => "Get Random Vector2 from {Vector2s} -> {StoreResult}";
    }
}

