using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionDescription( "Gets a random GameObject from a list of GameObjects." )]
    [ActionCategory(Category.RandomFromList)]
    public class GetRandomGameObject : BaseAction
    {
        [HideLabel]
        [Tooltip("A list of items to pick from. The weight determines how likely an item is to be chosen.")]
        public WeightedGameObjectVarList GameObjects;

        [Tooltip(Strings.NoRepeatWeightedTooltip)]
        public BoolVar NoRepeat;
        
        [Tooltip("Store the selected item in a variable.")]
        [WriteOnly]
        public GameObjectRef StoreResult;

        private GameObjectVar _lastItem;

        public override bool CanExecute() => CheckParameters(GameObjects, NoRepeat, StoreResult);

        public override void Execute()
        {
            var item = GameObjects.GetRandomItem(_lastItem, NoRepeat.Value);
            StoreResult.Value = item.Value;
            _lastItem = item;
        }
        
        public override string GetSummary() => "Get Random GameObject from {GameObjects} -> {StoreResult}";
    }
}

