
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ConvertibleGroup("ListGetItem")]
    [ActionDescription("Get a random item from the List.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.item")]
    public class ListGetRandomItem : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        [Tooltip("Don't get the same item twice in a row." +
                 "\nNOTE: Does not apply across scene loading/unloading.")]
        public BoolVar NoRepeat;
        
        
        [MatchType(nameof(List))]
        [ConvertibleName("Item")]
        [Tooltip("The item to set.")]
        [WriteOnly, SerializeReference] public IVariableRef GetItem;

        private RandomHelper _randomHelper;
        
        public override bool CanExecute() => CheckParameters(List, NoRepeat, GetItem);

        public override void Execute()
        {
            _randomHelper ??= new RandomHelper();
            
            var itemIndex = _randomHelper.Range(0, List.ListVariable.Count, NoRepeat.Value);
            GetItem.SetValue(List.ListVariable[itemIndex]);
        }
        
        private int GetRandomIndex() => Random.Range(0, List.ListVariable.Count);

        public override string GetSummary() => "Get random item from {List} -> {GetItem}";
    }
}