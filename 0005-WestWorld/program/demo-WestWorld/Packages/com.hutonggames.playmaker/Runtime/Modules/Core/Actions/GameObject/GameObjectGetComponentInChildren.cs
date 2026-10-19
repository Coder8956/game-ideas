using HutongGames.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GetComponent")]
    [ActionDescription("Get a Component on a GameObject, or any child of the GameObject. By default, Unity includes components on the root GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.GetComponentInChildren.html")]
    public class GameObjectGetComponentInChildren : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;

        [Tooltip("The type of Component to get. E.g., 'Rigidbody' or 'Renderer'")]
        [BaseType(typeof(Component))]
        public TypeReference ComponentType;
        
        [Tooltip("Should the search include inactive GameObjects?")]
        public BoolVar IncludeInactive;

        [Tooltip("Exclude components on the root GameObject from the result.")]
        public BoolVar ExcludeRoot = new();
        
        [SerializeReference]
        [WriteOnly, MatchType(nameof(ComponentType))]
        [Tooltip("Store the result in a Component variable")]
        public IVariableRef StoreResult;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            StoreResult?.SetValue(GetComponentInChildren());
        }

        private Component GetComponentInChildren()
        {
            var gameObject = GameObject.Value;
            var includeInactive = IncludeInactive.Value;
            if (ExcludeRoot is not { Value: true })
            {
                return gameObject.GetComponentInChildren(ComponentType.Type, includeInactive);
            }

            var components = gameObject.GetComponentsInChildren(ComponentType.Type, includeInactive);
            foreach (var component in components)
            {
                if (component == null || component.gameObject != gameObject)
                {
                    return component;
                }
            }

            return null;
        }

        public override string GetSummary() => "Get {ComponentType} component on {GameObject} or children -> {StoreResult}" 
                                               + (IncludeInactive.Value ? " (including inactive)" : "")
                                               + (ExcludeRoot is { Value: true } ? " (excluding root)" : "");
    }
}
