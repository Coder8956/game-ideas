using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.UI.Widgets.Editor
{
    [CustomEditor(typeof(AnimatedList))]
    public class AnimatedListEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            AddPropertyField(root,"_content");
            AddPropertyField(root,"_itemPrefab");
            AddPropertyField(root,"_hostPrefab");
            AddPropertyField(root,"_itemSizeMode");
            AddPropertyField(root,"_fixedItemSize");
            AddPropertyField(root,"_stretchItemToFillHost");

            AddHeader(root,"Insert Animation");
            
            AddPropertyField(root,"_defaultInsertAnimation.Timing.Duration");
            AddPropertyField(root,"_defaultInsertAnimation.Timing.Ease");
            AddPropertyField(root,"_defaultInsertAnimation.Timing.UseUnscaledTime");
            AddPropertyField(root,"_defaultInsertAnimation.Fade");
            
            AddHeader(root,"Remove Animation");
            
            AddPropertyField(root,"_defaultRemoveAnimation.Timing.Duration");
            AddPropertyField(root,"_defaultRemoveAnimation.Timing.Ease");
            AddPropertyField(root,"_defaultRemoveAnimation.Timing.UseUnscaledTime");
            AddPropertyField(root,"_defaultRemoveAnimation.Fade");
            
            AddPropertyField(root,"_destroyOnRemove");
            AddPropertyField(root,"_maxCount");
            AddPropertyField(root,"_maxAge");

            return root;
        }

        private void AddHeader(VisualElement root, string label)
        {
            var header = new Label(label)
            {
                style =
                {
                    unityFontStyleAndWeight = FontStyle.Bold,
                    marginLeft = 3,
                    marginTop = 13
                }
            };
            root.Add(header);
        }
        
        private void AddPropertyField(VisualElement root, string propertyPath)
        {
            var prop = serializedObject.FindProperty(propertyPath);
            root.Add(new PropertyField(prop));
        }
    }
}