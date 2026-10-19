using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Loop)]
    [ActionDescription("Run actions in this state on each child of a GameObject." +
                       "\n\nUse Recursive to include all descendants." +
                       "\n\nIf the parent has no children, no actions will be run." +
                       "\n\nNOTE: We capture the children when the loop starts, so actions that add or remove children will not affect the loop.")]
    public class ForEachChild : BaseForEachAction
    {
        [OwnerDefaultValue]
        [Tooltip("The parent.")]
        [SerializeField]
        private GameObjectVar _parent;

        [Tooltip("The current child.")]
        [SerializeField, WriteOnly]
        private GameObjectRef _child;

        [Tooltip("Also loop through all descendants.")]
        [SerializeField]
        private bool _recursive;

        private Transform ParentTransform => _parent.Value ? _parent.Value.transform : null;

        protected override int ItemCount => _children?.Length ?? 0;

        [NonSerialized] private GameObject[] _children;

        public override bool CanExecute() => CheckParameters(_parent, _child);

        public override void OnStart()
        {
            var parentTransform = ParentTransform;
            if (parentTransform == null)
            {
                _children = null;
                Finish();
                return;
            }

            if (_children == null)
            {
                // Store children in array to avoid issues if children are added/removed during loop
                _children = GetChildren(parentTransform, _recursive);
                //Debug.Log($"{parentTransform.name}: {parentTransform.childCount}  {_children.Length}");
            }

            base.OnStart();

            if (_children?.Length == 0)
            {
                _children = null;
            }
        }

        protected override void OnLoopFinished()
        {
            _children = null;
            base.OnLoopFinished();
        }

        public override void EachAction(int index)
        {
            //Debug.Log(NextItemIndex);
            _child.Value = _children[index];
        }

        internal static GameObject[] GetChildren(Transform parent, bool recursive)
        {
            if (parent == null)
            {
                return Array.Empty<GameObject>();
            }

            if (!recursive)
            {
                var children = new GameObject[parent.childCount];
                for (var i = 0; i < parent.childCount; i++)
                {
                    children[i] = parent.GetChild(i).gameObject;
                }

                return children;
            }

            var descendants = new List<GameObject>();
            AddChildrenRecursive(parent, descendants);
            return descendants.ToArray();
        }

        private static void AddChildrenRecursive(Transform parent, List<GameObject> children)
        {
            for (var i = 0; i < parent.childCount; i++)
            {
                var child = parent.GetChild(i);
                children.Add(child.gameObject);
                AddChildrenRecursive(child, children);
            }
        }

        public override string GetSummary() => _recursive
            ? "For each child of {_parent} recursively -> {_child}"
            : "For each child of {_parent} -> {_child}";
    }
}
