using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get the bounds of a GameObject and its children." +
                       "\n\nNOTE: This action calls GetComponents, which can be expensive, especially if called every frame. " +
                       "For a cheaper alternative, see Get Approximate Bounds, which works well if the child GameObjects are similar in size.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-bounds.html")]
    public class GameObjectGetBounds : BaseAction
    {
        [Tooltip("The target GameObject.")]
        [SerializeField]
        private GameObjectVar _gameObject;
        
        [Tooltip("Include children in the bounds calculation.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _includeChildren;
        
        [Tooltip("Get the bounds.")]
        [SerializeField, WriteOnly]
        private BoundsRef _getBounds;
        
        private GameObject _cachedGameObject;
        private Renderer _cachedRenderer;
        
        public override bool CanExecute() => CheckParameters(_gameObject, _includeChildren, _getBounds);
        public override void Execute() =>
            _getBounds.Value = _includeChildren.Value 
                ? GetCombinedBounds(_gameObject.Value) 
                : GetBounds(_gameObject.Value);

        private Bounds GetBounds(GameObject go)
        {
            if (_cachedGameObject != go)
            {
                _cachedGameObject = go;
                _cachedRenderer = null;
            }
            
            _cachedRenderer ??= go.GetComponent<Renderer>();
            return _cachedRenderer.bounds;
        }
        
        private Bounds GetCombinedBounds(GameObject parent) {

            var combinedBounds = new Bounds();
            
            // TODO: Maybe there is a way to cache these renderers?
            // The tricky part is determining when to invalidate the cache
            var renderers = parent.GetComponentsInChildren<Renderer>();
            
            foreach (var rendererChild in renderers) {

                if (combinedBounds.size == Vector3.zero) {
                    combinedBounds = rendererChild.bounds;
                }

                combinedBounds.Encapsulate(rendererChild.bounds);
            }

            return combinedBounds;
        }

        public override string GetSummary() => "Get {_gameObject} bounds -> {_getBounds} " + 
                                               (_includeChildren.Value ? "(including children)" : "");
    }
}