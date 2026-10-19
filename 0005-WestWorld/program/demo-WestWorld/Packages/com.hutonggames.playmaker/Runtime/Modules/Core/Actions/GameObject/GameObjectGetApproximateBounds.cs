using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get the bounds of a GameObject and its children using an approximate size for the children. " +
                       "This is faster than Get Bounds, but less accurate if the child GameObjects are very different in size.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-bounds.html")]
    public class GameObjectGetApproximateBounds : BaseAction
    {
        [Tooltip("The target GameObject.")]
        [SerializeField]
        private GameObjectVar _gameObject;

        [Tooltip("A fixed size used to approximate the parent size. Leave at zero if you just want to get the bounds of the children.")]
        [SerializeField]
        private Vector3Var _parentSize;
        
        [Tooltip("A fixed size used to approximate bounds. Works well if all GameObjects are similar in size.")]
        [SerializeField, DefaultValue("Vector3.one")]
        private Vector3Var _childSize;
        
        [Tooltip("Include children in the bounds calculation.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _includeChildren;
        
        [Tooltip("Get the bounds.")]
        [SerializeField, WriteOnly]
        private BoundsRef _getBounds;
        
        public override bool CanExecute() => CheckParameters(_gameObject, _parentSize, _childSize, _includeChildren, _getBounds); 
        
        public override void Execute() =>
            _getBounds.Value = _includeChildren.Value 
                ? GetCombinedBounds(_gameObject.Value) 
                : new Bounds(_gameObject.Value.transform.position, _parentSize.Value);
        
        private Bounds GetCombinedBounds(GameObject parent)
        {
            var combinedBounds = GetCombinedBoundsRecursive(parent, new Bounds());
            
            if (_parentSize.Value != Vector3.zero)
            {
                combinedBounds = new Bounds(parent.transform.position, _parentSize.Value);
            }
            
            return combinedBounds;
        }
        
        private Bounds GetCombinedBoundsRecursive(GameObject parent, Bounds combinedBounds) 
        {
            foreach (Transform child in parent.transform)
            {
                var childBounds = new Bounds(child.position, _childSize.Value);
                if (combinedBounds.size == Vector3.zero)
                {
                    combinedBounds = childBounds;
                }
                else
                {
                    combinedBounds.Encapsulate(childBounds);
                }
                
                GetCombinedBoundsRecursive(child.gameObject, combinedBounds);
            }

            return combinedBounds;
        }

        public override string GetSummary() => "Get {_gameObject} approximate bounds -> {_getBounds} ";
    }
}