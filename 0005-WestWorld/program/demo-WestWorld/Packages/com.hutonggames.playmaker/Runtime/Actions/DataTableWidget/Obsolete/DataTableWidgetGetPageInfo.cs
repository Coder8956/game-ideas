using System;
using UnityEngine;
using HutongGames.PlayMaker.UI;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [Obsolete("Use DataPagingGetPageInfo action instead.")]
    [ConvertibleGroup("DataPaging")]
    [ActionCategory(Category.DataTableWidget)]
    [ActionDescription("Gets paging information from a DataTableWidget.")]
    public sealed class DataTableWidgetGetPageInfo : BaseAction
    {
        [Tooltip("The DataTableWidget.")]
        public DataTableWidgetVar Widget;

        [ActionHeader("Store Results")]
        [OptionalField, WriteOnly]
        public IntegerRef PageIndex;
       
        [OptionalField, WriteOnly]
        public IntegerRef TotalPages;

        [OptionalField, WriteOnly]
        public IntegerRef TotalRows;

        public override void Execute()
        {
            // Obsolete
        }

        public override string GetSummary() => "Get Page Info {Widget} {PageIndex:output} {TotalPages:output} {TotalRows:output}";
    }
}