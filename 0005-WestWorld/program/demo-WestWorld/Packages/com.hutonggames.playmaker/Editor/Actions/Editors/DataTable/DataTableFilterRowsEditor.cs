using HutongGames.Editor.Extensions;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataTableFilterRows))]
    public sealed class DataTableFilterRowsEditor : BaseDataTableWithOverrideEditor<DataTableFilterRows>
    {
        protected override void BuildBeforeContentGUI()
        {
            AddField(nameof(DataTableFilterRows.Mode));
        }

        protected override void BuildAfterContentGUI()
        {
            AddField(nameof(DataTableFilterRows.AffectedRows));
            AddField(nameof(DataTableFilterRows.Changed));
        }

        protected override void BuildTableUI(DataDefinition definition)
        {
            var property = TargetProperty.FindPropertyRelative(nameof(DataTableFilterRows.Where));
            var conditionTest = property?.GetTargetObject() as ConditionTest;
            if (conditionTest == null)
                return;

            ContentRoot.Add(new ConditionTestEditor(conditionTest, property, typeof(DataRow)));
        }
    }
}
