using HutongGames.PlayMaker.Actions; // if RandomAxisValue lives here
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [CustomPropertyDrawer(typeof(RandomAxisValue))]
    public class RandomAxisValuePropertyDrawer : PropertyDrawer
    {
        private const string ModePropName    = "_mode";
        private const string UniformPropName = "_uniform";
        private const string XPropName       = "_x";
        private const string YPropName       = "_y";
        private const string ZPropName       = "_z";
        private const string VectorPropName  = "_vector";

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            // Root container
            var root = new VisualElement();

            // Find relative properties
            var modeProp = property.FindPropertyRelative(ModePropName);
            var uniformProp = property.FindPropertyRelative(UniformPropName);
            var xProp = property.FindPropertyRelative(XPropName);
            var yProp = property.FindPropertyRelative(YPropName);
            var zProp = property.FindPropertyRelative(ZPropName);
            var vectorProp = property.FindPropertyRelative(VectorPropName);

            // Mode dropdown
            var modeField = new EnumField(property.displayName);
            modeField.Init((RandomAxisValueMode)modeProp.enumValueIndex);
            modeField.BindProperty(modeProp);
            modeField.AddToClassList("hutong-field");
            root.Add(modeField);

            // Container for the value fields, slightly indented
            var valuesContainer = new VisualElement();
            valuesContainer.AddToClassList("hutong-field");
            root.Add(valuesContainer);

            // Create the fields using PropertyField so FloatVar / Vector3Var drawers are reused
            var uniformField = BuildPropertyField(uniformProp, "Value");
            var xField = BuildPropertyField(xProp, "X");
            var yField = BuildPropertyField(yProp, "Y");
            var zField = BuildPropertyField(zProp, "Z");
            var vectorField = new PropertyField(vectorProp, "Vector");
            
            valuesContainer.Add(uniformField);
            valuesContainer.Add(xField);
            valuesContainer.Add(yField);
            valuesContainer.Add(zField);
            valuesContainer.Add(vectorField);

            // Local helper to toggle visibility based on mode
            void UpdateVisibility(RandomAxisValueMode mode)
            {
                // Default all hidden
                uniformField.style.display = DisplayStyle.None;
                xField.style.display = DisplayStyle.None;
                yField.style.display = DisplayStyle.None;
                zField.style.display = DisplayStyle.None;
                vectorField.style.display = DisplayStyle.None;

                switch (mode)
                {
                    case RandomAxisValueMode.Disabled:
                        // Nothing else visible
                        break;

                    case RandomAxisValueMode.Uniform:
                        uniformField.style.display = DisplayStyle.Flex;
                        break;

                    case RandomAxisValueMode.PerAxis:
                        xField.style.display = DisplayStyle.Flex;
                        yField.style.display = DisplayStyle.Flex;
                        zField.style.display = DisplayStyle.Flex;
                        break;

                    case RandomAxisValueMode.Vector3Var:
                        vectorField.style.display = DisplayStyle.Flex;
                        break;
                }
            }



            // Initial state
            UpdateVisibility((RandomAxisValueMode)modeProp.enumValueIndex);

            // React to mode changes
            modeField.RegisterValueChangedCallback(evt =>
            {
                var newMode = (RandomAxisValueMode)evt.newValue;
                UpdateVisibility(newMode);
            });

            return root;
        }
        
        private static PropertyField BuildPropertyField(SerializedProperty property, string label)
        {
            var propertyField = new PropertyField(property, label);
            //propertyField.AddToClassList("hutong-field");
            propertyField.AddToClassList("hutong-property-field");
            return propertyField;
        }
    }
}
