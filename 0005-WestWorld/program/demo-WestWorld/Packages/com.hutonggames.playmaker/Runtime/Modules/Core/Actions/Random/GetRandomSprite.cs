using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionDescription("Get random sprite from a list of sprites.")]
    [ActionCategory(Category.RandomFromList)]
    public class GetRandomSprite : BaseAction
    {
        [HideLabel]
        [Tooltip("A list of items to pick from. The weight determines how likely an item is to be chosen.")]
        public WeightedSpriteVarList Sprites;

        [Tooltip(Strings.NoRepeatWeightedTooltip)]
        public BoolVar NoRepeat;
        
        [Tooltip("Store the selected item in a variable.")]
        [WriteOnly]
        public SpriteRef StoreResult;

        private SpriteVar _lastItem;

        public override bool CanExecute() => CheckParameters(Sprites, NoRepeat, StoreResult);

        public override void Execute()
        {
            var item = Sprites.GetRandomItem(_lastItem, NoRepeat.Value);
            StoreResult.Value = item.Value;
            _lastItem = item;
        }
        
        public override string GetSummary() => "Get Random Sprite from {Sprites} -> {StoreResult}";
    }
}

