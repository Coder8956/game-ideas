using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionDescription("Gets a random transform from a list of transforms.")]  
    [ActionCategory(Category.RandomFromList)]
    public class GetRandomTransform : BaseAction
    {
        [HideLabel]
        [Tooltip("A list of items to pick from. The weight determines how likely an item is to be chosen.")]
        public WeightedTransformVarList Transforms;

        [Tooltip(Strings.NoRepeatWeightedTooltip)]
        public BoolVar NoRepeat;
        
        [Tooltip("Store the selected item in a variable.")]
        [WriteOnly]
        public TransformRef StoreResult;

        private TransformVar _lastItem;

        public override bool CanExecute() => CheckParameters(Transforms, NoRepeat, StoreResult);

        public override void Execute()
        {
            var item = Transforms.GetRandomItem(_lastItem, NoRepeat.Value);
            StoreResult.Value = item.Value;
            _lastItem = item;
        }
        
        public override string GetSummary() => "Get Random Transform from {Transforms} -> {StoreResult}";
    }
}

