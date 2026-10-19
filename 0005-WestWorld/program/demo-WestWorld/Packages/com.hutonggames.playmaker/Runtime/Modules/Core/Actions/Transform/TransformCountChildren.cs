using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("GetChild")]
    [ActionDescription("Count the number of children, with recursive option. For a simple child count use Get Child Count.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-childCount.html")]
    public class TransformCountChildren : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The parent Transform.")]
        public TransformVar ParentTransform;

        [WriteOnly]
        [Tooltip("Store the child count in a variable.")]
        public IntegerRef GetChildCount;
        
        [Tooltip("Recursive count. Counts the children of the children...")]
        [DefaultValue(true)]
        public BoolVar Recursive;
        
        public override bool CanExecute() => CheckParameters(ParentTransform, GetChildCount, Recursive);

        public override void Execute()
        {
            var transform = ParentTransform.Value;
            if (transform == null) return;
            GetChildCount.Value = CountChildren(transform);
        }
        
        public static int CountChildren(Transform parent) 
        {
            int count = 0;

            foreach (Transform child in parent) 
            {
                count += CountChildren(child);    // add the number of children the child has to total
                ++count;                          // add the child itself to total
            }

            return count;
        }
        
        public override string GetSummary() => "Count {ParentTransform} children -> {GetChildCount} {Recursive:option}";
    }
}