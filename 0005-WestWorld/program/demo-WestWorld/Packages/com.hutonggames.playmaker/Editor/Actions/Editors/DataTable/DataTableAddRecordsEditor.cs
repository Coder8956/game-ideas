using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataTableAddRecords))]
    public sealed class DataTableAddRecordsEditor : BaseDataTableWithOverrideEditor<DataTableAddRecords>
    {
        protected override void BuildBeforeContentGUI()
        {
            AddField(nameof(DataTableAddRecords.Source));
            AddField(nameof(DataTableAddRecords.SourceDataTableComponent));
            AddField(nameof(DataTableAddRecords.SourceDataTableAsset));
            AddField(nameof(DataTableAddRecords.SourceDataTable));
            AddField(nameof(DataTableAddRecords.DataComponents));
            AddField(nameof(DataTableAddRecords.Records));
            AddField(nameof(DataTableAddRecords.UseSourceKeys));
        }

        protected override void BuildAfterContentGUI()
        {
            AddField(nameof(DataTableAddRecords.AddedCount));
            AddField(nameof(DataTableAddRecords.Added));
        }

        protected override void BuildTableUI(DataDefinition definition)
        {
            // No schema-driven fields for this action.
        }
    }
}
