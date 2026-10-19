using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionDescription("Gets a random Color from a list of Colors.")]
    [ActionCategory(Category.RandomFromList)]
    public class GetRandomColor : BaseAction
    {
        [HideLabel]
        [Tooltip("A list of items to pick from. The weight determines how likely an item is to be chosen.")]
        public WeightedColorVarList Colors;

        [Tooltip(Strings.NoRepeatWeightedTooltip)]
        public BoolVar NoRepeat;
        
        [Tooltip("Store the selected item in a variable.")]
        [WriteOnly]
        public ColorRef StoreResult;

        private ColorVar _lastItem;

        public override bool CanExecute() => CheckParameters(Colors, NoRepeat, StoreResult);

        public override void Execute()
        {
            var item = Colors.GetRandomItem(_lastItem, NoRepeat.Value);
            StoreResult.Value = item.Value;
            _lastItem = item;
        }
        
        public override string GetSummary() => "Get Random Color from {Colors} -> {StoreResult}";
    }
}

