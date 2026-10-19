using HutongGames.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GetComponent")]
    [ActionDescription("Get a Component on a GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html")]
    public class GameObjectGetComponent : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [BaseType(typeof(Component))]
        [Tooltip("The type of Component to get. E.g., 'Rigidbody' or 'Renderer'")]
        public TypeReference ComponentType;
        
        [SerializeReference]
        [WriteOnly, MatchType(nameof(ComponentType))]
        [Tooltip("Store the result in a Component variable")]
        public IVariableRef StoreResult;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            StoreResult?.SetValue(GameObject.Value.GetComponent(ComponentType.Type));
        }
        
        public override string GetSummary() => "Get {ComponentType} component on {GameObject} -> {StoreResult}";
    }
}
