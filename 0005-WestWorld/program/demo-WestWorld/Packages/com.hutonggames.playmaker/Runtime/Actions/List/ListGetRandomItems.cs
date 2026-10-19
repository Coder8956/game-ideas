using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ConvertibleGroup("ListGetItem")]
    [ActionDescription("Get random items from the List.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.item")]
    public class ListGetRandomItems : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        [Tooltip("How many random items to get.")]
        public IntegerVar Count;

        [Tooltip("Get only unique items. If Count is greater than the list size, returns all items.")]
        public BoolVar Distinct;

        [MatchType(nameof(List))]
        [Tooltip("Store the random items in a list.")]
        [WriteOnly, SerializeReference] public IListVariableRef GetItems;

        public override bool CanExecute() => CheckParameters(List, Count, Distinct, GetItems);

        public override void Execute()
        {
            var sourceList = List.ListVariable;
            var sourceCount = sourceList.Count;
            var result = new List<object>();
            var resultCount = Mathf.Max(0, Count.Value);

            if (sourceCount == 0 || resultCount == 0)
            {
                GetItems.SetValue(result);
                return;
            }

            if (Distinct.Value)
            {
                resultCount = Mathf.Min(resultCount, sourceCount);
                var indices = new List<int>(sourceCount);

                for (var i = 0; i < sourceCount; i++)
                {
                    indices.Add(i);
                }

                for (var i = 0; i < resultCount; i++)
                {
                    var randomPoolIndex = Random.Range(0, indices.Count);
                    var sourceIndex = indices[randomPoolIndex];

                    result.Add(sourceList[sourceIndex]);
                    indices.RemoveAt(randomPoolIndex);
                }
            }
            else
            {
                for (var i = 0; i < resultCount; i++)
                {
                    var sourceIndex = Random.Range(0, sourceCount);
                    result.Add(sourceList[sourceIndex]);
                }
            }

            GetItems.SetValue(result);
        }

        public override string GetSummary() => "Get {Count} random items from {List} -> {GetItems}";
    }
}
