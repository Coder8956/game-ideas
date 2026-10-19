/* WIP

 Maybe use Array2D type instead?
 
using System;
using System.Collections;
using System.Collections.Generic;
using HutongGames.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Extract a column from a list given x and y cell counts.")]
    public class ListGetColumn : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The source list.")]
        [SerializeReference] public IListVariableRef SourceList;

        [Tooltip("The index of the column.")]
        public IntegerVar ColumnIndex;
        
        [Tooltip("The number of cells in x.")]
        public IntegerVar XCount;

        [Tooltip("The number of cells in y.")]
        public IntegerVar yCount;
        
        [MatchType(nameof(SourceList))]
        [Tooltip("The list to store the column.")]
        [WriteOnly, SerializeReference] 
        public IListVariableRef GetColumn;

        public override bool CanExecute() => CheckParameters(SourceList, ColumnIndex, XCount, yCount, GetColumn);

        public override void Execute()
        {
            var column = new List<object>();
            var sourceList = SourceList.GetValue() as IList;
            if (sourceList == null) return;
            
            var x = XCount.Value;
            var y = yCount.Value;
            var columnIndex = ColumnIndex.Value;
            for (var i = 0; i < y; i++)
            {
                column.Add(sourceList[columnIndex + i * x]);
            }
            GetColumn.SetValue(column);
        }

        public override string GetSummary() => "Get column {ColumnIndex} from {SourceList} x: {XCount} y: {yCount} -> {GetColumn}";
    }
}
*/