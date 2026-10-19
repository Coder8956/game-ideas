using System.Collections.Generic;
using HutongGames.Editor.Extensions;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataTableAddRecord))]
    public sealed class DataTableAddRecordEditor : BaseDataTableWithOverrideEditor<DataTableAddRecord>
    {
        protected override void BuildBeforeContentGUI()
        {
            AddField(nameof(DataTableAddRecord.Key));
            AddField(nameof(DataTableAddRecord.Record));
            AddField(nameof(DataTableAddRow.Index));
            AddField(nameof(DataTableAddRow.Added));
        }
        
        protected override void BuildTableUI(DataDefinition definition)
        {
            // Empty
        }
    }
}