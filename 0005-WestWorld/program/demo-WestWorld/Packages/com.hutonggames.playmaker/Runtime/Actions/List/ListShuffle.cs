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
    [ActionDescription("Shuffle items in a list.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.item")]
    public class ListShuffle : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;
        
        public override bool CanExecute() => CheckParameters(List);

        public override void Execute()
        {
            var list = List.ListVariable;
            
            // Knuth-Fisher-Yates algorithm
            
            for (var i = list.Count-1; i > 0; i--)
            {
                // Set swapWithPos a random position such that 0 <= swapWithPos <= i
                var swapWithPos = Random.Range(0, i + 1);
				
                // Swap the value at the "current" position (i) with value at swapWithPos
                (list[i], list[swapWithPos]) = (list[swapWithPos], list[i]);
            }
        }

        public override string GetSummary() => "Shuffle {List}";
    }
}