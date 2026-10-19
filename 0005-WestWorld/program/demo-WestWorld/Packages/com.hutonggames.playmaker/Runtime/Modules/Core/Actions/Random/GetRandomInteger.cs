using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionDescription("Get random integer from a list of integers.")]
    [ActionCategory(Category.RandomFromList)]
    public class GetRandomInteger : BaseAction
    {
        [HideLabel]
        [Tooltip("A list of items to pick from. The weight determines how likely an item is to be chosen.")]
        public WeightedIntegerVarList Integers;

        [Tooltip(Strings.NoRepeatWeightedTooltip)]
        public BoolVar NoRepeat;
        
        [Tooltip("Store the selected item in a variable.")]
        [WriteOnly]
        public IntegerRef StoreResult;

        private IntegerVar _lastItem;

        public override bool CanExecute() => CheckParameters(Integers, NoRepeat, StoreResult);

        public override void Execute()
        {
            var item = Integers.GetRandomItem(_lastItem, NoRepeat.Value);
            StoreResult.Value = item.Value;
            _lastItem = item;
        }

        public override string GetSummary() => "Get Random Integer from {Integers} -> {StoreResult}";
    }
}

