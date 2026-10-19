using HutongGames.Editor.Extensions;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataTableFindRow))]
    public sealed class DataTableFindRowEditor : BaseDataTableWithOverrideEditor<DataTableFindRow>
    {
        protected override void BuildAfterContentGUI()
        {
            AddField(nameof(DataTableFindRow.Index));
            AddField(nameof(DataTableFindRow.Key));
            AddField(nameof(DataTableFindRow.Record));
            AddField(nameof(DataTableFindRow.Found));
            AddField(nameof(DataTableFindRow.NotFoundEvent));
        }

        protected override void BuildTableUI(DataDefinition definition)
        {
            var property = TargetProperty.FindPropertyRelative(nameof(DataTableFindRow.FindFirstRowWhere));
            if (property?.GetTargetObject() is not ConditionTest conditionTest)
                return;

            ContentRoot.Add(new ConditionTestEditor(conditionTest, property, typeof(DataRow)));
        }
    }
}
