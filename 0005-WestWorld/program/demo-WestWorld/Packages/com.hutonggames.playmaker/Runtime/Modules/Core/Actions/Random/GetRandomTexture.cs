using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionDescription("Gets a random texture from a list of textures.")]   
    [ActionCategory(Category.RandomFromList)]
    public class GetRandomTexture : BaseAction
    {
        [HideLabel]
        [Tooltip("A list of items to pick from. The weight determines how likely an item is to be chosen.")]
        public WeightedTextureVarList Textures;

        [Tooltip(Strings.NoRepeatWeightedTooltip)]
        public BoolVar NoRepeat;
        
        [Tooltip("Store the selected item in a variable.")]
        [WriteOnly]
        public TextureRef StoreResult;

        private TextureVar _lastItem;

        public override bool CanExecute() => CheckParameters(Textures, NoRepeat, StoreResult);

        public override void Execute()
        {
            var item = Textures.GetRandomItem(_lastItem, NoRepeat.Value);
            StoreResult.Value = item.Value;
            _lastItem = item;
        }
        
        public override string GetSummary() => "Get Random Texture from {Textures} -> {StoreResult}";
    }
}

