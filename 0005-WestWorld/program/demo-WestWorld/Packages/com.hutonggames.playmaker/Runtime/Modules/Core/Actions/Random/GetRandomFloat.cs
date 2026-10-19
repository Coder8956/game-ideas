using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionDescription("Gets a random float from a list of floats.")]
    [ActionCategory(Category.RandomFromList)]
    public class GetRandomFloat : BaseAction
    {
        [HideLabel]
        [Tooltip("A list of items to pick from. The weight determines how likely an item is to be chosen.")]
        public WeightedFloatVarList Floats;

        [Tooltip(Strings.NoRepeatWeightedTooltip)]
        public BoolVar NoRepeat;
        
        [Tooltip("Store the selected item in a variable.")]
        [WriteOnly]
        public FloatRef StoreResult;

        private FloatVar _lastItem;

        public override bool CanExecute() => CheckParameters(Floats, NoRepeat, StoreResult);

        public override void Execute()
        {
            var item = Floats.GetRandomItem(_lastItem, NoRepeat.Value);
            StoreResult.Value = item.Value;
            _lastItem = item;
        }
        
        public override string GetSummary() => "Get Random Float from {Floats} -> {StoreResult}";
    }
}

