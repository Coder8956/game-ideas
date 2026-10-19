using HutongGames.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GetComponent")]
    [ActionDescription("Add a Component to a GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.AddComponent.html")]
    public class GameObjectAddComponent : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [BaseType(typeof(Component))]
        [Tooltip("The type of Component to add. E.g., 'Rigidbody' or 'Renderer'")]
        public TypeReference ComponentType;
        
        [SerializeReference, OptionalField]
        [WriteOnly, MatchType(nameof(ComponentType))]
        [Tooltip("Store the result in a Component variable")]
        public IVariableRef StoreAddedComponent;
        
        public override void Execute()
        {
            StoreAddedComponent?.SetValue(GameObject.Value.AddComponent(ComponentType.Type));
        }

        public override string GetSummary() => 
            "Add {ComponentType} component to {GameObject}" +
            (StoreAddedComponent != null && StoreAddedComponent.HasValue() ? " -> {StoreAddedComponent}" : "");
    }
}
