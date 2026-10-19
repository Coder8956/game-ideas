using HutongGames.Editor.Extensions;
using HutongGames.PlayMaker.Actions;
using UnityEditor;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [CustomPropertyDrawer(typeof(DataRowFieldValueParameter))]
    public sealed class DataRowFieldValueParameterDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property) =>
            new DataFieldPredicateParameterEditor(property, ResolveDataDefinition(property));

        private static DataDefinition ResolveDataDefinition(SerializedProperty property)
        {
            var action = property.GetAncestor<BaseAction>();
            if (action is IDataTableAction dataTableAction)
                return dataTableAction.DataTable.GetEditTimeDataDefinition(dataTableAction.DataDefinition);

            return null;
        }
    }
}
