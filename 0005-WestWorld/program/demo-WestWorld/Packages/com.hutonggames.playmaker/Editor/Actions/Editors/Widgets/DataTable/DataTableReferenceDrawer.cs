using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [CustomPropertyDrawer(typeof(DataTableReference))]
    public sealed class DataTableReferenceDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var root = new VisualElement();
            root.style.minWidth = 0;
            root.style.flexDirection = FlexDirection.Column;

            var sourceProp = property.FindPropertyRelative("_source");
            var assetProp = property.FindPropertyRelative("_tableAsset");
            var compProp = property.FindPropertyRelative("_tableComponent");

            var sourceField = new PropertyField(sourceProp, "Source");
            root.Add(sourceField);

            var assetField = new PropertyField(assetProp, "Table Asset");
            var compField = new PropertyField(compProp, "Table Component");

            root.Add(assetField);
            root.Add(compField);

            void Refresh()
            {
                var src = (DataTableReference.TableSource)sourceProp.enumValueIndex;
                assetField.style.display = src == DataTableReference.TableSource.Asset ? DisplayStyle.Flex : DisplayStyle.None;
                compField.style.display = src == DataTableReference.TableSource.Component ? DisplayStyle.Flex : DisplayStyle.None;
            }

            sourceField.RegisterValueChangeCallback(_ =>
            {
                property.serializedObject.Update();
                Refresh();
            });

            Refresh();
            return root;
        }
    }
}
