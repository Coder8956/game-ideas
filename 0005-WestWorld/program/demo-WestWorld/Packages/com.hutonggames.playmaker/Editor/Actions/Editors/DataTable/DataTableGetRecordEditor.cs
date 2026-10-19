using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataTableGetRecord))]
    public sealed class DataTableGetRecordEditor : BaseDataTableWithOverrideEditor<DataTableGetRecord>
    {
        protected override void BuildBeforeContentGUI()
        {
            AddField(nameof(DataTableGetRecord.Row));
        }

        protected override void BuildAfterContentGUI()
        {
            AddField(nameof(DataTableGetRecord.OnRowNotFound));
            AddField(nameof(DataTableGetRecord.Record));
            AddField(nameof(DataTableGetRecord.Found));
            AddField(nameof(DataTableGetRecord.NotFoundEvent));
        }

        protected override void BuildTableUI(DataDefinition definition)
        {
            // No schema-driven UI. The base editor is used to manage the DataDefinition override visibility.
        }
    }
}
