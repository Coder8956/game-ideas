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
    [ActionDescription("Shuffle a range of values in a list.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.item")]
    public class ListShuffle__Range : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;
        
        [Tooltip("Start index of the range to shuffle.")]
        [SerializeField]
        private IntegerVar _start;

        [Tooltip("Shuffle this number of elements.")]
        [SerializeField] 
        private IntegerVar _count;
        
        public override bool CanExecute() => CheckParameters(List, _start, _count);

        public override void Execute()
        {
            var list = List.ListVariable;
            var start = Math.Max(_start.Value, 0);
            var end = Math.Min(start + _count.Value-1, list.Count-1);
            
            // Knuth-Fisher-Yates algorithm
            
            for (var i = end; i > start; i--)
            {
                // Set swapWithPos a random position such that 0 <= swapWithPos <= i
                var swapWithPos = Random.Range(start,i + 1);
				
                // Swap the value at the "current" position (i) with value at swapWithPos
                (list[i], list[swapWithPos]) = (list[swapWithPos], list[i]);
            }
        }
        
        public override string GetSummary() => "Shuffle {_count} items in {List} starting at {_start}";
    }
}
