using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Find an ancestor by name. Looks up the parent chain until it finds a parent with the specified name.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-parent.html")]
    public class TransformFindAncestor : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;

        [Tooltip("The name of the ancestor to find.")]
        public StringVar AncestorName;
        
        [WriteOnly, Tooltip("Store the result (or null if not found).")]
        public TransformRef Result;

        public override bool CanExecute() => CheckParameters(Transform, AncestorName, Result);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;

            var ancestorName = AncestorName.Value;
            if (string.IsNullOrEmpty(ancestorName))
            {
                Result.Value = null;
                return;
            }

            var current = transform.parent;
            while (current != null)
            {
                if (string.Equals(current.name, ancestorName, StringComparison.Ordinal))
                {
                    Result.Value = current;
                    return;
                }

                current = current.parent;
            }

            // Not found
            Result.Value = null;
        }
        
        public override string GetSummary() => "Find {Transform} ancestor {AncestorName} -> {Result}";
    }
}