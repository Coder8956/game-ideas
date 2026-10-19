using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionDescription("Gets a random string from a list of strings.")]
    [ActionCategory(Category.RandomFromList)]
    public class GetRandomString : BaseAction
    {
        [HideLabel]
        [Tooltip("A list of items to pick from. The weight determines how likely an item is to be chosen.")]
        public WeightedStringVarList Strings;

        [Tooltip(global::HutongGames.PlayMaker.Actions.Strings.NoRepeatWeightedTooltip)]
        public BoolVar NoRepeat;
        
        [Tooltip("Store the selected item in a variable.")]
        [WriteOnly]
        public StringRef StoreResult;

        private StringVar _lastItem;

        public override bool CanExecute() => CheckParameters(Strings, NoRepeat, StoreResult);

        public override void Execute()
        {
            var item = Strings.GetRandomItem(_lastItem, NoRepeat.Value);
            StoreResult.Value = item.Value;
            _lastItem = item;
        }
        
        public override string GetSummary() => "Get Random String from {Strings} -> {StoreResult}";
    }
}

